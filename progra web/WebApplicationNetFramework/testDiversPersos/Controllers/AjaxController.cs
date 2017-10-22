using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testDiversPersos.Models;

namespace testDiversPersos.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult AddUser(Users u ) {

            string messageDeRetour = "Utilisateur ajoutée à la BDD";

            return Json(messageDeRetour);
        }


        //////////////////////////////////// AMBIGUITE ///////////////////////////////////
        //public JsonResult AddUser ( int ID, string Name, string Firstname, int Solde ) {

        //    string messageDeRetour = "Utilisateur ajoutée à la BDD";

        //    return Json( messageDeRetour );
        //}



    }
}