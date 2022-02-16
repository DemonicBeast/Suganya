using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Payroll.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Payroll.API.ExceptionHandling
{
    public static class GlobalExceptionFilter
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
                       await context.Response.WriteAsync(new ErrorDetails()
                       {
                           StatusCode = context.Response.StatusCode,
                           ErrorMessgae = "Internal Server Error !!! Please contact your Admin"
                       }.ToString());
                   }
               });

           });
        }
    }
}
