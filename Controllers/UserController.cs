using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ShookModel.Models;
using ShookREST.Util;
using ShookREST.Util.Authorisation;

namespace ShookREST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly UserRepositoryImpl _userRepositoryImpl = new UserRepositoryImpl();

        [HttpGet]
        [AuthorizationKeyFilter]
        public IEnumerable<User> Get()
        {
            return _userRepositoryImpl.AllUsers();
        }
    }
}
