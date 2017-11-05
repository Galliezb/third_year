using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Article.Models;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace Article.Controllers
{
    public class HomeController : Controller
    {

        string strConnection = @"Server=127.0.0.1\SQLEXPRESS; Database = labo_sql_connection; Uid = labo; Password = 123";
        List<Articles> listArticle = new List<Articles>();

        // GET: Home
        public ActionResult Index()
        {
            GetAllArticles();
            return View( listArticle );
        }

        private void GetAllArticles () {

            listArticle.Clear();

            SqlConnection myConnection = new SqlConnection( strConnection );
            myConnection.Open();

            SqlCommand myCmd = new SqlCommand {
                Connection = myConnection ,
                CommandType = CommandType.StoredProcedure ,
                CommandText = "GetAllArticles"
            };

            SqlDataReader monReader = myCmd.ExecuteReader();
            while ( monReader.Read() ) {

                Articles a = new Articles();
                a.Nom = monReader["nom"].ToString();
                a.Descriptif = monReader["descriptif"].ToString();
                a.Promo = bool.Parse( monReader["promo"].ToString() );

                int idImage;
                if ( int.TryParse( monReader["idImg"].ToString() , out idImage ) ) {
                    a.IdImg = idImage;
                } else {
                    a.IdImg = 0;
                }

                if ( monReader["img"] != DBNull.Value ) {
                    byte[] outByte = (byte[]) monReader["img"];
                    string base64 = Convert.ToBase64String( outByte);
                    a.ImgSrc = string.Format( "data:image/jpg;base64,{0}" , base64 );

                    // pour tester
                    //string laStrImg = Convert.ToBase64String( outByte , 0 , outByte.Length );
                    //ViewBag.Base64String = "data:image/png;base64," + laStrImg;
                } else {
                    a.ImgSrc = "/img/default.png";
                }


                a.UniqueIdentifier = monReader["id"].ToString();

                listArticle.Add( a );

            }

            monReader.Close();
            myConnection.Close();

        }

        [HttpPost]
        //ATTENTION => le même nom que celui donnée dans le formData avant envoi AJAX
        public JsonResult UploadImage ( HttpPostedFileBase monImageUploaded ) {

            // traitement du fichier
            string fileName = Path.GetFileName( monImageUploaded.FileName );
            var path = Server.MapPath( "/img/" );
            string FullPath = path + @"\" + fileName;
            ////le fromstream renvoie une image selon le flux, si elle n'est pas correcte, cela lèvera une exception
            //System.Drawing.Image sourceimage = System.Drawing.Image.FromStream( monImageUploaded.InputStream );
            //sourceimage.Save( FullPath );

            BinaryReader br = new BinaryReader( monImageUploaded.InputStream );
            byte[] bytes = br.ReadBytes( monImageUploaded.ContentLength );

            SqlConnection myConnection = new SqlConnection( strConnection );
            myConnection.Open();

            SqlCommand myCmd = new SqlCommand {
                Connection = myConnection ,
                CommandType = CommandType.StoredProcedure ,
                CommandText = "addImg"
            };

            myCmd.Parameters.AddWithValue( "@img" , bytes );
            myCmd.ExecuteNonQuery();

            // récupère le dernier id ( ouep je sais c'est crade mais je trouve pas encore comment
            // retourner le @@IDENTITY )
            myCmd.CommandText = "getLastIdInserted";
            myCmd.Parameters.Clear();
            SqlDataReader monReader = myCmd.ExecuteReader();
            monReader.Read();
            int topID = int.Parse( monReader["id"].ToString() );

            monReader.Close();
            myConnection.Close();

            // on renvoye l'image pour la prévisualisation
            string base64 = Convert.ToBase64String( bytes );
            string ImgSrc = string.Format( "data:image/jpg;base64,{0}" , base64 );


            return Json( new { id = topID , url = ImgSrc } );


            //public string UploadImage() {

            //// deuxième façon de récupérer
            //var toSplit = Request.Files[0].FileName.Split('\\');
            //string name = toSplit[(toSplit.Length-1)];
            //Request.Files[0].SaveAs( @"C:\bruno\githubServer\third_year\progra web\WebApplicationNetFramework\Article\img\"+name );

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
        }

        // Y'a des trucs comme les vérifications qui peuvent être utile. Vieux code à delete.
        // [HttpPost] => filtrage permettant d'empêcher la méthode d'être appelé sur un get
        // [HttpPost]
        //
        //public string UploadImage () {

        //    HttpPostedFileBase fichierRecu = Request.Files.Get( 0 );
        //    // vérification qu'il s'agit d'une image
        //    if ( fichierRecu.ContentLength > 0 ) {
        //        return "Erreur de réception du fichier";
        //        // vérification qu'il s'agit d'une image
        //    } else if ( !fichierRecu.ContentType.StartsWith( "image" ) ) {
        //        return "Type de fichier inconnu";
        //        // vérification du poids de l'image ( 5ko max
        //    } else if ( fichierRecu.ContentLength > 50000 ) {
        //        return "Le fichier est trop volumineux";
        //    } else {

        //        // nom de l'image uploadé
        //        string[] toSplit = Request.Files[0].FileName.Split( '\\' );
        //        string name = toSplit[( toSplit.Length - 1 )];

        //        // redimensionner si nécessaire
        //        string fileName = Path.GetFileName( fichierRecu.pa );
        //        var path = Server.MapPath( "/img/" );
        //        string FullPath = path + @"\" + fileName;
        //        System.Drawing.Image sourceimage = System.Drawing.Image.FromStream( fichierRecu.InputStream );
        //        sourceimage.Save( FullPath );

        //    }

        //    // deuxième façon de récupérer
        //    //var toSplit = Request.Files[0].FileName.Split('\\');
        //    //string name = toSplit[(toSplit.Length-1)];
        //    Request.Files[0].SaveAs( @"C:\bruno\githubServer\third_year\progra web\WebApplicationNetFramework\Article\img\" + name );

        //    // avec JsonResult on aurait pu passer par ici
        //    //return Json( @"C:\bruno\githubServer\third_year\progra web\WebApplicationNetFramework\Article\img\" + Request.Files[0].FileName );
        //    return @"\img\" + name;
        //}


        public string AddArticle ( Articles a ) {

            // enregisrement en BDD
            SqlConnection myConnection = new SqlConnection( strConnection );
            myConnection.Open();

            SqlCommand myCmd = new SqlCommand {
                Connection = myConnection ,
                CommandType = CommandType.StoredProcedure ,
                CommandText = "addArticle"
            };

            myCmd.Parameters.AddWithValue( "@nom" , a.Nom );
            myCmd.Parameters.AddWithValue( "@descriptif" , a.Descriptif );
            myCmd.Parameters.AddWithValue( "@promo" , a.Promo );
            if ( a.IdImg != 0 ) {
                myCmd.Parameters.AddWithValue( "@idImg" , a.IdImg );
            }
            myCmd.ExecuteNonQuery();
            
            myConnection.Close();

            return "Article ajoutée dans la BDD";
        }

        // protection contre les attaques de forms qui proviennent d'ailleurs que du site web
        // Insertion automatique d'un champ ID ( le token )
        // via le cookie anti contrefaçon
        // dans la vue on insert un @Html.AntiForgeryToken()
        // sera validé dans le Controller par
        // [ValidateAntiForgeryToken]

    }
}