using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi2.Models;

namespace WebApi2.Controllers {
    public class HomeController : ApiController {
        // TODO
        // identification de l'utilisateur via requete webApi
        // redirection sur page de login et renvoi vers la page demandée
        // le tout en https ?

        // en ajoutant {action}/ dans la route avant l'id, on arrête d'appeler par défaut des méthodes
        // GET et POST basé sur l'action du header. Cela nous permet d'avoir nos propre méthodes à appeler
        // auxquels on précise si la requête sera GET ou POST avec les filtres
        // car plein le cul d'appeler api/home/1, maintenant ce sera api/home/GetUserInfo/1 qui est quand même
        // beaucoup plus parlant
        // bizarrement sans le httpGet en filtre, rien n'est accessible. Bizarre, à tester.

        // une fois le token d'authentification obtenu avec le tout, il faudra l'envoyer vers la web api
        // créer une session qui permet de se souvenir de ceci
        // modifier la route 

        // il est possible d'ajouter des contraintes dans les envois d'infomation via le webapiconfig
        // genre le token envoyé doit être sous forme de GUID => via expression régulière
        // https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/controllers-and-routing/creating-a-custom-route-constraint-cs
        //Config.Routes.MapHttpRoute(
        //    name:"defaultApi",
        //    routeTemplate:"api/{Controller}/{token}/id",
        //    defaults : new { id = RouteParameter.Optional },
        //    constraint : {}
        //    );
        // pour cela il faudra passer par une classe et l'interface IrouteConstraint
        // on appelera ensuite la méthode dans les paramètres de la route
        // cette méthode renvoyant un bool, elle permettra de savoir si les conditions requises sont 
        // remplis pour répondre à cette requête
        // contraint : new  { token = @"[a-f0-9-]+"}
        // ou



        [HttpGet]
        // GET: api/Home
        // http://www.tutorialsteacher.com/webapi/create-web-api-project
        public IEnumerable<GetUserListResult> GetListOfUser() {
            //return new string[] { "value1", "value2" };
            toUserDataContext tud = new toUserDataContext();
            var maListeUser = tud.GetUserList().ToList();
            return maListeUser;
        }

        // GET: api/Home/5
        [HttpGet]
        public GetAllFromUserIdResult GetUserInfo(int id) {

            toUserDataContext tud = new toUserDataContext();
            var maListeUser = tud.GetAllFromUserId( id ).FirstOrDefault<GetAllFromUserIdResult>();
            return maListeUser;

        }

        //// POST: api/Home
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Home/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Home/5
        //public void Delete(int id)
        //{
        //}
    }
}
