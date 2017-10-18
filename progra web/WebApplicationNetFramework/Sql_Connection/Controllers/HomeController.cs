using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Sql_Connection.Models;

namespace Sql_Connection.Controllers
{
    public class HomeController : Controller
    {
        List<Etudiant> lStudent = new List<Etudiant>();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        private void GetAllAMtricules() {

            string connectionStr = @"Server=127.0.0.1\SQLEXPRESS;database=";
            SqlConnection myConnexion = new SqlConnection( connectionStr );
            myConnexion.Open();
            SqlCommand myCmd = new SqlCommand();
            myCmd.Connection = myConnexion;
            myCmd.CommandType = CommandType.StoredProcedure;
            myCmd.CommandText = "GetAllMatricules";

            SqlDataReader myRd = myCmd.ExecuteReader();

            while (myRd.Read()) {
                lStudent.Add( new Etudiant { ID= myRd["Matricules"].ToString(), Nom = myRd["Matricules"].ToString(), Matricule = myRd["Matricules"].ToString() } );
            }
            //
            // OU
            //
            //DataTable mytable = new DataTable();
            //mytable.Load( myRd );
            myRd.Close();
            myConnexion.Close();

        }

        public JsonResult getStudentInfo(string mat) {

            string connectionStr = @"Server=127.0.0.1\SQLEXPRESS;database=";
            SqlConnection myConnexion = new SqlConnection( connectionStr );
            myConnexion.Open();
            SqlCommand myCmd = new SqlCommand();
            myCmd.Connection = myConnexion;
            myCmd.CommandType = CommandType.StoredProcedure;
            myCmd.CommandText = "getStudentInfo";
            myCmd.Parameters.AddWithValue( "@Matricule", mat );

            SqlDataReader myRd = myCmd.ExecuteReader();
            myRd.Read();
            Etudiant et = new Etudiant { Nom = myRd["nom"].ToString(), Prenom = myRd["prenom"].ToString(), Localite = myRd["localite"].ToString() };

            myRd.Close();
            myConnexion.Close();

            return Json( et );

        }

    }
}