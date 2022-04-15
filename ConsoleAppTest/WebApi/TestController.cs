using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ConsoleAppTest.WebApi
{
    public class TestController : ApiController
    {
        [HttpGet]
        public IList<User> GetUser()
        {
            var user = new User { Id = 99, UserName = "Michael" };
            var list = new List<User>();
            list.Add(user);
            list.Add(user);
            return list;
        }

        [HttpGet]
        public User GetById(int id)
        {
            var user = new User { Id = id, UserName = "Michael" };
            return user;
        }
    }

    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public DateTime CreateTime { get { return DateTime.Now; } }
    }
}
