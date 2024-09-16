using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OBiletTask.Application.Dtos.Common.RequestModel;
using OBiletTask.Application.Dtos.GetJourneys.RequestModel;
using OBiletTask.Application.Enums;
using OBiletTask.Application.Interface.Services;
using OBiletTask.Application.ViewModel.GeetSession;
using OBiletTask.MVC.Extensions;
using OBiletTask.MVC.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text;
using Task_test.Dtos.GetSession.RequestModel;
using Task_test.Dtos.GetSession.ResponseModel;
using UAParser;


namespace OBiletTask.MVC.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Proje i�erisindeki ba��ml�l�klar� minimize etmek i�in DI kulland�m.
        /// </summary>
        private readonly IApiTransactionService _apiTransactionService;
        private IValidator<GetBusJourneysRequestData> _validator;

        public HomeController(IApiTransactionService apiTransactionService, IHttpContextAccessor httpcontextAccessor, IValidator<GetBusJourneysRequestData> validator)
        {
            _apiTransactionService = apiTransactionService;
            _validator = validator;
        }



        public async Task<IActionResult> Index()
        {
            #region Session
            //Session bilgisini default formatta tuttum. Senaryo gere�i uygulamam�z yo�un trafikli bir uygulama ise sessionlar� In memomy olarak sunucu �zerinde tutmak sunucuyu gereksiz �i�irece�i i�in pek faydal� olmayacakt�r. B�yle bir senaryoda sessionlar�m�z� redis �zerinde saklayabiliriz. 
            #endregion
            var result = await _apiTransactionService.GetSession();
            if (HttpContext.Session.Get<GetSessionViewModel>("SessionId") is null)
            {
                HttpContext.Session.Set<GetSessionViewModel>("SessionId", (GetSessionViewModel)result.Data);
            }
            return View();
        }

        public async Task<IActionResult> GetAllBusLocations()
        {

            var getSession = HttpContext.Session.Get<GetSessionViewModel>("SessionId");
            if (getSession is null)
            {
                return Json(new { failed = true, message = "User Session Not Found." });
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
            var response = await _apiTransactionService.GetAllBusLocations(getallBusLocationRequestModel);

            if (response.Status == ApiResponseStatusEnums.Success.ToString())
            {
                return Json(new { failed = false, data = response.Data });

            }
            else
            {
                return Json(new { failed = true, message = (response.UserMessage is null ? "Api taraf�nda hata olu�tu." : response.UserMessage) });

            }


        }
        [HttpPost]
        public async Task<IActionResult> GetBusLocationByText(string searchText)
        {

            var getSession = HttpContext.Session.Get<GetSessionViewModel>("SessionId");
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
            var response = await _apiTransactionService.GetAllBusLocations(getallBusLocationRequestModel);

            if (response.Status == ApiResponseStatusEnums.Success.ToString())
            {
                return Json(new { failed = false, data = response.Data });

            }
            else
            {
                return Json(new { failed = true, message = (response.UserMessage is null ? "Api taraf�nda hata olu�tu." : response.UserMessage) });

            }
        }
        [HttpPost]
        public async Task<IActionResult> GetBusJourneys(GetBusJourneysRequestData model)
        {
         
           //Backend taraf�nda request model validasyonu yap�ld�.
            FluentValidation.Results.ValidationResult result = await _validator.ValidateAsync(model);
            if (!result.IsValid)
            {

                return Json(new { failed = true, message = result.Errors.FirstOrDefault()?.ErrorMessage }); ;
            }
            var getSession = HttpContext.Session.Get<GetSessionViewModel>("SessionId");
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
            var response = await _apiTransactionService.GetBusJourneys(getallBusLocationRequestModel);

            if (response.Status == ApiResponseStatusEnums.Success.ToString())
            {
                return PartialView("~/Views/Home/_PartialJourneyItem.cshtml", response.Data);
            }
            else
            {
                return Json(new { failed = true, message = (response.UserMessage is null ? "Api taraf�nda hata olu�tu." : response.UserMessage) });

            }


        }
        public IActionResult Journeys()
        {
            return View();
        }
        public IActionResult NotFoundPage(int statuscode)
        {

            if (statuscode > 0)
            {
                ViewBag.StatusCode = statuscode;
            }
            return View();
        }
    }
}
