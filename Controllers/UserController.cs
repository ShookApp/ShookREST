using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ShookModel.Models;
using ShookREST.Utils.Authorization;
using ShookREST.Utils.MongoDB;

namespace ShookREST.Controllers
{
    /// <summary>
    /// Handles all api requests under /user.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        /// <summary>
        /// The <see cref="UserRepositoryImpl"/> instance.
        /// </summary>
        private readonly UserRepositoryImpl _userRepositoryImpl = new UserRepositoryImpl();

        /// <summary>
        /// Returns all users.
        /// </summary>
        /// <returns>All users.</returns>
        [HttpGet]
        [AuthorizationKeyFilter]
        public IEnumerable<User> Get()
        {
            return _userRepositoryImpl.AllUsers();
        }
    }
}
