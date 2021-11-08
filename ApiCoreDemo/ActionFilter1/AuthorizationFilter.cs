using ApiCoreDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Controllers;



namespace ApiCoreDemo.ActionFilter1
{
    public class AuthorizationFilter : Attribute,  IAuthorizationFilter
    {
        private TokenManager _tokenManager = new TokenManager();

        //public class AuthorizationFilter : IAuthorizationFilter
        //{
        //    public void OnAuthorization(AuthorizationFilterContext context)
        //    {
        //        //可在此進行權限檢查
        //        //context.HttpContext.Response.WriteAsync($"進入Authorization Filter。 \r\n");
        //    }
        //}

        public void OnAuthorization(AuthorizationFilterContext actionContext)
        {
            //var secret = "Hello";
            if (actionContext.HttpContext.Request == null)
            {
                setErrorResponse(actionContext, "驗證錯誤");
            }
            else
            {
                try
                {
                    var authorization = actionContext.HttpContext.Request.Headers["Authorization"];

                    var user = _tokenManager.GetUser(authorization);
                    if (user == null)
                    {
                        setErrorResponse(actionContext, "帳號已過期");
                    }
                }
                catch (Exception ex)
                {
                    setErrorResponse(actionContext, "請輸入Authorization");
                }
            }
            //base.OnActionExecuting(actionContext);
        }
        private static void setErrorResponse(AuthorizationFilterContext actionContext, string message)
        {
          
            actionContext.Result = new BadRequestObjectResult(message);
            //var response = actionContext.HttpContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, message);
            //actionContext.HttpContext.Response = response;
        }
    }
}
