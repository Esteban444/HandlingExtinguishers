using HandlingExtinguishers.Core.Exceptions;
using HandlingExtinguishers.Core.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HandlingExtinguishers.Infraestructure.Middleware
{
    public class MiddlewareException( RequestDelegate next, ILogger<MiddlewareException> logger )
    {
        private readonly RequestDelegate requestDelegate = next;
        private readonly ILogger<MiddlewareException> logger = logger;

        public async Task InvokeAsync( HttpContext context )
        {
            try
            {
                await requestDelegate( context );
            }
            catch ( Exception ex )
            {
                await HandlingExcepcionAsync( context, ex, logger );
            }
        }

        public async Task HandlingExcepcionAsync( HttpContext context, Exception exception, ILogger<MiddlewareException> logger )
        {
            object errores = new();

            switch ( exception )
            {
                case HandlingExceptions ex:
                    logger.LogError( ex, CommonConstants.ErrorHandling );
                    errores = new { 
                        StatusCode = context.Response.StatusCode,
                        Message = ex.Message
                    };
                    break;

                case Exception ex:
                    logger.LogError( exception, CommonConstants.ServerError);
                    errores = new { 
                        StatusCode = context.Response.StatusCode,
                        Message = string.IsNullOrWhiteSpace(ex.Message) ? CommonConstants.ErrorMessage : ex.Message 
                    };
                    break;

                default:
                    logger.LogError( exception, CommonConstants.UnhandledException );
                    errores = new {
                        StatusCode = context.Response.StatusCode,
                        Message = exception.Message
                    };
                    break;
            }

            context.Response.ContentType = CommonConstants.ContentType;

            if ( errores is not null )
            {
                var result = JsonConvert.SerializeObject( new { errores } );
                await context.Response.WriteAsync( result );
            }
        }
    }
}