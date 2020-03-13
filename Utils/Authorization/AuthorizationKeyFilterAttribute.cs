using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ShookREST.Util.Authorization
{
    public class AuthorizationKeyFilterAttribute : Attribute, IAuthorizationFilter
    {
        // Check if the delivered API key is valid.
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var apiKey = context.HttpContext.Request.Headers["Authorization"];

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
