using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace ConsoleAppTest.WebApi
{
    public class HttpController
    {
        public void InitController()
        {
            var config = new HttpSelfHostConfiguration("http://localhost:3333");
            config.Routes.MapHttpRoute("default", "api/{controller}/{id}", new { id = RouteParameter.Optional });
           // config.Routes.MapHttpRoute(name: "test-api", routeTemplate: "api/{controller}", defaults: new { controller = "A" });


            var server = new HttpSelfHostServer(config);
            server.OpenAsync().Wait();
            Console.WriteLine("Server is opened");
            
        }
    }
}
