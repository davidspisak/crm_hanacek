using HNCK.CRM.Dto.Subject;
using HNCK.CRM.Model;
using HNCK.CRM.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HNCK.CRM.Web.ViewModels.Subject
{
	public class SubjectCreateViewModel : IViewModel
	{
		public bool CreateEventFromResidenceCardValidDate { get; set; }
		public SubjectCreateViewModel()
		{

		}

		public SubjectCreateViewModel(IRepositoryServices repositoryServices)
		{
			Countries = repositoryServices.GetCountries()
				.Select(n => new SelectListItem() { Value = n.IdCountry.ToString(), Text = n.NameENShort.ToString() })
				.ToList();
		}

		//[DisplayName("Subject")]
		public SubjectDto Subject { get; set; } 
		public IEnumerable<SelectListItem> Countries { get; set; }
	}
}
