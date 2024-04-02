using Microsoft.Extensions.Configuration;
using OBiletTask.Application.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_test.Dtos.GetSession.RequestModel;
using Task_test.Dtos.GetSession.ResponseModel;
using Newtonsoft;
using Newtonsoft.Json;
using OBiletTask.Application.Dtos.GetBusLocations;
using OBiletTask.Application.Dtos.Common.RequestModel;
using OBiletTask.Application.Dtos.GetJourneys.ResponseModel;
using OBiletTask.Application.Dtos.GetJourneys.RequestModel;
using AutoMapper;
using OBiletTask.Application.ViewModel.GetJourneys;
using Microsoft.AspNetCore.Http;
using UAParser;
using OBiletTask.Application.Dtos.Common.ResponseModel;
using OBiletTask.Application.Enums;
using OBiletTask.Application.ViewModel.GetAllBusLocations;


namespace OBiletTask.Infrastructure.Services
{
    public class ApiTransactionService : IApiTransactionService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;



        public ApiTransactionService(IConfiguration configuration, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<BaseResponseModel<List<GetJourneysViewModel>>> GetBusJourneys(CommonRequestModel<GetBusJourneysRequestData> model)
        {
            var responseModel = new BaseResponseModel<List<GetJourneysViewModel>>();

            try
            {
                string apiUrl = _configuration["ApiUrls:GetBusJourneys"];

                // Mevcut token
                string accessToken = _configuration["ApiBasicToken:Value"];

                // POST edilecek model
                using (HttpClient client = new HttpClient())
                {
                    // İstek başlığına token'i ekleyin
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", accessToken);

                    // Modeli JSON formatına dönüştürme
                    string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    // HTTP POST isteği gönderme
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    // Yanıtın durum kodunu kontrol etme
                    if (response.IsSuccessStatusCode)
                    {
                        // Yanıt içeriğini okuma
                        string responseContent = await response.Content.ReadAsStringAsync();

                        var result = JsonConvert.DeserializeObject<GetBusJourneysResponseModel>(responseContent);
                        if (result.status == ApiResponseStatusEnums.Success.ToString())
                        {
                            var mapping = _mapper.Map<List<GetJourneysViewModel>>(result.data);
                            return BaseResponseModel<List<GetJourneysViewModel>>.Success(mapping.OrderBy(t => t.Departure).ToList(), result.status);

                        }

                        return BaseResponseModel<List<GetJourneysViewModel>>.Error(result.status, result.usermessage);


                    }
                    else
                    {
                        return BaseResponseModel<List<GetJourneysViewModel>>.Error("ApiError", "Beklenmedik bir hata oluştu");


                    }
                }
            }
            catch (Exception ex)
            {
                //Log kaydı
                return BaseResponseModel<List<GetJourneysViewModel>>.Error("ApiError", "Beklenmedik bir hata oluştu");

            }


        }

        public async Task<BaseResponseModel<List<GetBusLocationViewModel>>> GetAllBusLocations(CommonRequestModel<object> model)
        {
            try
            {
                string apiUrl = _configuration["ApiUrls:GetAllBusLocations"];


                string accessToken = _configuration["ApiBasicToken:Value"];


                using (HttpClient client = new HttpClient())
                {

                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", accessToken);


                    string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");


                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);


                    if (response.IsSuccessStatusCode)
                    {
                        // Yanıt içeriğini okuma
                        string responseContent = await response.Content.ReadAsStringAsync();

                        var result = JsonConvert.DeserializeObject<GetBusLocationResponseModel>(responseContent);

                        if (result.status == ApiResponseStatusEnums.Success.ToString())
                        {
                            var mapping = _mapper.Map<List<GetBusLocationViewModel>>(result.data);

                            return BaseResponseModel<List<GetBusLocationViewModel>>.Success(mapping, result.status);
                        }
                        else
                        {
                            return BaseResponseModel<List<GetBusLocationViewModel>>.Error(result.status, result.usermessage);
                        }
                    }

                    return BaseResponseModel<List<GetBusLocationViewModel>>.Error("ApiError", "Beklenmedik bir hata oluştu");

                }
            }
            catch (Exception ex)
            {
                //Log kaydı
                return BaseResponseModel<List<GetBusLocationViewModel>>.Error("ApiError", "Beklenmedik bir hata oluştu");
            }

        }

        public async Task<GetSessionResponseModel> GetSession()
        {
            string ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            int port = _httpContextAccessor.HttpContext.Connection.LocalPort;
            string userAgentString = _httpContextAccessor.HttpContext.Request.Headers["User-Agent"];


            var uaParser = Parser.GetDefault();
            ClientInfo clientInfo = uaParser.Parse(userAgentString);

            string browserName = clientInfo.UA.Family; // Tarayıcı adı
            string browserVersion = clientInfo.UA.Major; // Tarayıcı versiyonu

            GetSessionRequestModel model = new GetSessionRequestModel
            {
                browser = new Browser { name = browserName, version = browserVersion },
                connection = new Connection { ipaddress = ipAddress, port = port.ToString() },
                type = 7
            };

            string apiUrl = _configuration["ApiUrls:GetSession"];


            string accessToken = _configuration["ApiBasicToken:Value"];


            using (HttpClient client = new HttpClient())
            {

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", accessToken);


                string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");


                HttpResponseMessage response = await client.PostAsync(apiUrl, content);


                if (response.IsSuccessStatusCode)
                {

                    string responseContent = await response.Content.ReadAsStringAsync();


                    var result = JsonConvert.DeserializeObject<GetSessionResponseModel>(responseContent);
                    return result;

                }
                else
                {
                    return null;

                }
            }
        }


    }
}
