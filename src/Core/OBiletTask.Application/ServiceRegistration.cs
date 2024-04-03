using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using OBiletTask.Application.Dtos.GetJourneys.RequestModel;
using OBiletTask.Application.Validator.GetBusLocations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace OBiletTask.Application
{
    /// <summary>
    ///Program.cs'in daha okunaklı olması için her katmanda geliştirilen kodların ihtiyaç duyduğu konfigürasyonları static bir class ile yönettim. 
    /// </summary>
    public static class ServiceRegistration
    {
      
        public static void AddApplicationRegistration(this IServiceCollection services)
        {
            var assm = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assm);
 
            services.AddScoped<IValidator<GetBusJourneysRequestData>, GetBusJourneysRequestDataValidator>();





        }
    }
}
