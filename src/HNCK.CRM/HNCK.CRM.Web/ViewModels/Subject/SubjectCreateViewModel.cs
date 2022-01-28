using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HNCK.CRM.Web.ViewModels.Subject
{
	public class SubjectCreateViewModel
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
		public string CityName { get; set; }
		[DisplayName("Street number")]
		public string StreetNumber { get; set; }
		[DisplayName("Street name")]
		public string StreetName { get; set; }
		[DisplayName("ZIP code")]
		public string Zip { get; set; }
		[DisplayName("Country")]
		public int CountryId { get; set; }
		public IEnumerable<SelectListItem> Countries { get; set; }
	}
}
