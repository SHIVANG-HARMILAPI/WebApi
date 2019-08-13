using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet]
        [Route("{value}")]
        public ActionResult<string> Get(string value)
        {
            string response="";
            if (value == "Hey")
                response = "Hi";
            else
                response = "Hey";
            return response;
        }
        [HttpGet]
        //[Route("{value}")]
        public string GetHi(string value)
        {
            return "Hey";
        }
       
     
    }
}
