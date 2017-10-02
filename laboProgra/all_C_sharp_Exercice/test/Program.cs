using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace test {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine( "Hello World!" );
            // new threadstart demande donc une fonction void nommé target
            // il exige une méthode sans argument et de type void
            // threadstart est un type délégué
            Thread test = new Thread( new ThreadStart( MonThread ) );
            // démarrer le thread
            test.Start();
            test.Abort


            Console.ReadKey();
        }

        static void MonThread() {

        }
    }
}
