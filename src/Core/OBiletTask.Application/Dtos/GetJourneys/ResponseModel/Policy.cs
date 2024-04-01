using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletTask.Application.Dtos.GetJourneys.ResponseModel
{
    public class Policy
    {
        [JsonProperty("max-seats")]
        public object maxseats { get; set; }

        [JsonProperty("max-single")]
        public int? maxsingle { get; set; }

        [JsonProperty("max-single-males")]
        public int? maxsinglemales { get; set; }

        [JsonProperty("max-single-females")]
        public int? maxsinglefemales { get; set; }

        [JsonProperty("mixed-genders")]
        public bool mixedgenders { get; set; }

        [JsonProperty("gov-id")]
        public bool govid { get; set; }
        public bool lht { get; set; }
    }
}
