using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace StarNoteWebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
       [Route("Test")]
        public string Test()
        {
            return "OK";
        }
        [Route("DBTest")]
        [HttpGet]
        public string DBTest()
        {
            return "OK";
        }

    }
}
