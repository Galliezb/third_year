using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Trombinoscope {
    class User {
        public int UserId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Adresse { get; set; }
        public string CodePostal { get; set; }
        public string Numero { get; set; }
        public string Ville { get; set; }
    }
}
