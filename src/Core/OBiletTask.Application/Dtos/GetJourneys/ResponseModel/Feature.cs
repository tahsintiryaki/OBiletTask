using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletTask.Application.Dtos.GetJourneys.ResponseModel
{
    public class Feature
    {
        public int id { get; set; }
        public int? priority { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        [JsonProperty("is-promoted")]
        public bool ispromoted { get; set; }

        [JsonProperty("back-color")]
        public string backcolor { get; set; }

        [JsonProperty("fore-color")]
        public string forecolor { get; set; }

        [JsonProperty("partner-notes")]
        public object partnernotes { get; set; }
    }
}
