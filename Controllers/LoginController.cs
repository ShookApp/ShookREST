using System;
using Microsoft.AspNetCore.Mvc;
using ShookModel.Models;
using ShookREST.Util;

namespace ShookREST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        // Checks if the user with the username and password exist in the database.
        // If it exits, return a LoginPackage with all the needed information. 
        [HttpPost]
        public LoginPackage Login(string username, string password)
        {
            // Maybe save the IP address temporary to make sure that nobody
            // is brute forcing into the system.
            UserRepositoryImpl _userRepository = new UserRepositoryImpl();

            // TODO: Check if the user exists. If not return an empty LoginPackage.

            User _accountUser = _userRepository.GetByUsernameAndPassword(
                username, password);

            if (_accountUser != null)
            {
                return new LoginPackage
                {
                    Success = true,
                    AccountUser = _accountUser,
                    ApiKey = StaticStrings.API_KEY,
                    ValidUntil = DateTime.Now
                };
            }

            return new EmptyLoginPackage();
        }
    }
}
