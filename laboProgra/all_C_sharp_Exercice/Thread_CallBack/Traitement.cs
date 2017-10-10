using System;
using System.Collections.Generic;
using System.Text;

namespace Thread_CallBack {
    class Traitement {
        // l'evenementiel se base sur des messages
        // si aucun message n'est présent, on attend une entrée.
        // La programmation Action sera donc d'associé un message
        // à une action.
        // Action / func est un délégué
        // Action n'as pas de type de retour comparé à Func
        // RAppel : un délégué est une référence qui pointe vers une méthode
        // si un message pointe vers une délégué, il exécute le code
        // s'il ne pointe vers aucun délégué, rien ne sera éxécuté
        // = fonctionnement évènementiel chez Microsoft

        public event Action<string> IsCompleted;
        public void DoWork() {
            Console.WriteLine( "Travail en cours" );
            System.Threading.Thread.Sleep( 10000 );
            Console.WriteLine( "Travail terminé" );
            if (IsCompleted != null) {
                IsCompleted( "MyData" );
            }
        }

        // au travers des expressions lambda, on peut en plus de simplifié la visibilité
        // du code ( thread crée, sur une délégué pointant une méthode ailleurs etc... ),
        // on concentre tout le code touchant au thread au même endroit.


        // pour la gestion du callback il suffira d'ajouter une expression lambda
        // via le continueWith
        // var MyTask = Task<string>.Run(() =>
        // {
        // Task.Delay(1000);
        // this.WriteTB("xxxx");
        // return "TOTO";
        // }).ContinueWith((test) => { MessageBox.Show(test.Result);});

        // test sera donc une référence sur Task<string> qui vient de finir de s'executer
        // permettant au travers du test.result, de récupérer le return.
    }
}
