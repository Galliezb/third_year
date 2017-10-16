using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cookie.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCookie() {

            // request pour recevoir les cookies
            string str = Request.Cookies["test"].Value;

            // response pour envoyer des cookies depuis le serveur
            Response.Cookies["test2"].Value = "cookie du controlleur";
            Response.Cookies["test2"].Expires = DateTime.Now.AddDays(5);

            return View("index.cshtml");
        }
    }
}