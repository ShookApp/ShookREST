using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ShookREST.Util.Authorisation
{
    public class AuthorizationKeyFilterAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var apiKey = context.HttpContext.Request.Headers["Authorization"];
            Console.Write(apiKey.ToString());

            if (apiKey.Any())
            {
                if (!apiKey.ToString().Equals(StaticStrings.API_KEY))
                {
                    context.Result = new UnauthorizedResult();
                }
            }
            else
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
