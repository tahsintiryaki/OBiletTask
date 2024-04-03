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
using OBiletTask.Application.ViewModel.GeetSession;
using OBiletTask.Application.Interface.Repositories;


namespace OBiletTask.Infrastructure.Services
{
    /// <summary>
    ///Repositorydeki metodlara istekte bulunmadan önce iş kuralları burada kontrol edilecektir.
    /// </summary>
    public class ApiTransactionService : IApiTransactionService
    {
     
        private readonly IApiTransactionRepository _apiTransactionRepository;



        public ApiTransactionService(IApiTransactionRepository apiTransactionRepository)
        {
          
            _apiTransactionRepository = apiTransactionRepository;
        }

        public async Task<BaseResponseModel<List<GetJourneysViewModel>>> GetBusJourneys(CommonRequestModel<GetBusJourneysRequestData> model)
        {
            return await _apiTransactionRepository.GetBusJourneys(model);

        }

        public async Task<BaseResponseModel<List<GetBusLocationViewModel>>> GetAllBusLocations(CommonRequestModel<object> model)
        {
            return await _apiTransactionRepository.GetAllBusLocations(model);

        }

        public async Task<BaseResponseModel<GetSessionViewModel>> GetSession()
        {
            return await _apiTransactionRepository.GetSession();
            
           
        }


    }
}
