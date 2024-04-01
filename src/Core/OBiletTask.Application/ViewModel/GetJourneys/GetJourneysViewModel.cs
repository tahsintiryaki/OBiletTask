using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletTask.Application.ViewModel.GetJourneys
{
    public class GetJourneysViewModel
    {
        public string Origin { get; set; }    
        public string Destination { get; set; }    
        public string Currency { get; set; }    
        public double Price { get; set; }    
        public DateTime Departure { get; set; }    
        public DateTime Arrival { get; set; }    
    }
}
