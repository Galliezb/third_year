using System;
using System.Threading;

namespace autoEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine( "Demande de démarrage du traitement secondaire" );

            Thread MyThread = new Thread( new ThreadStart( Traitement.DoWork ) );
            MyThread.Start();
            Console.WriteLine( "Travail principal poursuivi" );
            System.Threading.Thread.Sleep( 500 );
            Console.WriteLine( "Attente de fin de traitement secondaire" );

            // attend que le travail du thread soi terminé
            // il sera prévenu par le MyAutoEvent.Set();
            Traitement.MyAutoEvent.WaitOne();
            Console.WriteLine( "Traitement secondaire est terminé" );
            Console.ReadKey();
        }
    }
}
