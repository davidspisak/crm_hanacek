using HNCK.CRM.Dto.Event;
using HNCK.CRM.Repository;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNCK.CRM.Web.Controllers
{
	public class UserEventController : Controller
	{
		private readonly ILogger<SubjectController> _logger;
		private readonly IRepositoryServices _repositoryServices;

		public UserEventController(ILogger<SubjectController> logger, IRepositoryServices repositoryServices)
		{
			_logger = logger;
			_repositoryServices = repositoryServices;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult GetUserEvents_Read([DataSourceRequest] DataSourceRequest request)
		{
			var subjects = _repositoryServices.GetUserEvents().OrderBy(x => x.DueDate).ThenBy(x => x.Name);
			DataSourceResult result = subjects.AsQueryable().ToDataSourceResult(request);
			return Json(result);
		}

		[HttpPost]
		public async Task<IActionResult> Create(UserEventDto userEventDto)
		{
			//if (!ModelState.IsValid)
			//	return Error();

			await _repositoryServices.SaveUserEventAsync(userEventDto);
			return RedirectToAction("Detail", "Subject", new { id = userEventDto.IdSubject});
		}
	}
}
