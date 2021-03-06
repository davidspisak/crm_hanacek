using HNCK.CRM.Dto;
using HNCK.CRM.Dto.Event;
using HNCK.CRM.Dto.Subject;
using HNCK.CRM.Model;
using HNCK.CRM.QueryModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HNCK.CRM.Repository
{
	public interface IRepositoryServices
	{
		/*QUERIES*/
		IEnumerable<SubjectDto> GetAllSubjects();
		Task<SubjectDto> GetSubjectByIdAsync(int id);
		IEnumerable<Addresses> GetSubjectPermanentResidences(int subjectId);
		IEnumerable<Countries> GetCountries();
		IEnumerable<AttachmentDto> GetAttachmentsBySubjectId(int subjectId);
		IEnumerable<UserEventDto> GetUserEvents();


		/*COMMANDS*/
		Task<SubjectDto> SaveSubjectAsync(SubjectDto subject);
		Task<IEnumerable<AttachmentDto>> SaveAttachmentsAsync(IEnumerable<AttachmentDto> attachments);
		Task<UserEventDto> SaveUserEventAsync(UserEventDto userEventDto);
		Task<IEnumerable<UserEventDto>> SaveUserEventAsync(IEnumerable<UserEventDto> userEventDto);

		Task<SubjectDto> UpdateSubjectAsync(SubjectDto subject);
		Task<UserEventDto> UpdateUserEventAsync(UserEventDto userEventDto);

		Task<Subject> RemoveSubjectAsync(int idSubject);
		Task<Subject> RemoveSubjectAsync(Subject subject);
		Task<AttachmentDto> RemoveAttachmentAsync(AttachmentDto attachmentDto);

	}
}