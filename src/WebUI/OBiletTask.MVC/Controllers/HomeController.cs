using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OBiletTask.Application.Dtos.Common.RequestModel;
using OBiletTask.Application.Dtos.GetJourneys.RequestModel;
using OBiletTask.Application.Interface.Services;
using OBiletTask.MVC.Extensions;
using OBiletTask.MVC.Models;
using System.Diagnostics;
using System.Text;
using Task_test.Dtos.GetSession.RequestModel;
using Task_test.Dtos.GetSession.ResponseModel;

namespace OBiletTask.MVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly IApiTransactionService _apiTransactionService;

        public HomeController(IApiTransactionService apiTransactionService)
        {
            _apiTransactionService = apiTransactionService;
        }

        public async Task<IActionResult> Index2()
        {
            GetSessionRequestModel model = new GetSessionRequestModel
            {
                browser = new Browser { name = "Chrome", version = "47.0.0.12" },
                connection = new Connection { ipaddress = "0.0.0.1", port = "0000" },
                type = 7
            };
            var result = await _apiTransactionService.GetSession(model);


            if (HttpContext.Session.Get<Data>("SessionId") is null)
            {

                HttpContext.Session.Set<Data>("SessionId", result.Data);
            }

            var get = HttpContext.Session.Get<Data>("SessionId");





            ViewBag.SessionId = result.Data.sessionid;
            ViewBag.DeviceId = result.Data.deviceid;
            return View();
        }

        public async Task<IActionResult> Index()
        {
            GetSessionRequestModel model = new GetSessionRequestModel
            {
                browser = new Browser { name = "Chrome", version = "47.0.0.12" },
                connection = new Connection { ipaddress = "0.0.0.1", port = "0000" },
                type = 7
            };
            var result = await _apiTransactionService.GetSession(model);


            if (HttpContext.Session.Get<Data>("SessionId") is null)
            {

                HttpContext.Session.Set<Data>("SessionId", result.Data);
            }

            var get = HttpContext.Session.Get<Data>("SessionId");





            ViewBag.SessionId = result.Data.sessionid;
            ViewBag.DeviceId = result.Data.deviceid;
            return View();
        }

        public async Task<IActionResult> GetAllBusLocations()
        {

            var getSession = HttpContext.Session.Get<Data>("SessionId");
            if (getSession is null)
            {
                return Json(new { failed = true, message = "Not Found Session Value" });
            }
            CommonRequestModel<object> getallBusLocationRequestModel = new()
            {
                Date = DateTime.Now,
                Language = "tr-TR",
                Data = null,
                DeviceSession = new DeviceSession()
                {
                    deviceid = getSession.deviceid,
                    sessionid = getSession.sessionid,
                }
            };
            var result = await _apiTransactionService.GetAllBusLocations(getallBusLocationRequestModel);
            if (result != null)
            {
                return Json(new { failed = false, data = result.data.Take(7) });
            }
            else
            {
                return Json(new { failed = true, message = "Not Found Session Value" });
            }

        }
        [HttpPost]
        public async Task<IActionResult> GetBusLocationByText(string searchText)
        {

            var getSession = HttpContext.Session.Get<Data>("SessionId");
            if (getSession is null)
            {
                return Json(new { failed = true, message = "Not Found Session Value" });
            }
            CommonRequestModel<object> getallBusLocationRequestModel = new()
            {
                Date = DateTime.Now,
                Language = "tr-TR",
                Data = (searchText == null ? null : searchText),
                DeviceSession = new DeviceSession()
                {
                    deviceid = getSession.deviceid,
                    sessionid = getSession.sessionid,
                }
            };
            var result = await _apiTransactionService.GetAllBusLocations(getallBusLocationRequestModel);
            if (result != null)
            {
                return Json(new { failed = false, data = result.data });
            }
            else
            {
                return Json(new { failed = true, message = "Not Found Session Value" });
            }

        }
        [HttpPost]
        public async Task<IActionResult> GetBusJourneys(GetBusJourneysRequestData model)
        {

            var getSession = HttpContext.Session.Get<Data>("SessionId");
            if (getSession is null)
            {
                return Json(new { failed = true, message = "Not Found Session Value" });
            }
            CommonRequestModel<GetBusJourneysRequestData> getallBusLocationRequestModel = new()
            {
                Date = DateTime.Now,
                Language = "tr-TR",
                Data = model,
                DeviceSession = new DeviceSession()
                {
                    deviceid = getSession.deviceid,
                    sessionid = getSession.sessionid,
                }
            };
            var result = await _apiTransactionService.GetBusJourneys(getallBusLocationRequestModel);
            if (result != null)
            {
                //return Json(new { failed = false, data = result.data });
                return PartialView("~/Views/Home/_PartialJourneyItem.cshtml", result);
            }
            else
            {
                return Json(new { failed = true, message = "Not Found Session Value" });
            }

        }
        public IActionResult Journeys()
        {
            return View();
        }



    }
}
