using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using OnlineShopping.Data.Models;
using Serilog;
using System.Net;

namespace OnlineShoppingWebAPI.Extensions
{
    /// <summary>
    /// Handle exception from one location
    /// </summary>
    public static class ExceptionMiddlewareExtensions
    {        
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {            
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        Log.Error($"Something went wrong: {contextFeature.Error}");

                        await context.Response.WriteAsync(new ErrorDetails()
                        {

                            StatusCode = context.Response.StatusCode,
                            ErrorDescription = "Internal Server Error.",
                            Data = null
                        }.ToString()); ;
                    }
                });
            });
        }
    }
}