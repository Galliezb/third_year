using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestSharp;
using RestSharp.Deserializers;
using UserOfWebApi.Models;

namespace UserOfWebApi.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        // Nugget installé RestCsharp pour faciliter l'encapsulationd es method d'accès a l'api
        // on peut aussi jouer avec System.net.http
        [Authorize]
        public ActionResult Index()
        {
            var id = 1;
            var client = new RestClient( "http://localhost:53858/api/" );
            // récupère tous les utilisateurs , sauf si on ajoute un id
            var request = new RestRequest( "Home/GetListOfUser", Method.GET );
            //request.AddParameter( "id", "1" ); // adds to POST or URL querystring based on Method
            request.AddHeader( "cache-control", "no-cache" );
            IRestResponse response = client.Execute( request );
            JsonDeserializer deserial = new JsonDeserializer();
            // vu à la dev day
            // using Newtonsoft.Json$ et JsonConvert.DeserializeObject();
            // Users class linq
            List<Users> listUsers = deserial.Deserialize<List<Users>>( response );
            //request.AddUrlSegment( "id", "123" ); // replaces matching token in request.Resource

            return View( listUsers );
        }

        [AllowAnonymous]
        public ActionResult Login() {

            return View("Login");

        }

        // possibilité de modifier les routes avec une nouvelle route et en utilisant :
        //[Route("authenticate")]
        // il faudra passer par une requête async Task car la requete Http POST n'existe qu'en asynchrone
        //
        // puis bosser avec des await pour attendre la réponse. Une fois
        // Clint.defaultRequestHeaders.Accept.clear() => ?


        [HttpPost]
        [AllowAnonymous]
        public ActionResult IdentificationClient() {

            return View( "Login" );

        }
    }
}