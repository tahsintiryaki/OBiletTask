using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletTask.Application.Dtos.GetJourneys.ResponseModel
{
    public class Stop
    {
        public int id { get; set; }
        public int? kolayCarLocationId { get; set; }
        public string name { get; set; }
        public string station { get; set; }
        public DateTime? time { get; set; }

        [JsonProperty("is-origin")]
        public bool isorigin { get; set; }

        [JsonProperty("is-destination")]
        public bool isdestination { get; set; }

        [JsonProperty("is-segment-stop")]
        public bool issegmentstop { get; set; }
        public int? index { get; set; }

        [JsonProperty("obilet-station-id")]
        public object obiletstationid { get; set; }
    }
}
