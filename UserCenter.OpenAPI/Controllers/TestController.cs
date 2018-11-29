using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using UserCenter.IServices;

namespace UserCenter.OpenAPI.Controllers
{
    public class TestController : ApiController
    {
        public IUserService UserService { get; set; }


        public async Task<string> OK(string name, string age)
        {
            return $"name={name},age={age}";
        }
    }
}
