using HNCK.CRM.Common;
using HNCK.CRM.Dto;
using HNCK.CRM.Dto.Subject;
using HNCK.CRM.Model;
using HNCK.CRM.QueryModel;
using HNCK.CRM.Repository.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNCK.CRM.Repository
{
	public class RepositoryServices : IRepositoryServices
	{
		private readonly QueryContext _qctx;
		private readonly HnckcrmContext _ctx;

		public RepositoryServices(QueryContext qctx, HnckcrmContext ctx)
		{
			_qctx = qctx;
			_ctx = ctx;
		}

		/*QUERIES*/
		public IEnumerable<SubjectDto> GetAllSubjects()
		{
			var subjects = _qctx.Subjects.AsNoTracking().Where(x => !x.ValidTo.HasValue).OrderBy(x => x.LastName);
			var subjectDtos = SubjectMapper.Map(subjects);
			return subjectDtos;
		} 

		public async Task<SubjectDto> GetSubjectByIdAsync(int id)
		{
			var sub = await _qctx.Subjects.FirstOrDefaultAsync(x => x.IdSubject == id);
			var addrs = GetSubjectPermanentResidences(id).FirstOrDefault();
			var subDto = SubjectMapper.Map(sub, addrs);
			return subDto;
		}

		public IEnumerable<Addresses> GetSubjectPermanentResidences(int SubjectId)
			=> _qctx.Addresses.Where(x => x.IdSubject == SubjectId && x.IdAddressType == (int)Enums.AddressTypeEnum.PermanentResidence).AsNoTracking();

		public IEnumerable<Countries> GetCountries()
			=> _qctx.Countries.AsNoTracking().Where(x => x.IsValid.Value == true);


		public IEnumerable<AttachmentDto> GetAttachmentsBySubjectId(int subjectId)
		{
			var attachments = _qctx.Attachments.AsNoTracking().Where(x => !x.DeletedAt.HasValue && x.IdSubject == subjectId);
			var attachmentDtos = SubjectMapper.Map(attachments);
			return attachmentDtos;
		}


		/*COMMANDS*/
		public async Task<SubjectDto> SaveSubjectAsync(SubjectDto subject)
		{
			var newSubject = SubjectMapper.Map(subject);
			_ctx.Subjects.Add(newSubject);
			await _ctx.SaveChangesAsync();
			return subject;
		}

		public async Task<IEnumerable<AttachmentDto>> SaveAttachmentsAsync(IEnumerable<AttachmentDto> attachments)
		{
			var attachmentsDB = SubjectMapper.Map(attachments);
			_ctx.Attachments.AddRange(attachmentsDB);
			await _ctx.SaveChangesAsync();
			return attachments;
		}


		public async Task<SubjectDto> UpdateSubjectAsync(SubjectDto subject)
		{
			var updatedSubject = SubjectMapper.Map(subject);

			_ctx.Subjects.Update(updatedSubject);
			await _ctx.SaveChangesAsync();

			return subject;
		}

		public async Task<Subject> RemoveSubjectAsync(Subject subject)
		{
			var sub = await RemoveSubjectAsync(subject.IdSubject);
			return sub;
		}

		public async Task<Subject> RemoveSubjectAsync(int idSubject)
		{
			var sub = await _ctx.Subjects.FirstOrDefaultAsync(x => x.IdSubject == idSubject);

			if(sub == null)
				throw new ArgumentException($"Subject with ID {idSubject} does not exists.");

			sub.ValidTo = DateTime.UtcNow;
			_ctx.Subjects.Update(sub);
			await _ctx.SaveChangesAsync();
			return sub;
		}

		public async Task<AttachmentDto> DeleteAttachmentAsync(AttachmentDto attachmentDto)
		{
			var updatedAttachment = SubjectMapper.Map(attachmentDto);
			updatedAttachment.DeletedAt = DateTime.Now;
			_ctx.Attachments.Update(updatedAttachment);
			await _ctx.SaveChangesAsync();
			return attachmentDto;
		}
	}
}
