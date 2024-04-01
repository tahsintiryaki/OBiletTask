using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletTask.Application.Dtos.Common.RequestModel
{
    public class CommonRequestModel<T> 
    {
        public T Data { get; set; }

        [JsonProperty("device-session")]
        public DeviceSession DeviceSession { get; set; }
        public DateTime Date { get; set; }
        public string Language { get; set; }


    }
}
