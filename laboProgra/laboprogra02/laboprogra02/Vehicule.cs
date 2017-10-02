using System;
using System.Collections.Generic;
using System.Text;

namespace laboprogra02 {
    class Vehicule : IComparable {

        string _marque;
        int _cylindree;
        string _numero_chassis;

        // plutot que de mettre des valeurs par défaut dans le constructeur
        // dispo depuis une certaine version de .net
        // on peut écrire ceci qui est compatible pour les anciennes versions de .net
        public Vehicule():this("noMark",0,"numero_chassis") { }

        public Vehicule(string marque,int cylindree, string numero_chassis) {
            this._marque = marque;
            this._cylindree = cylindree;
            this._numero_chassis = numero_chassis;
        }



        public string GetNumeroChassis() {

            return this._numero_chassis;

        }

        // mise en place d'un opérator
        static public bool operator==(Vehicule v1,Vehicule v2) {
            return false;
            // exemple
            //return v1._cylindree == v2._cylindree;
        }

        // == exige la surcharg de !=
        static public bool operator !=(Vehicule v1, Vehicule v2) {
            return true;
            // exemple
            //return v1._cylindree != v2._cylindree;

        }

        // 2 warning sont soulevés, ces méthodes ne substituent pas à equals et gethashcode
        // hashcode -> code hashé qui donne une facon d'identifier l'objet de manière unique
        // equals permet de savoir si les deux objets sont identiques
        // alors que notre méthode ne vérifie que le N° de chassis ( bien qu'il soit unique )


        public int CompareTo(object obj) {

            Vehicule tmp = (Vehicule)obj;
            return this._cylindree.CompareTo(tmp._cylindree);
            //throw new NotImplementedException();
        }

        static public explicit operator float( Vehicule v) {

            // blablabla
            return 0.5f;
        }

        static public implicit operator int ( Vehicule v) {
            return v._cylindree;
        }

    }
}
