//using System;
//using System.Collections.Generic;
//using System.Threading;

//namespace WorkerThread {
//    class Program {

//        static void Main ( string[] args ) {

//            //Class1[] a = { new Class1() , new Class1() , new Class1() , new Class1() , new Class1() , new Class1() };
//            //foreach ( Class1 c in a ) {
//            //    c.Display();
//            //}


//            //for ( int i = 5; i < 15; i++ ) {
//            //    Thread th = new Thread( new ThreadStart( () => Class1.monAction( 1800 - 100 * i ) ) );
//            //    th.Name = i.ToString();
//            //    th.Start();
//            //}
//            //Thread.Sleep( 10000 );
//            //Console.WriteLine( "final : " + Class1.a );
//            List<Class1> a = new List<Class1>() { new Class1() , new Class1() , new Class1() , new Class1() , new Class1() };

//            for ( int i = 0; i < a.Count; i++ ) {
//                Console.WriteLine( "final : " + nameof( a[i] ) );
//            }



//            Console.ReadKey();
//        }
//    }

//    class Class1 {

//        private static readonly Object o = new Object();
//        static public int a = 0;
//        public static Action<int> monAction = ( t ) => {
//            lock ( o ) {
//                Thread.Sleep( t );
//                Console.WriteLine( Thread.CurrentThread.Name + " => " + Class1.a + " + " + 1 );
//                Class1.a += 1;
//            }

//        };

//        public void Display () {
//            Console.WriteLine( o.GetHashCode() );
//        }

//    }
//}