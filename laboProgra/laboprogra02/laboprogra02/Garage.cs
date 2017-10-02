using System;
using System.Collections.Generic;
using System.Text;

namespace laboprogra02 {
    class Garage {

        string _site;
        int _nbVehicule;
        int _maxVehicule;
        Vehicule[] Tvehicule;
        List<Vehicule> LV;

        public Garage(int maxVehicule, string site) {
            Tvehicule = new Vehicule[maxVehicule];
            this._nbVehicule = 0;
            this._maxVehicule = maxVehicule;
            this._site = site;
            this.LV = new List<Vehicule>( maxVehicule );
        }

        public void AddVehicule(Vehicule vaj) {

            if (this._nbVehicule < this._maxVehicule) {

                this._nbVehicule++;
                this.Tvehicule[this._nbVehicule] = vaj;
                this.LV.Add( vaj );

            } else {
                throw new Exception( "Trop de Véhicule" );
            }
        }

        // pour récupérer une véhicule sur G1[0]
        // on mets en place un indexeur
        // avec un override on ne peut faire passer qu'un entier
        public Vehicule this[int i] {
            get {
                return this.Tvehicule[i];
            }
        }

        // imaginons qu'on envoi le N° de chassis pour trouver le véhicule
        public Vehicule this [string numChassis] {

            get {
                // on pourrait mettre var v, le système voyant la collection de véhicule
                // il mettra automatiquement vehicule en type pour le var
                foreach ( Vehicule v in this.Tvehicule) {
                    if ( v.GetNumeroChassis() == numChassis) {
                        return v;
                    }
                }
                throw new Exception( "Numero de chassis introuvable" );
            }

        }
    }

    // on aurait pu faire plus simple
    class GarageTest : List<Vehicule> {

        // en créant un garage ailleurs, on pourra faire 
        // garageTest g2 = new garageTest();
        // g2.add(new vehicule(...));
        // g2 héritera de la list et donc de ses fonctionnalités

    }


}
