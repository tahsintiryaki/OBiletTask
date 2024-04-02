using FluentValidation;
using OBiletTask.Application.Dtos.GetJourneys.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletTask.Application.Validator.GetBusLocations
{
    public class GetBusJourneysRequestDataValidator: AbstractValidator<GetBusJourneysRequestData>
    {
        /// <summary>
        /// Backend tarafındaki validasyonlarımı Fluent Validation kullanarak yaptım.
        /// </summary>
        public GetBusJourneysRequestDataValidator()
        {
            RuleFor(t => t.originid).NotEmpty().NotNull().WithMessage("OriginId boş geçilemez");
            RuleFor(t => t.destinationid).NotEmpty().NotNull().WithMessage("DestinationId boş geçilemez");
            RuleFor(t => t.departuredate).NotEmpty().NotNull().WithMessage("DepartureDate boş geçilemez");
        }
    }
}
