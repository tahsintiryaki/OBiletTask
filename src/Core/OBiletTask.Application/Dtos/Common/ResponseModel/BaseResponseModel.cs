using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletTask.Application.Dtos.Common.ResponseModel
{
    public class BaseResponseModel<T> where T : class
    {
        public string Status { get; set; }
        public object Data { get; set; }
        public object UserMessage { get; set; }
        public static BaseResponseModel<T> Success(T data, string status)
        {
            return new BaseResponseModel<T> { Status = status, Data = data};
        }
        
        public static BaseResponseModel<T> Error(string status, object userMessage)
        {
            return new BaseResponseModel<T> { Status = status, UserMessage = userMessage };
        }
    }
}
