using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sql_Connection.Models {


    public class Etudiant {

        public List<Etudiant> students = new List<Etudiant>();

        public int ID { get; set; }
        public string Matricule { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Localite { get; set; }
    }
}