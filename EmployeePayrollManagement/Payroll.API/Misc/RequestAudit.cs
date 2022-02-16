using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Payroll.BL.Models;
using Payroll.BL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll.API.Misc
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RequestAudit
    {
        private readonly RequestDelegate _next;

        public RequestAudit(RequestDelegate next)
        {
            _next = next;
        }

        public  Task Invoke(HttpContext httpContext, IRequestAuditCommandRepository requestAuditCommand)
        {

            var currentController = httpContext.Request.RouteValues.Count > 0 ? httpContext.Request.RouteValues["controller"].ToString() : "";
            var currentAction = httpContext.Request.RouteValues.Count > 0 ? httpContext.Request.RouteValues["controller"].ToString() : "";
            var Request = httpContext.Request;
            AuditRequest auditRequest = new AuditRequest()
            {
                RequestedURL = Request.GetDisplayUrl(),
                RequestedActionMethod = currentAction,
                RequestedController = currentController,
                RequestedDateTime = DateTime.Now
            };
              requestAuditCommand.AddNewAudit(auditRequest);

            return  _next.Invoke(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RequestAuditExtensions
    {
        public static IApplicationBuilder UseRequestAudit(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestAudit>();
        }
    }
}
