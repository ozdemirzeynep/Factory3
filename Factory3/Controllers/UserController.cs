using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Factory3.Factories;
using Factory3.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Factory3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        DataContextFactory<UserService> dataContextFactory = new DataContextFactory<UserService>();
        public IActionResult GetUsers()
        {
            
            dataContextFactory.Instance.Insert(new Models.User()
            {
                CreateDate =DateTime.UtcNow,
                Name ="zzz"
            });

            IEnumerable<Models.User> users = dataContextFactory.Instance.List().ToList();

            return new JsonResult(users);
        }


        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            
            var user = dataContextFactory.Instance.Get(id);

            return new JsonResult(user);
        }

        [HttpPost]
        public IActionResult PostUser(Models.User user)
        {
            dataContextFactory.Instance.Insert(user);
            return new JsonResult(user);
        }
    }
}