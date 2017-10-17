using System;
using System.Collections.Generic;
using System.Text;

namespace param_valeur_reference
{
    class Personne
    {
        public string nom { get; set; }
        public string prenom { get; set; }

        public override string ToString() {
            //return nom + "" + prenom;
            return String.Format( "{0} {1}", prenom, nom );
        }

    }
}
