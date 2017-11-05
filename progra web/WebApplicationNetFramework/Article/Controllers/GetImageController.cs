using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Article.Controllers
{
    public class GetImageController : Controller
    {

        string strConnection = @"Server=127.0.0.1\SQLEXPRESS; Database = labo_sql_connection; Uid = labo; Password = 123";

        public ActionResult Index ( int id=12 ) {

            SqlConnection myConnection = new SqlConnection( strConnection );
            myConnection.Open();

            SqlCommand myCmd = new SqlCommand {
                Connection = myConnection ,
                CommandType = CommandType.StoredProcedure ,
                CommandText = "GetImg"
            };
            myCmd.Parameters.AddWithValue( "@idImg" , id );

            SqlDataReader monReader = myCmd.ExecuteReader();
            monReader.Read();

            byte[] imgData = (byte[])monReader["img"];

            //ViewBag.Base64String = "data:image/png;base64," + Convert.ToBase64String( imgData , 0 , imgData.Length );

            return File( imgData , "image/jpg" );


        }
    }
}