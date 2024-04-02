
using AutoMapper;
using OBiletTask.Application.Dtos.GetBusLocations;
using OBiletTask.Application.Dtos.GetBusLocations.ResponseModel;
using OBiletTask.Application.Dtos.GetJourneys.ResponseModel;
using OBiletTask.Application.ViewModel.GeetSession;
using OBiletTask.Application.ViewModel.GetAllBusLocations;
using OBiletTask.Application.ViewModel.GetJourneys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_test.Dtos.GetSession.ResponseModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OBiletTask.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {

            CreateMap<GetBusJourneysResponseData, GetJourneysViewModel>()
                 .ForPath(dest => dest.Departure, act => act.MapFrom(src => src.journey.departure))
                 .ForPath(dest => dest.Arrival, act => act.MapFrom(src => src.journey.arrival))
                 .ForPath(dest => dest.Currency, act => act.MapFrom(src => src.journey.currency))
                 .ForPath(dest => dest.Origin, act => act.MapFrom(src => src.journey.origin))
                 .ForPath(dest => dest.Destination, act => act.MapFrom(src => src.journey.destination))
                 .ForPath(dest => dest.Price, act => act.MapFrom(src => src.journey.originalprice));

            CreateMap<GetBusLocationData, GetBusLocationViewModel>()
              .ForMember(dest => dest.Id, act => act.MapFrom(src => src.id))
              .ForMember(dest => dest.Name, act => act.MapFrom(src => src.name));

            CreateMap<Data, GetSessionViewModel>()
             .ForMember(dest => dest.sessionid, act => act.MapFrom(src => src.sessionid))
             .ForMember(dest => dest.deviceid, act => act.MapFrom(src => src.deviceid));

        }
    }
}
