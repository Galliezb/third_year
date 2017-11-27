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
        public ActionResult Index()
        {
            var id = 1;
            var client = new RestClient( "http://localhost:53858/api/" );
            var request = new RestRequest( "Home/{id}", Method.GET );
            //request.AddParameter( "id", "1" ); // adds to POST or URL querystring based on Method
            request.AddHeader( "cache-control", "no-cache" );
            IRestResponse response = client.Execute( request );
            JsonDeserializer deserial = new JsonDeserializer();
            // Users class linq
            List<Users> listUsers = deserial.Deserialize<List<Users>>( response );
            //request.AddUrlSegment( "id", "123" ); // replaces matching token in request.Resource





            return View( listUsers );
        }
    }
}