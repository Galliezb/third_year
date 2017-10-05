using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Enumeration
{
    class GarageEnumerator : IEnumerator<Vehicule> {

        private Vehicule[] flotte;
        private int nbVehicule;
        private int indice;

        public GarageEnumerator(int nbVehicule, Vehicule[] flotte) {
            this.flotte = flotte;
            this.nbVehicule = nbVehicule;
            indice = 0;
        }

        public Vehicule Current {
            get { return this.flotte[indice]; }
        }

        //object IEnumerator.Current => throw new NotImplementedException();
        object IEnumerator.Current {
            get { return this.flotte[indice]; }
        }

        public void Dispose() {
            throw new NotImplementedException();
        }

        public bool MoveNext() {
            if ( indice < this.nbVehicule-1) {
                this.indice++;
                return true;
            } else {
                return false;
            }
        }

        public void Reset() {
            this.indice = 0;
        }
    }
}
