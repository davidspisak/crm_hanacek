using HNCK.CRM.Model;
using HNCK.CRM.QueryModel;
using HNCK.CRM.Repository;
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
using static HNCK.CRM.Common.Enums;

namespace HNCK.CRM.Web.Controllers
{
	public class SubjectController : Controller
	{
		private readonly ILogger<SubjectController> _logger;
		private readonly IRepositoryServices _repositoryServices;

		public SubjectController(ILogger<SubjectController> logger , IRepositoryServices repositoryServices)
		{
			_logger = logger;
			_repositoryServices = repositoryServices;
		}

		public IActionResult Index()
		{
			var vm = new SubjectIndexViewModel();
			return View(vm);
		}

		public IActionResult GetSubject_Read([DataSourceRequest] DataSourceRequest request)
		{
			var subjects = _repositoryServices.GetAllSubjects();
			DataSourceResult result = subjects.AsQueryable().ToDataSourceResult(request);
			return Json(result);
		}


		[HttpGet]
		public IActionResult Create()
		{
			var vm = new SubjectCreateViewModel(_repositoryServices);
			return View(vm);
		}

		[HttpPost]
		public async Task<IActionResult> Create(SubjectCreateViewModel vm)
		{
			if (!ModelState.IsValid)
				return Error();

			await _repositoryServices.SaveSubjectAsync(vm.Subject);
			return View("Index");
		}



		[Route("[controller]/[action]/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			if (!ModelState.IsValid)
				return Error();

			await _repositoryServices.RemoveSubjectAsync(id);
			return RedirectToAction("Index");
		}

		[Route("[controller]/[action]/{id}")]
		public async Task<IActionResult> Detail(int id)
		{
			var vm = new SubjectDetailViewModel();
			vm.Attachments = _repositoryServices.GetAttachmentsBySubjectId(id);
			vm.Subject = await _repositoryServices.GetSubjectByIdAsync(id);
			return View(vm);
		}

		public async Task<IActionResult> Update(int id)
		{
			var vm = new SubjectUpdateViewModel();
			vm.Subject = await _repositoryServices.GetSubjectByIdAsync(id);
			vm.Countries = _repositoryServices.GetCountries()
				.Select(n => new SelectListItem() { Value = n.IdCountry.ToString(), Text = n.NameENShort.ToString() })
				.ToList();
			return View(vm);
		}

		[HttpPost]
		public async Task<IActionResult> Update(SubjectUpdateViewModel vm)
		{
			if (!ModelState.IsValid)
				return Error();

			await _repositoryServices.UpdateSubjectAsync(vm.Subject);
			return View("Index");
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
