using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ajax_Jquery.Models;

namespace ajax_Jquery.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Traitement(MesDatas idt ) {

            ReturnData data = new ReturnData { Propriete1 = idt.Identite, Propriete2 = idt.Prenom };
            return Json( data );

        }
        //public ActionResult Traitement() {
        //    return View( "index" );
        //}
    }
}