using System;
using Microsoft.AspNetCore.Mvc;
using ShookModel.Models;
using ShookREST.Utils;
using ShookREST.Utils.MongoDB;

namespace ShookREST.Controllers
{
    /// <summary>
    /// Handles all api requests under /login and is used to login.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        // TODO: Add brute force prevention.
        
        /// <summary>
        /// The <see cref="UserRepositoryImpl"/> that is used to search the user in the database.
        /// </summary>
        private readonly UserRepositoryImpl _userRepository = new UserRepositoryImpl();
        
        /// <summary>
        /// Checks if the user with the username and password exist in the database.
        /// If it exits, return a LoginPackage with all the needed information. 
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns></returns>
        [HttpPost]
        public LoginPackage Login(string username, string password)
        {

            var accountUser = _userRepository.GetByUsernameAndPassword(
                username, password);

            if (accountUser != null)
            {
                return new LoginPackage
                {
                    Success = true,
                    AccountUser = accountUser,
                    ApiKey = StaticStrings.ApiKey,
                    ValidUntil = DateTime.Now
                };
            }

            return new EmptyLoginPackage();
        }
    }
}
