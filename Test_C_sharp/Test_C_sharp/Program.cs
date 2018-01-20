using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

namespace Test_C_sharp {

    delegate void monDelegue ( object a , object b );


    class Program {

        static public void Main() {

            List<Transaction> lcb = new List<Transaction>();

            lcb.Add( new Transaction(0.0));

            foreach ( int i in lcb[0].Reverse() ) {
                Console.WriteLine( "" + i );
            }

            Console.WriteLine( "---------------------" );

            Console.ReadKey();

        }

    }

}