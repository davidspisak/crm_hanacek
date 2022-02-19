using HNCK.CRM.Common;
using HNCK.CRM.Dto;
using HNCK.CRM.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HNCK.CRM.Web.Controllers
{
	public class AttachmentController : Controller
	{
        private readonly ILogger<SubjectController> _logger;
        private readonly IRepositoryServices _repositoryServices;

		public AttachmentController(ILogger<SubjectController> logger, IRepositoryServices repositoryServices)
        {
            _logger = logger;
            _repositoryServices = repositoryServices;
        }

        public IActionResult Index()
		{
			return View();
		}

        [HttpGet]
        public ActionResult DownloadAttachment(int subjectId, string fileName)
		{
            var attachmentsForDelete = _repositoryServices.GetAttachmentsBySubjectId(subjectId);

            if (fileName != null)
            {
                var attachmentForDelete = attachmentsForDelete.Where(x => x.Name == fileName).FirstOrDefault();
                if (fileName.Length > 0)
                {
                    var path = Path.Combine(AppSettings.Instance.FileStorage, attachmentForDelete.RelativePath);
                    if(System.IO.File.Exists(path))
					{
                        byte[] bytes = System.IO.File.ReadAllBytes(path);
                        return File(bytes, "application/octet-stream", fileName);
                    }
                }
            }
            return RedirectToAction("Index", "Subject");
        }

        public async Task<IActionResult> SaveAttachment(IEnumerable<IFormFile> files, int subjectId)
        {
            var attachmentDtos = new List<AttachmentDto>();

            if (files != null)
            {
				foreach (var attachment in files)
				{
					if (attachment.Length > 0)
					{
                        var path = Path.Combine(AppSettings.Instance.FileStorage, subjectId.ToString());
                        Directory.CreateDirectory(path);

                        Guid idAttachment = Guid.NewGuid();
                        var extension = System.IO.Path.GetExtension(attachment.FileName);
                        var filePath = Path.Combine(path, attachment.FileName);

						if (System.IO.File.Exists(filePath))
						{
                            return Content($"File with name {attachment.FileName} already exists.");
						}

                        if (attachment.Length > AppSettings.Instance.AttachmentMaxSizeInBytes)
                        {
                            return Content($"File {attachment.FileName} is too big. Max allowed size {AppSettings.Instance.AttachmentMaxSizeInBytes/1048576} MB");
                        }

                        using (var stream = System.IO.File.Create(filePath))
						{
							await attachment.CopyToAsync(stream);
						}

                        var attachmentDto = new AttachmentDto()
                        {
                            IdAttachment = idAttachment,
                            Extension = extension,
                            Name = attachment.FileName,
                            Size = attachment.Length,
                            RelativePath = Path.Combine(subjectId.ToString(), attachment.FileName),
                            ContentType = attachment.ContentType,
                            IdSubject = subjectId
                        };
                        attachmentDtos.Add(attachmentDto);
                    }
				}
			}

			if (attachmentDtos != null || attachmentDtos.Count() > 0)
			{
                await _repositoryServices.SaveAttachmentsAsync(attachmentDtos);
            }

            return Content("");
        }

		public async Task<IActionResult> RemoveAttachment(string[] fileNames, int subjectId)
		{

			var attachmentsForDelete = _repositoryServices.GetAttachmentsBySubjectId(subjectId);

			if (fileNames != null)
			{
				foreach (var formFile in fileNames)
				{
					var attachmentForDelete = attachmentsForDelete.Where(x => x.Name == formFile).FirstOrDefault();
					if (formFile.Length > 0)
					{
						var path = Path.Combine(AppSettings.Instance.FileStorage, attachmentForDelete.RelativePath);
						if (System.IO.File.Exists(path))
						{
                            System.IO.File.Delete(path);
                            await _repositoryServices.DeleteAttachmentAsync(attachmentForDelete);
                        }
						else
						{
                            _logger.LogError(new FileNotFoundException(), $"File {formFile} not found.");
                            return Content($"File not found.");
                        }
					}
				}
			}
			return Content("");
		}


	}
}
