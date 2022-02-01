using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HNCK.CRM.Web.ViewModels.Subject
{
	public class SubjectCreateViewModel
	{
		public int IdSubject { get; set; }
		[DisplayName("´FirstName")]
		public string FirstName { get; set; }
		[DisplayName("LastName")]
		public string LastName { get; set; }
		[DisplayName("Email")]
		public string Email { get; set; }
		[DisplayName("TelNumber")]
		public string TelNumber { get; set; }
		[DisplayName("City")]
		public string CityName { get; set; }
		[DisplayName("StreetNumber")]
		public string StreetNumber { get; set; }
		[DisplayName("StreetName")]
		public string StreetName { get; set; }
		[DisplayName("ZIPCode")]
		public string Zip { get; set; }
		[DisplayName("Country")]
		public int CountryId { get; set; }
		public IEnumerable<SelectListItem> Countries { get; set; }
	}
}
