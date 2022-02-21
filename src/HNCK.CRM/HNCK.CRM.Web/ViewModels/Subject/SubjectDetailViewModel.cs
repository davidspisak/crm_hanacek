using HNCK.CRM.Common;
using HNCK.CRM.Dto;
using HNCK.CRM.Dto.Event;
using HNCK.CRM.Dto.Subject;
using HNCK.CRM.QueryModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HNCK.CRM.Web.ViewModels.Subject
{
	public class SubjectDetailViewModel : ISubjectViewModel
	{
		public SubjectDto Subject { get; set; }
		public IEnumerable<AttachmentDto> Attachments { get; set; }
		public UserEventDto UserEventDto { get; set; }

		public int AttachmentMaxSizeInBytes => AppSettings.Instance.AttachmentMaxSizeInBytes;

		public SubjectDetailViewModel()
		{
		}
	}
}
