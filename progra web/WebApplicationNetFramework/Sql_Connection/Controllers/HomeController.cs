using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Sql_Connection.Models;

namespace Sql_Connection.Controllers {
    public class HomeController : Controller {

        List<Etudiant> lStudent = new List<Etudiant>();
        SqlDataReader myRd = null;
        SqlConnection myConnection = null;
        Dictionary<string , string> dictio = new Dictionary<string , string>();

        // GET: Home
        public ActionResult Index () {
            GetAllAMtricules();
            return View( lStudent );
        }

        private void GetFromStoredProcedure ( string nameProcedure  ) {

            string str = @"Server=127.0.0.1\SQLEXPRESSFIXE; Database = labo_sql_connection; Uid = labo; Password = 123456789";

            string connectionStr = str;
            myConnection = new SqlConnection( connectionStr );
            myConnection.Open();

            SqlCommand myCmd = new SqlCommand();
            myCmd.Connection = myConnection;
            myCmd.CommandType = CommandType.StoredProcedure;
            myCmd.CommandText = nameProcedure;

            if ( dictio.Count > 0 ) {

                foreach ( KeyValuePair<string , string> kp in dictio ) {
                    myCmd.Parameters.AddWithValue( kp.Key , kp.Value );
                }

            }
            dictio.Clear();

            myRd = myCmd.ExecuteReader();

        }

        private void CloseConnection () {
            myRd.Close();
            myConnection.Close();
        }

        private void GetAllAMtricules () {

            GetFromStoredProcedure( "GetAllMatricules" );

            while ( myRd.Read() ) {
                lStudent.Add( new Etudiant { Matricule = myRd["matricule"].ToString() } );
            }

            CloseConnection();

        }

        public JsonResult GetAllFromMatricule ( string id ) {

            dictio.Add( "@matricule" , id );
            Console.WriteLine( dictio );

            GetFromStoredProcedure( "GetAllFromMatricule" );

            myRd.Read();

            Etudiant ets = new Etudiant() {
                ID = int.Parse( myRd["ID"].ToString() ) ,
                Matricule = myRd["matricule"].ToString() ,
                Nom = myRd["nom"].ToString() ,
                Prenom = myRd["prenom"].ToString() ,
                Localite = myRd["localite"].ToString()
            };

            return Json( ets );

        }

        public JsonResult getStudentInfo ( string mat ) {

            string connectionStr = @"Server=127.0.0.1\SQLEXPRESS;database=";
            SqlConnection myConnection = new SqlConnection( connectionStr );
            myConnection.Open();
            SqlCommand myCmd = new SqlCommand();
            myCmd.Connection = myConnection;
            myCmd.CommandType = CommandType.StoredProcedure;
            myCmd.CommandText = "getStudentInfo";
            myCmd.Parameters.AddWithValue( "@Matricule" , mat );

            SqlDataReader myRd = myCmd.ExecuteReader();
            myRd.Read();
            Etudiant et = new Etudiant { Nom = myRd["nom"].ToString() , Prenom = myRd["prenom"].ToString() , Localite = myRd["localite"].ToString() };

            myRd.Close();
            myConnection.Close();

            return Json( et );

        }

    }
}