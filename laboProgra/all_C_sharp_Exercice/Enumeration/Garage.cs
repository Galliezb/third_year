using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Enumeration
{
    class Garage:IEnumerable<Vehicule>
    {
        private Vehicule[] flotte;
        private int taille;
        private int nbVehicule;

        public Garage(int tailleGarrage) {
            this.nbVehicule = 0;
            flotte = new Vehicule[tailleGarrage];
        }

        public void Add(Vehicule vh) {
            if ( this.nbVehicule < this.flotte.Length) {
                this.flotte[this.nbVehicule] = vh;
                this.nbVehicule++;
            } else {
                throw new GaragePleinException();
            }
        }

        public IEnumerator<Vehicule> GetEnumerator() {
            for (int i =0; i<this.nbVehicule; i++) {
                yield return flotte[i];
            }
        }

        // on peut ajouter autant d'enumerator que l'on veut
        // dans un foreach il suffira de l'appeler comme une méthode de classe sans 
        // aucun soucis ex : foreach ( vehicule v in G1.getReverse() ){}
        // !!!!!!!!!!!!!!!!! CE SONT DES IENUMERABLE et pas IENUMERATOR
        public IEnumerator<Vehicule> getReverse() {
            for (int i = nbVehicule-1; i > 0; i--) {
                yield return flotte[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return new GarageEnumerator( this.nbVehicule, this.flotte );
        }
    }
}
