//using System;
//using System.Collections.Generic;
//using System.Threading;


//namespace Test_C_sharp {


//    class ClassBase {


//        public ClassBase ( int a , int b , int c = 10 , bool boule = false ) {

//        }
//    }

//    class Program {

//        //delegate void test ( List<int> b, params int[] a );
//        //delegate void test2 ( object[] a );

//        static void Main ( string[] args ) {

//            Func<int , bool> test = ( a ) => { return 1; };
//            Action<int , int[]> test2 = ( a , b ) => { /* faire quelque chose ici */ };
//            bool result = test( 1 );
//            test2( 1 , new int[] { 2 , 3 } );

//            //test a = delegate ( object x , object y ) {
//            //    Console.WriteLine( "appel délégué anonyme avec paramètres" );
//            //};
//            //test z = ( u,n ) => {
//            //    foreach ( var i in u ) {
//            //        Console.WriteLine( i );
//            //    }
//            //    foreach ( var i in n ) {
//            //        Console.WriteLine( i );
//            //    }
//            //    string s = n.ToString() + " World";
//            //    Console.WriteLine( s );
//            //};
//            //test2 abon = ( n ) => {
//            //    foreach ( var i in n ) {
//            //        Console.WriteLine( i );
//            //    }
//            //    string s = n.ToString() + " World";
//            //    Console.WriteLine( s );
//            //};
//            //Thread th = new Thread( new ThreadStart( () => { Console.WriteLine( "appel délégué anonyme"); } ) );
//            //Thread th2 = new Thread( new ParameterizedThreadStart( (n) => z((List<int>)n,15,1,1 ) ) );
//            //th2 = new Thread( new ParameterizedThreadStart( (n) => z((List<int>)n,1,2,1 ) ) );
//            //th2.Start( new List<int>() { 1 , 2 , 3 , 4 , 5 , 6 , 9 } );

//            //th2 = new Thread( new ParameterizedThreadStart( (n) => {
//            //    foreach( int i in (List<int>)n ) {
//            //        Console.WriteLine( i.ToString() );
//            //    }
//            //} ) );
//            //th2.Start( new List<int>() { 1 , 2 , 3 , 45 } );

//            //th2 = new Thread( new ParameterizedThreadStart( ( n ) => {
//            //    Console.WriteLine( "Bruno est vraiment le meilleur" );
//            //} ) );
//            //th2.Start( "Norbert m'emmerde plus la" );




//            Console.ReadKey();
//        }

//    }
//}