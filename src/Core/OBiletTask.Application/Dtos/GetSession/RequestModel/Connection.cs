using Newtonsoft.Json;

namespace Task_test.Dtos.GetSession.RequestModel
{
    public class Connection
    {

        [JsonProperty("ip-address")]
        public string ipaddress { get; set; }
        public string port { get; set; }
    }
}
