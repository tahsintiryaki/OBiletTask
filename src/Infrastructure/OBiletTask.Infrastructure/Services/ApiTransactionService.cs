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


namespace OBiletTask.Infrastructure.Services
{
    public class ApiTransactionService : IApiTransactionService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;


        public ApiTransactionService(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<List<GetJourneysViewModel>> GetBusJourneys(CommonRequestModel<GetBusJourneysRequestData> model)
        {


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
                        var response2= _mapper.Map<List<GetJourneysViewModel>>(result.data);
                        return response2.OrderBy(t=>t.Departure).ToList();

                    }
                    else
                    {
                        return null;

                    }
                }
            }
            catch (Exception ex)
            {
                return null;

            }
            // HTTP isteği oluşturma

        }

        public async Task<GetBusLocationResponseModel> GetAllBusLocations(CommonRequestModel<object> model)
        {
            string apiUrl = _configuration["ApiUrls:GetAllBusLocations"];

            // Mevcut token
            string accessToken = _configuration["ApiBasicToken:Value"];

            // POST edilecek model


            // HTTP isteği oluşturma
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

                    var result = JsonConvert.DeserializeObject<GetBusLocationResponseModel>(responseContent);
                    return result;

                }
                else
                {
                    return null;

                }
            }
        }

        public async Task<GetSessionResponseModel> GetSession(GetSessionRequestModel model)
        {
            // API'nin URL'si
            string apiUrl = _configuration["ApiUrls:GetSession"];

            // Mevcut token
            string accessToken = _configuration["ApiBasicToken:Value"];

            // POST edilecek model


            // HTTP isteği oluşturma
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
