using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCoreDemo.ActionFilter1
{
    public static  class FilterExtensions
    {
        public static void AddMessageFilter(this MvcOptions options)
        {
            options.Filters.Add<AuthorizationFilter>();
        }
    }
}
