using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace OBiletTask.Application
{
    public static class ServiceRegistration
    {
        //We write to define AutoMapper and MediatR and call them in Program.cs in UI project.
        public static void AddApplicationRegistration(this IServiceCollection services)
        {
            var assm = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(assm);

           



        }
    }
}
