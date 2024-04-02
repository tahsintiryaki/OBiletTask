using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OBiletTask.Application.Dtos.Common.RequestModel;
using OBiletTask.Application.Dtos.Common.ResponseModel;
using OBiletTask.Application.Dtos.GetBusLocations;
using OBiletTask.Application.Dtos.GetJourneys.RequestModel;
using OBiletTask.Application.Dtos.GetJourneys.ResponseModel;
using OBiletTask.Application.Enums;
using OBiletTask.Application.Interface.Repositories;
using OBiletTask.Application.ViewModel.GeetSession;
using OBiletTask.Application.ViewModel.GetAllBusLocations;
using OBiletTask.Application.ViewModel.GetJourneys;
using OBiletTask.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_test.Dtos.GetSession.RequestModel;
using Task_test.Dtos.GetSession.ResponseModel;
using UAParser;

namespace OBiletTask.Infrastructure.Repositories
{
    public class ApiTransactionRepository : IApiTransactionRepository
    {
        /// <summary>
        ///Api requestlerimi repository katmanınya yaptım. Sizin gönderdiğiniz taskta böyle bir istek yok ama  Apiden gelen kayıtlar sonucunda o kayıtları ile birlikte DB de işlem yapmam gerekebileceği senaryo için api requestlerimi repository katmanına ekledim.
        /// </summary>
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        ILogger<ApiTransactionRepository> _logger;
        public ApiTransactionRepository(IHttpContextAccessor httpContextAccessor, IMapper mapper, IConfiguration configuration, ILogger<ApiTransactionRepository> logger)
        {

            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _configuration = configuration;
            _logger = logger;
        }


        public async Task<BaseResponseModel<List<GetJourneysViewModel>>> GetBusJourneys(CommonRequestModel<GetBusJourneysRequestData> model)
        {
            

            try
            {
                string apiUrl = _configuration["ApiUrls:GetBusJourneys"];

            
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

                        var result = JsonConvert.DeserializeObject<GetBusJourneysResponseModel>(responseContent);
                        if (result.status == ApiResponseStatusEnums.Success.ToString())
                        {
                            var mapping = _mapper.Map<List<GetJourneysViewModel>>(result.data);
                            return BaseResponseModel<List<GetJourneysViewModel>>.Success(mapping.OrderBy(t => t.Departure).ToList(), result.status);

                        }

                        return BaseResponseModel<List<GetJourneysViewModel>>.Error(result.status, result.usermessage is null ? "Api tarafında hata oluştu." : result.usermessage);



                    }
                    else
                    {
                        return BaseResponseModel<List<GetJourneysViewModel>>.Error("ApiError", "Beklenmedik bir hata oluştu");


                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
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

                            return BaseResponseModel<List<GetBusLocationViewModel>>.Error(result.status, result.usermessage is null ? "Api tarafında hata oluştu." : result.usermessage);
                        }
                    }

                    return BaseResponseModel<List<GetBusLocationViewModel>>.Error("ApiError", "Beklenmedik bir hata oluştu");

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BaseResponseModel<List<GetBusLocationViewModel>>.Error("ApiError", "Beklenmedik bir hata oluştu");
            }

        }


        public async Task<BaseResponseModel<GetSessionViewModel>> GetSession()
        {
            try
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



                        if (result.Status == ApiResponseStatusEnums.Success.ToString())
                        {
                            var mapping = _mapper.Map<GetSessionViewModel>(result.Data);

                            return BaseResponseModel<GetSessionViewModel>.Success(mapping, result.Status);
                        }
                        else
                        {

                            return BaseResponseModel<GetSessionViewModel>.Error(result.Status, result.usermessage is null ? "Api tarafında hata oluştu." : result.usermessage);
                        }

                    }
                    else
                    {
                        return BaseResponseModel<GetSessionViewModel>.Error("ApiError", "Beklenmedik bir hata oluştu");

                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                //Log
                return BaseResponseModel<GetSessionViewModel>.Error("ApiError", "Beklenmedik bir hata oluştu");
            }

        }
    }
}
