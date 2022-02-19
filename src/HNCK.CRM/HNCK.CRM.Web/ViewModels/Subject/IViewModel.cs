using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNCK.CRM.Web.ViewModels.Subject
{
	public interface IViewModel: ISubjectViewModel
	{
		public IEnumerable<SelectListItem> Countries { get; set; }
	}
}
