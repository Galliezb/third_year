using System;
using System.Collections.Generic;
using System.Text;

namespace laboprogra02
{
    class Utilitaire : Vehicule
    {

        int _mma;

        public Utilitaire(string marque, int cylindree, string numero_chassis, int mma):base(marque,cylindree,numero_chassis) {
            this._mma = mma;
        }

    }
}
