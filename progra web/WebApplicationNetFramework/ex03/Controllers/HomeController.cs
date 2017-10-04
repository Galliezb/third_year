using ex03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ex03.Controllers
{
    public class HomeController : Controller
    {
        //GET: Home
        //public ActionResult Index() {
        //    return View();
        //}

        public ActionResult Index(TraiteGet tg) {
            if (tg.pseudo == null) {
                tg.pseudo = "defaultLogin";
                tg.passwd = "defaultPasswd";
                tg.bornDate = DateTime.Now.ToString( "dd-MM-yyyy" );
            }
            return View(tg);
        }

        // ambiguite car le stype string est une référence et peut donc être null
        //public ActionResult Index(string pseudo, string passwd, string bornDate) {
        //    //ViewBag.test1 = pseudo;
        //    //ViewBag.test2 = passwd;
        //    //ViewBag.test3 = bornDate;
        //    return View();
        //}

        public ActionResult GetSubmit ( string pseudo , string passwd , string bornDate ) {
            ViewBag.test1 = pseudo;
            ViewBag.test2 = passwd;
            ViewBag.test3 = bornDate;
            return View( "indexIdentifie" );
        }
    }
}