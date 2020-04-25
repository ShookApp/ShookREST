using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ShookREST.Utils.Authorization
{
    /// <summary>
    /// All api requests (GET, POST, ...) that are annotated with this attribute have to provide the api key in the
    /// request header. The key is "Authorization" and the value should be the valid api key.
    /// </summary>
    public class AuthorizationKeyFilterAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var apiKey = context.HttpContext.Request.Headers["Authorization"];

            if (apiKey.Any())
            {
                if (!apiKey.ToString().Equals(StaticStrings.ApiKey))
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
