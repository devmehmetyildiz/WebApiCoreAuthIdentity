using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StarNoteWebApi.DataAccess;
using StarNoteWebApi.Models;
using StarNoteWebApi.EntitiyDB;
namespace StarNoteWebApi.Controllers
{
    public class HomeController : ApiController
    {
        [Authorize]
        [HttpGet]
        public string Test()
        {
            return "OK";
        }

        [HttpGet]
        public string DBTest()
        {
            bool isok = false;
            using (StarNoteEntity dbContext = new StarNoteEntity())
            {
              isok = dbContext.Database.Exists();
            }
            if (isok)
            {
                return "OK";
            }
            else
            {
                return "False";
            }
          
        }

    }
}
