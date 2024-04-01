using Newtonsoft.Json;

namespace Task_test.Dtos.GetSession.ResponseModel
{
    public class GetSessionResponseModel
    {

        public string Status { get; set; }
        public Data Data { get; set; }
        public object Message { get; set; }

        [JsonProperty("user-message")]
        public object usermessage { get; set; }

        [JsonProperty("api-request-id")]
        public object apirequestid { get; set; }
        public object controller { get; set; }
    }
}
