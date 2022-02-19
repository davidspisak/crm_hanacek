using HNCK.CRM.QueryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNCK.CRM.Web.ViewModels.Subject
{
	public class SubjectIndexViewModel
	{
		public IEnumerable<Subjects> Subjects { get; set; }

		public SubjectIndexViewModel()
		{
			Subjects = new List<Subjects>();
		}
	}
}
