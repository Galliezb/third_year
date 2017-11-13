using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compteBancaire {
    public class Banque {

        double solde { get; set; }
        bool bloque { get; set; } = false;
        string nom { get; set; }

        public Banque(double solde, string nomDeCompte) {

            this.solde = solde;
            this.nom = nomDeCompte;

        }

        public void Debit(double montant) {

            if ( bloque) {
                throw new Exception( "compte bloqué" );
            }
            if ( montant > solde ) {
                throw new ArgumentOutOfRangeException( "montant", "montant plus grand que le solde bancaire" );
            }
            if ( montant < 0) {
                throw new ArgumentOutOfRangeException( "montant", "montant plus petit que zéro" );
            }
            solde -= montant;
        }

        public void Credit (double montant) {

            if (bloque) {
                throw new Exception( "compte bloqué" );
            }
            if ( montant < 0) {
                throw new ArgumentOutOfRangeException( "montant", "montant plus petit que zéro" );
            }
            solde += montant;
        }

        public void BloqueCompte() {
            this.bloque = true;
        }

        public void DebloquerCompte() {
            this.bloque = false;
        }

    }
}
