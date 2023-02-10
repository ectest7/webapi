using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Log
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _logger;

        public LoggingMiddleware(RequestDelegate next, ILoggerManager logger)
        {
            this._next = next;
            this._logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                
                await _next(context);
            }
            finally
            {
                _logger.LogInfo($"Request {context.Request?.Method} {context.Request?.Path.Value}");
            }
        }


    }
}