using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletTask.Application.Dtos.GetJourneys.RequestModel
{
    public class GetBusJourneysRequestData
    {
        [JsonProperty("origin-id")]
        public int originid { get; set; }

        [JsonProperty("destination-id")]
        public int destinationid { get; set; }

        [JsonProperty("departure-date")]
        public string departuredate { get; set; }
    }
}
