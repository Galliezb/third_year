using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ajax_Jquery.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Traitement(string identite) {
            return View( "index" );
        }
        //public ActionResult Traitement() {
        //    return View( "index" );
        //}
    }
}