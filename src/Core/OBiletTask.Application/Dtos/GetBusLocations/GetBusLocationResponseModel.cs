using Newtonsoft.Json;
using OBiletTask.Application.Dtos.GetBusLocations.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletTask.Application.Dtos.GetBusLocations
{
    public  class GetBusLocationResponseModel
    {
        public string status { get; set; }
        public List<GetBusLocationData> data { get; set; }
        public object message { get; set; }

        [JsonProperty("user-message")]
        public object usermessage { get; set; }

        [JsonProperty("api-request-id")]
        public object apirequestid { get; set; }
        public string controller { get; set; }

        [JsonProperty("client-request-id")]
        public object clientrequestid { get; set; }

        [JsonProperty("web-correlation-id")]
        public object webcorrelationid { get; set; }

        [JsonProperty("correlation-id")]
        public string correlationid { get; set; }
        public object parameters { get; set; }
    }
}
