using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using lesFiltres.Models;

namespace lesFiltres.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        // Penser à compléter le web.config correctement pour créer la rediction vers la page Login
        // pour ceux qui ne sont pas connectés
        public ActionResult Index()
        {
            return View();
        }

        // [Authorize] => pour les clients connectés ( WebForm, auth windows, hotmail  )
        // webform => par une page web
        // auth window : par une fenêtre système
        // [AllowAnonymous] => pour le formulaire d'identification par exemple
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(User tempUser, string ReturnUrl) {
            //WPFTutorialEntities1DataContext WPFUsers = new WPFTutorialEntities1DataContext();
            //if (ModelState.IsValid) {

            //    int result = WPFUsers.CheckIfThisUserExist( tempUser.UserName, tempUser.Passwd ).FirstOrDefault() ?? 0;
            //    if (result == 1) {
            //        Session["User"] = tempUser;
            //        FormsAuthentication.SetAuthCookie( tempUser.UserName, false );
            //        if (ReturnUrl != null) return Redirect( ReturnUrl );
            //        else return Redirect( FormsAuthentication.DefaultUrl );
            //    } else {
            //        ModelState.AddModelError( "", "Log In Failed" );
            //    }
            //} else {
            //    ModelState.AddModelError( "", "Log In Failed" );
            //}

            // dans le cas ou on va directement sur la page de login et que ReturnUrl est null
            if (ReturnUrl == null) {
                ReturnUrl = FormsAuthentication.DefaultUrl;
            }
            ViewBag.ReturnUrl = ReturnUrl;

            return View();
        }

        [Authorize]
        public ActionResult PrivateEnv() {
            return View( "vu" );
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login(string urlToReturn) {
            return View();
        }

    }
}