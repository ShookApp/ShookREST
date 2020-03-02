using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ShookREST.Models;
using ShookREST.Util;

namespace ShookREST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly UserRepositoryImpl _userRepositoryImpl = new UserRepositoryImpl();

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userRepositoryImpl.AllUsers();
        }
    }
}
