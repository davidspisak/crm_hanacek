using HNCK.CRM.Dto.Subject;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNCK.CRM.Web.ViewModels.Subject
{
	public interface ISubjectWithAddress : ISubject, IAddress
	{
		public SubjectDto Subject { get; set; }

		public IEnumerable<SelectListItem> Countries { get; set; }
	}
}
