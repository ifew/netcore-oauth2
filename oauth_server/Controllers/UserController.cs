using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{

    [Route("api/[controller]")]
    [Authorize]
    public class UserController : Controller
    {
        [HttpGet]
        public JsonResult Get()
        {
            return Json("Hi, I'm Few");
        }
    }
}