using System;
using System.Threading;

namespace Thread_CallBack
{
    class Program
    {

        // si on test en winorm la modification d'un TB depuis un autre thread 
        // Opération inter-Threads non Valide ( depuis C# 2 c'est devenu interdit )
        // Solution possible :
        // * Autoriser l'inter-Thread dans la config ( temporaire pour les transitions )
        // * Appeler depuis le thread une méthode du thread principal permettant 
        // d'accéder à cette ressources ( via Invoke() )
        // invoke(délégué) fera appel à un mécanisme de passage des références
        // d'une pile à l'autre

        // this.textBox1.Invoke((MethodInvoker)delegate {this.textBox1.text = "xxxx";});


        static void Main(string[] args) {
            Traitement MyWork = new Traitement();
            MyWork.IsCompleted += MyWork_IsCompleted;
            Thread MyThread = new Thread( new ThreadStart( MyWork.DoWork ) );
            MyThread.Start();
            Console.ReadKey();
        }

        // le string sera directement récupéré via le Action<string>
        private static void MyWork_IsCompleted(string str) {
            Console.WriteLine( "Travail terminé: {0}", str );
        }
    }
}
