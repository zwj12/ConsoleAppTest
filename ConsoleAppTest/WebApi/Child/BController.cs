using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ConsoleAppTest.WebApi.Child
{
    public class BController:ApiController
    {
        [HttpGet]
        public IList<User> GetUser()
        {
            var user = new User { Id = 99, UserName = "Michael" };
            var list = new List<User>();
            list.Add(user);
            list.Add(user);
            list.Add(user);
            return list;
        }
    }
}
