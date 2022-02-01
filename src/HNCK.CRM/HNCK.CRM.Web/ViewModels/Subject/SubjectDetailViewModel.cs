using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HNCK.CRM.Web.ViewModels.Subject
{
	public class SubjectDetailViewModel
	{
		public int IdSubject { get; set; }
		[DisplayName("FirstName")]
		public string FirstName { get; set; }
		[DisplayName("LastName")]
		public string LastName { get; set; }
		[DisplayName("Email")]
		public string Email { get; set; }
		[DisplayName("TelNumber")]
		public string TelNumber { get; set; }
		[DisplayName("FullAddress")]
		public string FullAddress { get; set; }
	}
}
