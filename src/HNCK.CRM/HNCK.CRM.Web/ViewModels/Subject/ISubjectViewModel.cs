using HNCK.CRM.Dto.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNCK.CRM.Web.ViewModels.Subject
{
	public interface ISubjectViewModel
	{
		public SubjectDto Subject { get; set; }
	}
}
