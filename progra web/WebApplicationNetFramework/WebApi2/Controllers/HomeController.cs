using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi2.Models;

namespace WebApi2.Controllers
{
    public class HomeController : ApiController
    {
        // GET: api/Home
        // http://www.tutorialsteacher.com/webapi/create-web-api-project
        public IEnumerable<GetUserListResult> Get() {
            //return new string[] { "value1", "value2" };
            toUserDataContext tud = new toUserDataContext();
            var maListeUser = tud.GetUserList().ToList();
            return maListeUser;
        }

        // GET: api/Home/5
        [HttpGet]
        public GetAllFromUserIdResult Get(int id) {
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
