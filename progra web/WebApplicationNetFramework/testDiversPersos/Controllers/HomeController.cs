using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testDiversPersos.Models;

namespace testDiversPersos.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        //public JsonResult Test () {

        //    Users u = new Users { ID = 0; };

        //    return Json(  );

        //}
    }
}