using System;
using System.Collections.Generic;
using System.Threading;

namespace WorkerThread {
    class Program {

        public delegate bool superDelegue ();

        static void Main ( string[] args ) {

            superDelegue test = new superDelegue( new Class1().Display );
            int? a = 10;
            if ( test?.Invoke() ?? false ) {
                Console.WriteLine( "C'est vrai" );
            } else {
                Console.WriteLine( "C'est faux" );
            }

            Console.ReadKey();
        }
    }

    class Class1 {

        private static readonly Object o = new Object();
        static public int a = 0;


        public bool Display () {
            Console.WriteLine( o.GetHashCode() );
            return true;
        }

    }
}