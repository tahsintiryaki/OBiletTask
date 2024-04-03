using Microsoft.Extensions.DependencyInjection;
using OBiletTask.Application.Interface.Repositories;
using OBiletTask.Application.Interface.Services;
using OBiletTask.Infrastructure.ExceptionHandling;
using OBiletTask.Infrastructure.Repositories;
using OBiletTask.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletTask.Infrastructure
{
    /// <summary>
    ///Program.cs'in daha okunaklı olması için her katmanda geliştirilen kodların ihtiyaç duyduğu konfigürasyonları static bir class ile yönettim. 
    /// </summary>
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            #region GetSession
            serviceCollection.AddTransient<IApiTransactionRepository, ApiTransactionRepository>();
            serviceCollection.AddTransient<IApiTransactionService, ApiTransactionService>();
            #endregion
            //Global Hata Yönetimi
            serviceCollection.AddControllers(options => options.Filters.Add(typeof(ExceptionFilter)));
        }
    }
}
