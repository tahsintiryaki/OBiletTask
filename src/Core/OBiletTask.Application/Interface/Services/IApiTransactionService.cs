﻿using OBiletTask.Application.Dtos.Common.RequestModel;
using OBiletTask.Application.Dtos.GetBusLocations;
using OBiletTask.Application.Dtos.GetJourneys.RequestModel;
using OBiletTask.Application.Dtos.GetJourneys.ResponseModel;
using OBiletTask.Application.ViewModel.GetJourneys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_test.Dtos.GetSession.RequestModel;
using Task_test.Dtos.GetSession.ResponseModel;

namespace OBiletTask.Application.Interface.Services
{
    public interface IApiTransactionService
    {
        Task<GetSessionResponseModel> GetSession(GetSessionRequestModel model);
        Task<GetBusLocationResponseModel> GetAllBusLocations(CommonRequestModel<object> model);
        Task<List<GetJourneysViewModel>> GetBusJourneys(CommonRequestModel<GetBusJourneysRequestData> model);

    }
}