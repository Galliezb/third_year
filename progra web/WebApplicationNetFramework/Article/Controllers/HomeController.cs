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
        // pour le renvoi de l'imahge vers et depuis la BDD
        // s'il n'y a pas d'image uploader avec le form
        // Il est possible d'utiliser un DBNull.null

        //    return "fichier uploadé";

        // [HttpPost] => filtrage permettant d'empêcher la méthode d'être appelé sur un get
        [HttpPost]
        public string UploadImage() {

            HttpPostedFileBase fichierRecu = Request.Files.Get( 0 );
            // vérification qu'il s'agit d'une image
            if (fichierRecu.ContentLength > 0) {
                return "Erreur de réception du fichier";
                // vérification qu'il s'agit d'une image
            } else if (!fichierRecu.ContentType.StartsWith( "image" )) {
                return "Type de fichier inconnu";
            // vérification du poids de l'image ( 5ko max
            } else if ( fichierRecu.ContentLength > 50000 ) {
                return "Le fichier est trop volumineux";
            } else {

                // nom de l'image uploadé
                string[] toSplit = Request.Files[0].FileName.Split( '\\' );
                string name = toSplit[( toSplit.Length - 1 )];

                // redimensionner si nécessaire
                string fileName = Path.GetFileName( fichierRecu.pa );
                var path = Server.MapPath( "/img/" );
                string FullPath = path + @"\" + fileName;
                System.Drawing.Image sourceimage = System.Drawing.Image.FromStream( fichierRecu.InputStream );
                sourceimage.Save( FullPath );

            }

            // deuxième façon de récupérer
            //var toSplit = Request.Files[0].FileName.Split('\\');
            //string name = toSplit[(toSplit.Length-1)];
            Request.Files[0].SaveAs( @"C:\bruno\githubServer\third_year\progra web\WebApplicationNetFramework\Article\img\"+name );

            // avec JsonResult on aurait pu passer par ici
            //return Json( @"C:\bruno\githubServer\third_year\progra web\WebApplicationNetFramework\Article\img\" + Request.Files[0].FileName );
            return @"\img\"+name;
        }

        public JsonResult AddArticle( Articles a) {

            return Json( "Article ajoutée" );

        }

        // protection contre les attaques de forms qui proviennent d'ailleurs que du site web
        // Insertion automatique d'un champ ID ( le token )
        // via le cookie anti contrefaçon
        // dans la vue on insert un @Html.AntiForgeryToken()
        // sera validé dans le Controller par
        // [ValidateAntiForgeryToken]

    }
}