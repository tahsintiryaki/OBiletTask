using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletTask.Infrastructure.ExceptionHandling
{
    /// <summary>
    ///Fırlatılan hatalar ExceptionFilter tarafından yakalanıp, Ilogger ile logfile.txt ye yazılmaktadır.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public async override Task OnExceptionAsync(ExceptionContext context)
        {
            _logger.LogError(context.Exception.Message);
            
        }
    }
}
