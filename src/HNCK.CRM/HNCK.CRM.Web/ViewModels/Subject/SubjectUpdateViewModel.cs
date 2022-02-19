using HNCK.CRM.Dto.Subject;
using HNCK.CRM.Model;
using HNCK.CRM.QueryModel;
using HNCK.CRM.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HNCK.CRM.Web.ViewModels.Subject
{
	public class SubjectUpdateViewModel : IViewModel
	{
		public SubjectUpdateViewModel()
		{

		}

		public SubjectUpdateViewModel(IRepositoryServices repositoryServices)
		{
			Countries = repositoryServices.GetCountries()
				.Select(n => new SelectListItem() { Value = n.IdCountry.ToString(), Text = n.NameENShort.ToString() })
				.ToList();
		}

		public SubjectDto Subject { get; set; }
		public string Note { get; set; }
		public IEnumerable<SelectListItem> Countries { get; set; }
	}
}
