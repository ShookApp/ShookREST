using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShookREST.Models;
using ShookREST.Util;

namespace ShookREST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        // Get request.
        public Task<List<User>> Get()
        {
            DBUtil dbUtil = new DBUtil();

            Task <List<User>> test = dbUtil.ListAllUsers();

            return test;
        }
    }
}
