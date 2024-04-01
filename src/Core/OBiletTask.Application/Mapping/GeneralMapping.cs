
using AutoMapper;
using OBiletTask.Application.Dtos.GetJourneys.ResponseModel;
using OBiletTask.Application.ViewModel.GetJourneys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OBiletTask.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            //CreateMap<GetJourneysViewModel, GetBusJourneysResponseData>()
            //     .ForPath(dest => dest.journey.departure, act => act.MapFrom(src => src.Departure))
            //     .ForPath(dest => dest.journey.arrival, act => act.MapFrom(src => src.Arrival))
            //     .ForPath(dest => dest.journey.currency, act => act.MapFrom(src => src.Currency))
            //     .ForPath(dest => dest.journey.origin, act => act.MapFrom(src => src.Origin))
            //     .ForPath(dest => dest.journey.destination, act => act.MapFrom(src => src.Destination))
            //     .ForPath(dest => dest.journey.originalprice, act => act.MapFrom(src => src.Price));

            CreateMap<GetBusJourneysResponseData,GetJourneysViewModel > ()
                 .ForPath(dest => dest.Departure, act => act.MapFrom(src => src.journey.departure))
                 .ForPath(dest => dest.Arrival, act => act.MapFrom(src => src.journey.arrival))
                 .ForPath(dest => dest.Currency, act => act.MapFrom(src => src.journey.currency))
                 .ForPath(dest => dest.Origin, act => act.MapFrom(src => src.journey.origin))
                 .ForPath(dest => dest.Destination, act => act.MapFrom(src => src.journey.destination))
                 .ForPath(dest => dest.Price, act => act.MapFrom(src => src.journey.originalprice));

        }
    }
}
