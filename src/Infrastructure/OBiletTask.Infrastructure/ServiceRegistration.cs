using Microsoft.Extensions.DependencyInjection;
using OBiletTask.Application.Interface.Services;
using OBiletTask.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletTask.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            #region GetSession
            //serviceCollection.AddScoped<IApiTransactionRepository, ApiTransactionRepository>();
            serviceCollection.AddScoped<IApiTransactionService, ApiTransactionService>();
            #endregion
        }
    }
}
