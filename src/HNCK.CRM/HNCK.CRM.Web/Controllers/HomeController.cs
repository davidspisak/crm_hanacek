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
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			
			return View();
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

			return View();
		}

		[Route("[controller]/[action]/{id}")]
		public IActionResult Delete(int id)
		{
			return View("Index");
		}

		public IActionResult GetSubject_Read([DataSourceRequest] DataSourceRequest request)
		{
			var subjects = new List<SubjectIndexViewModel>();
			DataSourceResult result = subjects.AsQueryable().ToDataSourceResult(request);
			return Json(result);
		}


		public IActionResult GetSubject_Read_Sample([DataSourceRequest] DataSourceRequest request)
		{
			var subjects = new List<SubjectIndexViewModel>();

			subjects.Add(new SubjectIndexViewModel() { IdSubject = 1, FirstName = "Janko", LastName = "Hraško", Email = "hrach@mail.com", TelNumber = "+421 905050550" });
			subjects.Add(new SubjectIndexViewModel() { IdSubject = 2, FirstName = "Ali", LastName = "Baba", Email = "alibaba@mail.com", TelNumber = "+421 955 222 111" });
			subjects.Add(new SubjectIndexViewModel() { IdSubject = 3, FirstName = "Peter", LastName = "Kameň", Email = "suter@mail.com", TelNumber = "+421 988 444 555" });
			subjects.Add(new SubjectIndexViewModel() { IdSubject = 4, FirstName = "Karol", LastName = "Smalym", Email = "malyk@mail.com", TelNumber = "+421 912 134 567" });
			subjects.Add(new SubjectIndexViewModel() { IdSubject = 5, FirstName = "Eugenia", LastName = "Povolna", Email = "povolna@mail.com", TelNumber = "+421 922 333 444" });
			subjects.Add(new SubjectIndexViewModel() { IdSubject = 6, FirstName = "Janko", LastName = "Hraško", Email = "hrach@mail.com", TelNumber = "+421 905050550" });
			subjects.Add(new SubjectIndexViewModel() { IdSubject = 7, FirstName = "Ali", LastName = "Baba", Email = "alibaba@mail.com", TelNumber = "+421 955 222 111" });
			subjects.Add(new SubjectIndexViewModel() { IdSubject = 8, FirstName = "Peter", LastName = "Kameň", Email = "suter@mail.com", TelNumber = "+421 988 444 555" });
			subjects.Add(new SubjectIndexViewModel() { IdSubject = 9, FirstName = "Karol", LastName = "Smalym", Email = "malyk@mail.com", TelNumber = "+421 912 134 567" });
			subjects.Add(new SubjectIndexViewModel() { IdSubject = 10, FirstName = "Eugenia", LastName = "Povolna", Email = "povolna@mail.com", TelNumber = "+421 922 333 444" });

			subjects.Add(new SubjectIndexViewModel() { IdSubject = 11, FirstName = "Janko", LastName = "Hraško", Email = "hrach@mail.com", TelNumber = "+421 905050550" });
			subjects.Add(new SubjectIndexViewModel() { IdSubject = 12, FirstName = "Ali", LastName = "Baba", Email = "alibaba@mail.com", TelNumber = "+421 955 222 111" });
			subjects.Add(new SubjectIndexViewModel() { IdSubject = 13, FirstName = "Peter", LastName = "Kameň", Email = "suter@mail.com", TelNumber = "+421 988 444 555" });
			subjects.Add(new SubjectIndexViewModel() { IdSubject = 14, FirstName = "Karol", LastName = "Smalym", Email = "malyk@mail.com", TelNumber = "+421 912 134 567" });
			subjects.Add(new SubjectIndexViewModel() { IdSubject = 15, FirstName = "Eugenia", LastName = "Povolna", Email = "povolna@mail.com", TelNumber = "+421 922 333 444" });
			subjects.Add(new SubjectIndexViewModel() { IdSubject = 16, FirstName = "Janko", LastName = "Hraško", Email = "hrach@mail.com", TelNumber = "+421 905050550" });
			subjects.Add(new SubjectIndexViewModel() { IdSubject = 17, FirstName = "Ali", LastName = "Baba", Email = "alibaba@mail.com", TelNumber = "+421 955 222 111" });
			subjects.Add(new SubjectIndexViewModel() { IdSubject = 18, FirstName = "Peter", LastName = "Kameň", Email = "suter@mail.com", TelNumber = "+421 988 444 555" });
			subjects.Add(new SubjectIndexViewModel() { IdSubject = 19, FirstName = "Karol", LastName = "Smalym", Email = "malyk@mail.com", TelNumber = "+421 912 134 567" });
			subjects.Add(new SubjectIndexViewModel() { IdSubject = 20, FirstName = "Eugenia", LastName = "Povolna", Email = "povolna@mail.com", TelNumber = "+421 922 333 444" });

			subjects.Add(new SubjectIndexViewModel() { IdSubject = 21, FirstName = "2Janko", LastName = "Hraško", Email = "hrach@mail.com", TelNumber = "+421 905050550" });
			subjects.Add(new SubjectIndexViewModel() { IdSubject = 22, FirstName = "2Ali", LastName = "Baba", Email = "alibaba@mail.com", TelNumber = "+421 955 222 111" });
			subjects.Add(new SubjectIndexViewModel() { IdSubject = 23, FirstName = "2Peter", LastName = "Kameň", Email = "suter@mail.com", TelNumber = "+421 988 444 555" });
			subjects.Add(new SubjectIndexViewModel() { IdSubject = 24, FirstName = "2Karol", LastName = "Smalym", Email = "malyk@mail.com", TelNumber = "+421 912 134 567" });
			subjects.Add(new SubjectIndexViewModel() { IdSubject = 25, FirstName = "2Eugenia", LastName = "Povolna", Email = "povolna@mail.com", TelNumber = "+421 922 333 444" });
			subjects.Add(new SubjectIndexViewModel() { IdSubject = 26, FirstName = "2Janko", LastName = "Hraško", Email = "hrach@mail.com", TelNumber = "+421 905050550" });
			subjects.Add(new SubjectIndexViewModel() { IdSubject = 27, FirstName = "2Ali", LastName = "Baba", Email = "alibaba@mail.com", TelNumber = "+421 955 222 111" });
			subjects.Add(new SubjectIndexViewModel() { IdSubject = 28, FirstName = "2Peter", LastName = "Kameň", Email = "suter@mail.com", TelNumber = "+421 988 444 555" });
			subjects.Add(new SubjectIndexViewModel() { IdSubject = 29, FirstName = "2Karol", LastName = "Smalym", Email = "malyk@mail.com", TelNumber = "+421 912 134 567" });
			subjects.Add(new SubjectIndexViewModel() { IdSubject = 30, FirstName = "2Eugenia", LastName = "Povolna", Email = "povolna@mail.com", TelNumber = "+421 922 333 444" });

			DataSourceResult result = subjects.AsQueryable().ToDataSourceResult(request);
			return Json(result);
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
