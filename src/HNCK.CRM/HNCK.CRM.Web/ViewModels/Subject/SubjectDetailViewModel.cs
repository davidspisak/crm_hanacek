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
		[DisplayName("First name")]
		public string FirstName { get; set; }
		[DisplayName("Last name")]
		public string LastName { get; set; }
		[DisplayName("Email")]
		public string Email { get; set; }
		[DisplayName("Tel. number")]
		public string TelNumber { get; set; }
		[DisplayName("City")]
		public string FullAddress { get; set; }
	}
}
