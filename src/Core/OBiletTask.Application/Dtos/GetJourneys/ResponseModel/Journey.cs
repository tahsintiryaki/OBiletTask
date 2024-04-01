using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletTask.Application.Dtos.GetJourneys.ResponseModel
{
    public class Journey
    {
        public string kind { get; set; }
        public string code { get; set; }
        public List<Stop> stops { get; set; }
        public string origin { get; set; }
        public string destination { get; set; }
        public DateTime departure { get; set; }
        public DateTime arrival { get; set; }
        public string currency { get; set; }
        public string duration { get; set; }

        [JsonProperty("original-price")]
        public double originalprice { get; set; }

        [JsonProperty("internet-price")]
        public double internetprice { get; set; }

        [JsonProperty("provider-internet-price")]
        public double? providerinternetprice { get; set; }
        public object booking { get; set; }

        [JsonProperty("bus-name")]
        public string busname { get; set; }
        public Policy policy { get; set; }
        public List<string> features { get; set; }
        public string description { get; set; }
        public object available { get; set; }

        [JsonProperty("partner-provider-code")]
        public object partnerprovidercode { get; set; }

        [JsonProperty("peron-no")]
        public object peronno { get; set; }

        [JsonProperty("partner-provider-id")]
        public object partnerproviderid { get; set; }

        [JsonProperty("is-segmented")]
        public bool issegmented { get; set; }

        [JsonProperty("partner-name")]
        public object partnername { get; set; }

        [JsonProperty("provider-code")]
        public object providercode { get; set; }

        [JsonProperty("sorting-price")]
        public double sortingprice { get; set; }
    }
}
