using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace autoEvent
{
    class Traitement
    {

        // exemple on remplit une list, une autre thread doit attendre que cette
        // liste soit complètment remplie avant de la traité ( imaginons récupéré
        // des datas JSON d'un webAPI mettant du temps à répondre )
        // but : synchronisation de sous-processus partageant les mêmes datas.

        // il ne s'agit pas de vérouillage ici ( pas de lock ou monitor )
        // mais bien de synchronisation
        // but => autoResetEvent et ManuelResetEvent

        // imaginons 1 thread ( T1 )récupérant les datas ( 1 manoeuvre apportant des briques )
        // imaginons 4 threads ( T2-5) traitant les datas ( 5 maçons construisant le mur )
        // T1 apporte des datas ( autoResetEvent ) T2 prends la main, 
        // le manuel dévérouille tout
        // l'auto dévérouille 1 thread ( il s'en fou de qui, le premier qui répond )

        public static AutoResetEvent MyAutoEvent;
        static Traitement() {

            // non signalé, attend sur un wait
            // si true je passe au travers des wait et je n'attends pas
            // remets auto en non signél pour les autres
            MyAutoEvent = new AutoResetEvent( false );
        }
        public static void DoWork() {
            Console.WriteLine( "Travail en cours" );
            System.Threading.Thread.Sleep( 5000 );
            Console.WriteLine( "Travail terminé" );
            MyAutoEvent.Set();
        }
    }
}
