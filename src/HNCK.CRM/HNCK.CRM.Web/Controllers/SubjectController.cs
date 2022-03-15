using HNCK.CRM.Common;
using HNCK.CRM.Dto.Event;
using HNCK.CRM.Dto.Subject;
using HNCK.CRM.Model;
using HNCK.CRM.QueryModel;
using HNCK.CRM.Repository;
using HNCK.CRM.Web.Models;
using HNCK.CRM.Web.ViewModels.Subject;
using HNCK.CRM.WordProcessor;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using static HNCK.CRM.Common.Enums;

namespace HNCK.CRM.Web.Controllers
{
	public class SubjectController : Controller
	{
		private readonly ILogger<SubjectController> _logger;
		private readonly IRepositoryServices _repositoryServices;

		public SubjectController(ILogger<SubjectController> logger , IRepositoryServices repositoryServices)
		{
			_logger = logger;
			_repositoryServices = repositoryServices;
		}

		public IActionResult Index()
		{
			var vm = new SubjectIndexViewModel();
			return View(vm);
		}

		public IActionResult GetSubject_Read([DataSourceRequest] DataSourceRequest request)
		{
			var subjects = _repositoryServices.GetAllSubjects();
			DataSourceResult result = subjects.AsQueryable().ToDataSourceResult(request);
			return Json(result);
		}


		[HttpGet]
		public IActionResult Create()
		{
			var vm = new SubjectCreateViewModel(_repositoryServices);
			return View(vm);
		}

		[HttpPost]
		public async Task<IActionResult> Create(SubjectCreateViewModel vm)
		{
			if (!ModelState.IsValid)
				return Error();


			var userEvents = new List<UserEventDto>();
			if (vm.CreateEventFromResidenceCardValidDate && vm.Subject.ResidenceCardValidTo.HasValue)
			{
				var userEventDto = new UserEventDto()
				{
					DueDate = (DateTime)vm.Subject.ResidenceCardValidTo,
					Name = "Residence Card Validation Date - " + vm.Subject.LastName + " " + vm.Subject.FirstName,
					NotificationDate = vm.Subject.ResidenceCardValidTo.Value.AddDays(0-AppSettings.Instance.NotificationDays)
				};
				userEvents.Add(userEventDto);
			}

			vm.Subject.UserEvents = userEvents;
			await _repositoryServices.SaveSubjectAsync(vm.Subject);
			return View("Index");
		}

		[Route("[controller]/[action]/{id}")]
		public async Task<IActionResult> Detail(int id)
		{
			var vm = new SubjectDetailViewModel();
			vm.Attachments = _repositoryServices.GetAttachmentsBySubjectId(id);
			vm.Subject = await _repositoryServices.GetSubjectByIdAsync(id);
			vm.Subject.UserEvents = _repositoryServices.GetUserEvents().Where(x => x.IdSubject == (int)id).OrderBy(x => x.DueDate).ThenBy(x => x.Name);
			vm.UserEventDto = new UserEventDto() { IdSubject = id, DueDate = DateTime.Now};
			return View(vm);
		}

		[HttpPost]
		public async Task<IActionResult> GenerateDocuments(IEnumerable<int> ids, string template)
		{
			var docxTemplate = Path.Combine(Environment.CurrentDirectory, "Content", "DocxTemplates", template);
			var files = new List<string>();
			var subjects = _repositoryServices.GetAllSubjects().Where(x => ids.ToList().Contains((int)x.IdSubject));
			var zipFilePath = Path.Combine(AppSettings.Instance.DownloadTmpStorage, "tmp.zip");

			using (var generator = new DocxGenerator(AppSettings.Instance.DownloadTmpStorage))
			{
				foreach (var s in subjects)
				{
					var file = generator.FulFillDocxWithSubjectData(s, docxTemplate, s.LastName);
					files.Add(file);
				}
			}

			var zipFileMemoryStream = new MemoryStream();
			using (ZipArchive archive = new ZipArchive(zipFileMemoryStream, ZipArchiveMode.Create, leaveOpen: true))
			{
				foreach (var botFilePath in files)
				{
					var botFileName = Path.GetFileName(botFilePath);
					var entry = archive.CreateEntry(botFileName);
					using (var entryStream = entry.Open())
					using (var fileStream = System.IO.File.OpenRead(botFilePath))
					{
						fileStream.CopyTo(entryStream);
					}
				}
			}

			if (System.IO.File.Exists(zipFilePath))
				System.IO.File.Delete(zipFilePath);

			using (var fileStream = System.IO.File.Create(zipFilePath))
			{
				zipFileMemoryStream.Seek(0, SeekOrigin.Begin);
				await zipFileMemoryStream.CopyToAsync(fileStream);
			}
			return Json(new { fileName = zipFilePath });
		}

		public async Task<IActionResult> Download(string fileName)
		{
			var path = fileName;
			var memory = new MemoryStream();
			try
			{
				using (var stream = new FileStream(path, FileMode.Open))
				{
					await stream.CopyToAsync(memory);
				}
			}
			catch (Exception e)
			{
				ModelState.AddModelError("FileNotFoundError", e.Message);
				return Content(e.Message);
			}
			memory.Position = 0;
			return File(memory, "application/zip", "download.zip");
		}



		[Route("[controller]/[action]/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			if (!ModelState.IsValid)
				return Error();

			await _repositoryServices.RemoveSubjectAsync(id);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Update(int id)
		{
			var vm = new SubjectUpdateViewModel();
			vm.Subject = await _repositoryServices.GetSubjectByIdAsync(id);
			vm.Countries = _repositoryServices.GetCountries()
				.Select(n => new SelectListItem() { Value = n.IdCountry.ToString(), Text = n.NameENShort.ToString() })
				.ToList();
			return View(vm);
		}

		[HttpPost]
		public async Task<IActionResult> Update(SubjectUpdateViewModel vm)
		{
			if (!ModelState.IsValid)
				return Error();

			await _repositoryServices.UpdateSubjectAsync(vm.Subject);
			return View("Index");
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
