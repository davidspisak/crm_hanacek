using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNCK.CRM.Web.ViewModels.Subject
{
	public class SubjectIndexViewModel
	{
		public int IdSubject { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string TelNumber { get; set; }
		public string FullAddress { get; set; } = "Mostná 16, 955 01 Topoľčany, Slovenská republika"; 
	}
}
