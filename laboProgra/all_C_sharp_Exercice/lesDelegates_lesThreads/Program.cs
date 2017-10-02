using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

namespace lesDelegates_lesThreads
{
    class Program
    {

        public delegate ThreadStart MonTypeDelegue(float a);

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // new threadstart demande donc une fonction void nommé target
            // il exige une méthode sans argument et de type void
            // threadstart est un type délégué

            //Thread test = new Thread( new ThreadStart( MonThread ) );
            // démarrer le thread
            //test.Start();
            // OU

            ThreadStart toto = new ThreadStart(MonThread);
            toto();

            MonTypeDelegue dudule = new MonTypeDelegue( MonThread );
            dudule(0.5f);

            MonTypeDelegue dudule2 = delegate (float x) {
                return 12;
            };

            // ou encore avec expression lambda
            MonTypeDelegue dudule3 = x => { return (int)x; };
            //MonTypeDelegue dudule4 = x(param1,param2) => { return (int)x;};

            Thread test2 = new Thread();

            MaMethode( () => { return 10; } );
            MaMethode( (x,y) => { return x + y; } );

            Console.ReadKey();
        }

        static void MonThread() {

        }

        static float MonThread(float a) {
            //
            return 0;
        }

        static void MaMethode(Func<int> xxxx) {

        }
        static void MaMethode(Func<int,int> xxxx) {

        }

        static void MaMethode ( Func<int,int,int> test) {
            int data = 10;
            Console.WriteLine( test( data, 20 ) );
            List<test> toto = new List<test>();

            // on pourrait utiliser cela pour renseigner à find comment parcourir les collections
            // (x) => { return x.cylindre > 3000 }
            // qui permettra d'envoyé le délégué à find qui lui permettra
            // de chercher dans le collection depuis un méthode écrite beaucoup
            // plus rapidement qu'écrire une méthode de surcharge ou autre.
        }

        class test {

        }
    }
}
