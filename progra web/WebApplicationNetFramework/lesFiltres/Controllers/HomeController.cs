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

        // sera gérer par le GetRoleForUsers
        //pour Web.config => https://msdn.microsoft.com/fr-fr/library/system.web.security.roles(v=vs.110).aspx
        [MyAuthorize( Roles = "admin" )]
        //[MyAuthorize(Users ="toto3"]
        // pour l'autorisation des plusieurs personnes
        //[Authorize(Users ="toto1,toto2,toto3")]
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
            WPFTutorialEntities1DataContext WPFUsers = new WPFTutorialEntities1DataContext();
            if (ModelState.IsValid) {

                int result = WPFUsers.CheckIfThisUserExist( tempUser.UserName, tempUser.Passwd ).FirstOrDefault().Column1 ?? 0;
                if (result == 1) {
                    Session["User"] = tempUser;
                    FormsAuthentication.SetAuthCookie( tempUser.UserName, false );
                    if (ReturnUrl != null) return Redirect( ReturnUrl );
                    else return Redirect( FormsAuthentication.DefaultUrl );
                } else {
                    ModelState.AddModelError( "", "Log In Failed" );
                }
            } else {
                ModelState.AddModelError( "", "Log In Failed" );
            }

            // dans le cas ou on va directement sur la page de login et que ReturnUrl est null
            if (ReturnUrl == null) {
                ReturnUrl = FormsAuthentication.DefaultUrl;
            }
            ViewBag.ReturnUrl = ReturnUrl;

            return View();
        }

        // permet l'authentification depuis le fichier web.config pour la vérification des users / mdp
        // ici on fonctionne avec les provider et le LINQ et les procédure stockées
        [AllowAnonymous]
        public ActionResult Login2(string ReturnUrl, User tempUser = null) {


            // il faudra définir le provider dans le web.config
            // avec quel provider nous travaillons
            // https://msdn.microsoft.com/en-us/library/6e9y4s5t.aspx

            if ( Membership.ValidateUser( tempUser.UserName, tempUser.Passwd)) {
                return View( "vu" );
            } else {
                return View( "Login" );
            }


            // ICI C EST POUR LES VERIF AVEC LES FICHIER WEBCONFIG
            //if ( FormsAuthentication.Authenticate( tempUser.UserName, tempUser.Passwd )) {
            //    FormsAuthentication.SetAuthCookie( tempUser.UserName, false );
            //    // permet de virer le cookie d'authentification
            //    //FormsAuthentication.SignOut();
            //}

            

        }

        //Permet de généré une erreur qui renverrait par la page Error.cshtml plutôt qu'une page par défaut.
        //[HandleError(View = "Error")]


        


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