﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using modelDansUneVue.Models;

// Exercice :
// * Expression régulière pour vérifier l'email
// * Unicité de l'email ( par remote ajax qui renvoi un bool ) pas de BDD nécessaire, juste pour tester
// * champs required nom ( longueur de chaine )
// * champs required Prenom ( longueur de chaine )
// * champs required nom ( longueur de chaine )
// 1) créer le modèle
// 2) créer la vue sur base du modèle
// 


namespace modelDansUneVue.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [OutputCache( VaryByParam = "e" , Duration = 10 )]
        public ActionResult Index( Etudiant e )
        {
            Models.Etudiant ets1 = new Models.Etudiant { Nom = "Dupont", Prenom = "jesaispas", Matricule = "055525896" };
            return View( ets1 );
        }

        // les filtres => []
        [OutputCache(VaryByParam = "test", Duration = 10)] // cache 10 sec
       //     OutputCache Duration = "#ofseconds"
       //Location="Any | Client | Downstream | Server | None | 
       //  ServerAndClient "
       //Shared="True | False"
       //VaryByControl="controlname"
       //VaryByCustom="browser | customstring"
       //VaryByHeader="headers"
       //VaryByParam="parametername" 
       //CacheProfile="cache profile name | ''"
       //NoStore="true | false"
   //SqlDependency="database/table name pair | CommandNotification"
        // SqlDependency permettra de dévalider la cache par rapport aux datas SQL
        // tester l'affichage client avec un Datetime.now.toLongTimeString();
        // [Authorize] // Permet de définir l'accès qu'aux personnes identifiées
        // les accès se retrouvent dans le web.config
        public JsonResult CheckUnicity(string Email) {

            if (Email == "xxx@xxx.xx") {
                return Json( true, JsonRequestBehavior.AllowGet );
            } else {
                return Json( false, JsonRequestBehavior.AllowGet );
            }

        }
    }
}