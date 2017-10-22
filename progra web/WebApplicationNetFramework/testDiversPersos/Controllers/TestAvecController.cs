using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sql_Connection.Controllers
{
    public class TestAvecController : Controller
    {
        // GET: TestAvec
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult TestController () {

            return Json( "Contact établie, ça t'en bouche un coin hein ?" );
        }
    }
}