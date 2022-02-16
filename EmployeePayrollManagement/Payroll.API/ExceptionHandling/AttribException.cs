using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Payroll.API.ExceptionHandling
{
    public class AttribException:ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            string ErrorMessage = "";
            string Source = "";
            string ExceptionType = "";
            if(context.Exception.InnerException==null)
            {
                ErrorMessage = context.Exception.Message;
                Source = context.Exception.Source;
                ExceptionType = context.Exception.GetType().FullName;
            }
            else
            {
                ErrorMessage = context.Exception.InnerException.Message;
                Source = context.Exception.InnerException.Source;
                ExceptionType = context.Exception.InnerException.GetType().FullName;
            }
            var Result = new ObjectResult(new
            {
                ErrorMessage,
                Source,
                ExceptionType
            })
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
            context.Result = Result;
        }
    }
}
