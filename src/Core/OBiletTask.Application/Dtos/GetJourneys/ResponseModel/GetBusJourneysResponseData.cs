using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletTask.Application.Dtos.GetJourneys.ResponseModel
{
    public class GetBusJourneysResponseData
    {
        public int id { get; set; }

        [JsonProperty("partner-id")]
        public int partnerid { get; set; }

        [JsonProperty("partner-name")]
        public string partnername { get; set; }

        [JsonProperty("route-id")]
        public int routeid { get; set; }

        [JsonProperty("bus-type")]
        public string bustype { get; set; }

        [JsonProperty("bus-type-name")]
        public string bustypename { get; set; }

        [JsonProperty("total-seats")]
        public int totalseats { get; set; }

        [JsonProperty("available-seats")]
        public int availableseats { get; set; }
        public Journey journey { get; set; }
        public List<Feature> features { get; set; }

        [JsonProperty("origin-location")]
        public string originlocation { get; set; }

        [JsonProperty("destination-location")]
        public string destinationlocation { get; set; }

        [JsonProperty("is-active")]
        public bool isactive { get; set; }

        [JsonProperty("origin-location-id")]
        public int originlocationid { get; set; }

        [JsonProperty("destination-location-id")]
        public int destinationlocationid { get; set; }

        [JsonProperty("is-promoted")]
        public bool ispromoted { get; set; }

        [JsonProperty("cancellation-offset")]
        public int cancellationoffset { get; set; }

        [JsonProperty("has-bus-shuttle")]
        public bool hasbusshuttle { get; set; }

        [JsonProperty("disable-sales-without-gov-id")]
        public bool disablesaleswithoutgovid { get; set; }

        [JsonProperty("display-offset")]
        public string displayoffset { get; set; }

        [JsonProperty("partner-rating")]
        public double? partnerrating { get; set; }

        [JsonProperty("has-dynamic-pricing")]
        public bool hasdynamicpricing { get; set; }

        [JsonProperty("disable-sales-without-hes-code")]
        public bool disablesaleswithouthescode { get; set; }

        [JsonProperty("disable-single-seat-selection")]
        public bool disablesingleseatselection { get; set; }

        [JsonProperty("change-offset")]
        public int changeoffset { get; set; }
        public int rank { get; set; }

        [JsonProperty("display-coupon-code-input")]
        public bool displaycouponcodeinput { get; set; }

        [JsonProperty("disable-sales-without-date-of-birth")]
        public bool disablesaleswithoutdateofbirth { get; set; }

        [JsonProperty("open-offset")]
        public int? openoffset { get; set; }

        [JsonProperty("display-buffer")]
        public object displaybuffer { get; set; }

        [JsonProperty("allow-sales-foreign-passenger")]
        public bool allowsalesforeignpassenger { get; set; }

        [JsonProperty("has-seat-selection")]
        public bool hasseatselection { get; set; }

        [JsonProperty("branded-fares")]
        public List<object> brandedfares { get; set; }

        [JsonProperty("has-gender-selection")]
        public bool hasgenderselection { get; set; }

        [JsonProperty("has-dynamic-cancellation")]
        public bool hasdynamiccancellation { get; set; }

        [JsonProperty("partner-terms-and-conditions")]
        public object partnertermsandconditions { get; set; }

        [JsonProperty("partner-available-alphabets")]
        public string partneravailablealphabets { get; set; }

        [JsonProperty("provider-id")]
        public int providerid { get; set; }

        [JsonProperty("partner-code")]
        public string partnercode { get; set; }

        [JsonProperty("enable-full-journey-display")]
        public bool enablefulljourneydisplay { get; set; }

        [JsonProperty("provider-name")]
        public string providername { get; set; }

        [JsonProperty("enable-all-stops-display")]
        public bool enableallstopsdisplay { get; set; }

        [JsonProperty("is-destination-domestic")]
        public bool isdestinationdomestic { get; set; }

        [JsonProperty("min-len-gov-id")]
        public object minlengovid { get; set; }

        [JsonProperty("max-len-gov-id")]
        public object maxlengovid { get; set; }

        [JsonProperty("require-foreign-gov-id")]
        public bool requireforeigngovid { get; set; }

        [JsonProperty("is-cancellation-info-text")]
        public bool iscancellationinfotext { get; set; }

        [JsonProperty("cancellation-offset-info-text")]
        public object cancellationoffsetinfotext { get; set; }

        [JsonProperty("is-time-zone-not-equal")]
        public bool istimezonenotequal { get; set; }

        [JsonProperty("markup-rate")]
        public double markuprate { get; set; }

        [JsonProperty("is-print-ticket-before-journey")]
        public bool isprintticketbeforejourney { get; set; }

        [JsonProperty("is-extended-journey-detail")]
        public bool isextendedjourneydetail { get; set; }

        [JsonProperty("is-payment-select-gender")]
        public bool ispaymentselectgender { get; set; }

        [JsonProperty("should-turkey-on-the-nationality-list")]
        public bool shouldturkeyonthenationalitylist { get; set; }

        [JsonProperty("markup-fee")]
        public double markupfee { get; set; }

        [JsonProperty("partner-nationality")]
        public object partnernationality { get; set; }

        [JsonProperty("generate-barcode")]
        public bool generatebarcode { get; set; }
    }
}
