using System;
using System.Threading;

namespace multi_threading
{
    class Program
    {
        static void Main(string[] args)
        {
            CompteBancaire MtCompte = new CompteBancaire( 500 );
            int i = 20;
            while (i >= 0) {
                Thread MyThread1 = new Thread( new ParameterizedThreadStart( MtCompte.Retrait ) );
                MyThread1.Name = String.Format("MyThread:{0}",i);
                MyThread1.Start( 45 );
                i--;
            }
            Console.ReadKey();
            Console.WriteLine( "Solde du compte {0}", MtCompte.Solde );
            Console.ReadKey();
        }
    }
}
