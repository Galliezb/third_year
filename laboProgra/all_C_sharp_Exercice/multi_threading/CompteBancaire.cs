using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace multi_threading {
    class CompteBancaire {

        private System.Object lockthis = new System.Object();

        public float Solde { get; set; }
        public CompteBancaire(float Solde) {
            this.Solde = Solde;
        }
        public void Retrait(object montant) {

            float fmontant = Convert.ToSingle( montant );
            float resultat;
            // lock la variable, empeche les autres thread d'accéder au code avant le }
            // relance automatiquement le code une fois l'accès dispo
            // spammé l'execution ne donnera plus de solde négatif.
            lock (lockthis) {

                if (this.Solde - fmontant >= 0) {
                    System.Threading.Thread.Sleep( 10 );
                    resultat = this.Solde - fmontant;
                    this.Solde = resultat;
                    Console.WriteLine( "Execution Thread " + Thread.CurrentThread.Name + " avec solde " + this.Solde );
                }


            }
            // il est possible de gérer identiquement ce lock avec Monitor
            // mais il faudra absolumeent passé par un Enter et un Exit.
            // try finally recommandé, car en cas d'exit non appelé, le lock ne sera
            // jamais dévérouillé bloquant tous les accès aux autres threads.

            // de manière général, ex accès en BDD, le must sera d'avoir une fermeture
            // de la connexion sur le Finally pour s'assurer que la connexion est fermé
            // pour les autres threads, applications quelque soit le possible bug bloquant
            // l'execution du code

        }
    }
}
