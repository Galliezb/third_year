using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testDiversPersos.Models;

namespace testDiversPersos.Controllers {
    public class AjaxController : Controller {

        SqlDataReader myRd = null;
        SqlConnection myConnection = null;

        // GET: Ajax
        public ActionResult Index () {
            return View();
        }

        public JsonResult AddUser ( Users u ) {

            string str = @"Server=127.0.0.1\SQLEXPRESS; Database = Banque; Uid = labo; Password = 123";

            string connectionStr = str;
            myConnection = new SqlConnection( connectionStr );

            SqlCommand myCmd = new SqlCommand();
            myCmd.Connection = myConnection;
            myCmd.CommandType = CommandType.StoredProcedure;
            myCmd.CommandText = "AddUser";
            myCmd.Parameters.AddWithValue( "@Name" , u.Name );
            myCmd.Parameters.AddWithValue( "@Firstname" , u.Firstname );
            myCmd.Parameters.AddWithValue( "@Solde" , u.Solde );

            myConnection.Open();

            myCmd.ExecuteNonQuery();

            myConnection.Close();

            string messageDeRetour = "Utilisateur ajoutée à la BDD";
            return Json( messageDeRetour );
        }


        //////////////////////////////////// AMBIGUITE ///////////////////////////////////
        //public JsonResult AddUser ( int ID, string Name, string Firstname, int Solde ) {

        //    string messageDeRetour = "Utilisateur ajoutée à la BDD";

        //    return Json( messageDeRetour );
        //}



    }
}