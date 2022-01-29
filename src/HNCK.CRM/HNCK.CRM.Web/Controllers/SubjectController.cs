using HNCK.CRM.QueryModel;
using HNCK.CRM.Web.Models;
using HNCK.CRM.Web.ViewModels.Subject;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HNCK.CRM.Web.Controllers
{
	public class SubjectController : Controller
	{
		private readonly ILogger<SubjectController> _logger;
		private List<Subjects> subjects = new List<Subjects>();

		public SubjectController(ILogger<SubjectController> logger)
		{
			_logger = logger;
			SetSampleSubjectData();
		}

		public IActionResult Index()
		{
			var vm = new SubjectIndexViewModel();
			vm.Subjects = subjects;
			return View(vm);
		}


		[HttpGet]
		public IActionResult Create()
		{
			var vm = new SubjectCreateViewModel();
			vm.Countries = new List<SelectListItem>
			{
				new SelectListItem {Text = "Slovak Republic", Value = "1"},
				new SelectListItem {Text = "CzechPrepublic", Value = "2"}
			};
			return View(vm);
		}

		[HttpPost]
		public IActionResult Create(SubjectCreateViewModel subject)
		{
			if (!ModelState.IsValid)
			{
				return Error();
			}

			return View("Index");
		}

		[Route("[controller]/[action]/{id}")]
		public IActionResult Delete(int id)
		{
			return View("Index");
		}

		[Route("[controller]/[action]/{id}")]
		public IActionResult Detail(int id)
		{
			var sub = subjects.ElementAt(id-1);
			var vm = new SubjectDetailViewModel()
			{
				FullAddress = sub.FullAddress,
				FirstName = sub.FirstName,
				Email = sub.Email,
				LastName = sub.LastName,
				TelNumber = sub.TelNumber,
				IdSubject = sub.IdSubject
			};
			return View(vm);
		}

		public IActionResult Update(int id)
		{
			var sub = subjects.ElementAt(id - 1);
			var vm = new SubjectUpdateViewModel()
			{
				FirstName = sub.FirstName,
				Email = sub.Email,
				LastName = sub.LastName,
				TelNumber = sub.TelNumber,
				IdSubject = sub.IdSubject
			};
			return View(vm);
		}

		[HttpPost]
		public IActionResult Update(SubjectUpdateViewModel vm)
		{
			return View("Index");
		}

		public IActionResult GetSubject_Read([DataSourceRequest] DataSourceRequest request)
		{
			var subjects = new List<Subjects>();
			DataSourceResult result = subjects.AsQueryable().ToDataSourceResult(request);
			return Json(result);
		}


		public IActionResult GetSubject_Read_Sample([DataSourceRequest] DataSourceRequest request)
		{
			DataSourceResult result = subjects.AsQueryable().ToDataSourceResult(request);
			return Json(result);
		}

		private void SetSampleSubjectData()
		{
			subjects.Add(new Subjects() { IdSubject = 1, FirstName = "Janko", LastName = "Hraško", Email = "hrach@mail.com", TelNumber = "+421 905050550" });
			subjects.Add(new Subjects() { IdSubject = 2, FirstName = "Ali", LastName = "Baba", Email = "alibaba@mail.com", TelNumber = "+421 955 222 111" });
			subjects.Add(new Subjects() { IdSubject = 3, FirstName = "Peter", LastName = "Kameň", Email = "suter@mail.com", TelNumber = "+421 988 444 555" });
			subjects.Add(new Subjects() { IdSubject = 4, FirstName = "Karol", LastName = "Smalym", Email = "malyk@mail.com", TelNumber = "+421 912 134 567" });
			subjects.Add(new Subjects() { IdSubject = 5, FirstName = "Eugenia", LastName = "Povolna", Email = "povolna@mail.com", TelNumber = "+421 922 333 444" });
			subjects.Add(new Subjects() { IdSubject = 6, FirstName = "Janko", LastName = "Hraško", Email = "hrach@mail.com", TelNumber = "+421 905050550" });
			subjects.Add(new Subjects() { IdSubject = 7, FirstName = "Ali", LastName = "Baba", Email = "alibaba@mail.com", TelNumber = "+421 955 222 111" });
			subjects.Add(new Subjects() { IdSubject = 8, FirstName = "Peter", LastName = "Kameň", Email = "suter@mail.com", TelNumber = "+421 988 444 555" });
			subjects.Add(new Subjects() { IdSubject = 9, FirstName = "Karol", LastName = "Smalym", Email = "malyk@mail.com", TelNumber = "+421 912 134 567" });
			subjects.Add(new Subjects() { IdSubject = 10, FirstName = "Eugenia", LastName = "Povolna", Email = "povolna@mail.com", TelNumber = "+421 922 333 444" });

			subjects.Add(new Subjects() { IdSubject = 11, FirstName = "Janko", LastName = "Hraško", Email = "hrach@mail.com", TelNumber = "+421 905050550" });
			subjects.Add(new Subjects() { IdSubject = 12, FirstName = "Ali", LastName = "Baba", Email = "alibaba@mail.com", TelNumber = "+421 955 222 111" });
			subjects.Add(new Subjects() { IdSubject = 13, FirstName = "Peter", LastName = "Kameň", Email = "suter@mail.com", TelNumber = "+421 988 444 555" });
			subjects.Add(new Subjects() { IdSubject = 14, FirstName = "Karol", LastName = "Smalym", Email = "malyk@mail.com", TelNumber = "+421 912 134 567" });
			subjects.Add(new Subjects() { IdSubject = 15, FirstName = "Eugenia", LastName = "Povolna", Email = "povolna@mail.com", TelNumber = "+421 922 333 444" });
			subjects.Add(new Subjects() { IdSubject = 16, FirstName = "Janko", LastName = "Hraško", Email = "hrach@mail.com", TelNumber = "+421 905050550" });
			subjects.Add(new Subjects() { IdSubject = 17, FirstName = "Ali", LastName = "Baba", Email = "alibaba@mail.com", TelNumber = "+421 955 222 111" });
			subjects.Add(new Subjects() { IdSubject = 18, FirstName = "Peter", LastName = "Kameň", Email = "suter@mail.com", TelNumber = "+421 988 444 555" });
			subjects.Add(new Subjects() { IdSubject = 19, FirstName = "Karol", LastName = "Smalym", Email = "malyk@mail.com", TelNumber = "+421 912 134 567" });
			subjects.Add(new Subjects() { IdSubject = 20, FirstName = "Eugenia", LastName = "Povolna", Email = "povolna@mail.com", TelNumber = "+421 922 333 444" });

			subjects.Add(new Subjects() { IdSubject = 21, FirstName = "2Janko", LastName = "Hraško", Email = "hrach@mail.com", TelNumber = "+421 905050550" });
			subjects.Add(new Subjects() { IdSubject = 22, FirstName = "2Ali", LastName = "Baba", Email = "alibaba@mail.com", TelNumber = "+421 955 222 111" });
			subjects.Add(new Subjects() { IdSubject = 23, FirstName = "2Peter", LastName = "Kameň", Email = "suter@mail.com", TelNumber = "+421 988 444 555" });
			subjects.Add(new Subjects() { IdSubject = 24, FirstName = "2Karol", LastName = "Smalym", Email = "malyk@mail.com", TelNumber = "+421 912 134 567" });
			subjects.Add(new Subjects() { IdSubject = 25, FirstName = "2Eugenia", LastName = "Povolna", Email = "povolna@mail.com", TelNumber = "+421 922 333 444" });
			subjects.Add(new Subjects() { IdSubject = 26, FirstName = "2Janko", LastName = "Hraško", Email = "hrach@mail.com", TelNumber = "+421 905050550" });
			subjects.Add(new Subjects() { IdSubject = 27, FirstName = "2Ali", LastName = "Baba", Email = "alibaba@mail.com", TelNumber = "+421 955 222 111" });
			subjects.Add(new Subjects() { IdSubject = 28, FirstName = "2Peter", LastName = "Kameň", Email = "suter@mail.com", TelNumber = "+421 988 444 555" });
			subjects.Add(new Subjects() { IdSubject = 29, FirstName = "2Karol", LastName = "Smalym", Email = "malyk@mail.com", TelNumber = "+421 912 134 567" });
			subjects.Add(new Subjects() { IdSubject = 30, FirstName = "2Eugenia", LastName = "Povolna", Email = "povolna@mail.com", TelNumber = "+421 922 333 444" });
		}


		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
