using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Article.Models;
using System.IO;

namespace Article.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        //ATTENTION => le même nom que celui donnée dans le formData avant envoi AJAX
        //public string UploadImage(HttpPostedFileBase monImageUploaded) {

        //    string fileName = Path.GetFileName( monImageUploaded.FileName );
        //    var path = Server.MapPath( "/img/" );
        //    string FullPath = path + @"\" + fileName;
        //    //le fromstream renvoie une image selon le flux, si elle n'est pas correcte, cela lèvera une exception
        //    System.Drawing.Image sourceimage = System.Drawing.Image.FromStream( monImageUploaded.InputStream );
        //    sourceimage.Save( FullPath );
        // sauvegarde en BDD
        // var ms = memoryStream()
        // sourceimage.Save(ms, System.drawing.imaging.Imageformat.Png )
        // MyCmd.Parameters.AddWithValue("@nameParamater", ms.toArray() );

        //    return "fichier uploadé";

        // [HttpPost] => filtrage permettant d'empêcher la méthode d'être appelé sur un get
        [HttpPost]
        public string UploadImage() {

            // TODO mise à l'échelle de l'image

            // deuxième façon de récupérer
            var toSplit = Request.Files[0].FileName.Split('\\');
            string name = toSplit[(toSplit.Length-1)];
            Request.Files[0].SaveAs( @"C:\bruno\githubServer\third_year\progra web\WebApplicationNetFramework\Article\img\"+name );

            // avec JsonResult on aurait pu passer par ici
            //return Json( @"C:\bruno\githubServer\third_year\progra web\WebApplicationNetFramework\Article\img\" + Request.Files[0].FileName );
            return @"\img\"+name;
        }

        public JsonResult AddArticle( Articles a) {

            return Json( "Article ajourée" );

        }
    }
}