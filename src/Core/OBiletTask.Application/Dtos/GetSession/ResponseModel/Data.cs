using Newtonsoft.Json;

namespace Task_test.Dtos.GetSession.ResponseModel
{
    public class Data
    {
        [JsonProperty("session-id")]
        public string sessionid { get; set; }

        [JsonProperty("device-id")]
        public string deviceid { get; set; }
    }
}
