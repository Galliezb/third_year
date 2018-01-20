using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_ex_janvier_2018.Models;

/*
 PROCEDURE BINARY DANS RAZOR :
 1) copier <add assembly="System.Data.Linq, Version=3.5.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089"/>
 2) coller dans View/Home/web.config ( pas Web.config ) 
 3) utilisez le type binary en razor :D

    ******************************* SI CA MERDE **********************
    1) Créér ta propre classe, stock le binary dans un byte[] tabByte = xxx.toArray()
    2) en Razor faire :
    @{
    var base64 = Convert.ToBase64String(Model.ByteArray);
    var imgSrc = String.Format("data:image/gif;base64,{0}", base64);
    }
    <img src="@imgSrc" />

*/



namespace ASP_ex_janvier_2018.Controllers {
    public class HomeController : Controller {

        public MVM mvm { get; set; }

        // GET: Home
        public ActionResult Index () {

            mvm = new MVM();
            LinkDataContext BDD = new LinkDataContext();
            mvm.Tout = BDD.GetAll().ToList();
            mvm.ListGenre = BDD.GetAllGenre().ToList();
            mvm.ListCollection = BDD.GetCollection().ToList();

            return View( mvm );
        }

        public FileContentResult GetImage ( string id ) {

            byte[] imgData;

            try {
                Guid guid = Guid.Parse( id );

                LinkDataContext BDD = new LinkDataContext();
                AjaxGetImageResult a = BDD.AjaxGetImage( guid ).First();

                imgData = a.Photo.ToArray();

                //ViewBag.Base64String = "data:image/png;base64," + Convert.ToBase64String( imgData , 0 , imgData.Length );

                
            } catch ( Exception e ) {
                imgData = System.IO.File.ReadAllBytes( @"D:\githubServer\third_year\ASP_ex_janvier_2018\ASP_ex_janvier_2018\img\default.jpg" );
            }

            return File( imgData , "image/jpg" );

        }

        public string Update (string guid, string dnom, string ddesc, string genre, string collection) {

            try {
                Guid articleId = Guid.Parse( guid );
                Guid genreId = Guid.Parse( genre );
                Guid collectionId = Guid.Parse( collection );

                LinkDataContext BDD = new LinkDataContext();
                BDD.UpdateArticle( articleId , genreId , collectionId , dnom , ddesc );

                return "ok";
            } catch ( Exception e ) {
                return "pasok";
            }


        }
    }
}