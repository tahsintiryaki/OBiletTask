using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_test.Dtos.GetSession.RequestModel;
using Task_test.Dtos.GetSession.ResponseModel;

namespace OBiletTask.Application.Interface.Repositories
{
    public interface IApiTransactionRepository
    {
        Task<GetSessionResponseModel> GetSession(GetSessionRequestModel model);
    }
}
