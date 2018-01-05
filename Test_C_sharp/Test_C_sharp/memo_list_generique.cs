//using System;
//using System.Collections.Generic;

//namespace Test_C_sharp {

//    class ClassBase : IComparable<ClassBase> {
//        public int a { get; set; } = 0;

//        public ClassBase ( int tmp ) {
//            a = tmp;
//        }

//        public int CompareTo ( ClassBase other ) {
//            if ( this.a > other.a ) {
//                return this.a;
//            } else {
//                return other.a;
//            }
//        }
//    }

//    class ListGenerique<T> where T : IComparable<T> {

//        List<T> list = new List<T>();

//        public void AddClassToMyListGenerique ( T t ) {
//            list.Add( t );

//        }

//        public int Compare ( T x , T y ) {
//            return x.CompareTo( y );
//        }

//        public T this[int i] {
//            get {
//                return list[i];
//            }
//        }


//    }

//    class Program {

//        static void Main ( string[] args ) {

//            ListGenerique<ClassBase> lg = new ListGenerique<ClassBase>();
//            lg.AddClassToMyListGenerique( new ClassBase( 0 ) );
//            lg.AddClassToMyListGenerique( new ClassBase( 1 ) );
//            lg.AddClassToMyListGenerique( new ClassBase( 2 ) );
//            lg.AddClassToMyListGenerique( new ClassBase( 3 ) );
//            lg.AddClassToMyListGenerique( new ClassBase( 4 ) );

//            Console.WriteLine( " 0 VS 1 => " + lg.Compare( lg[0] , lg[1] ) );
//            Console.WriteLine( " 0 VS 2 => " + lg.Compare( lg[0] , lg[2] ) );
//            Console.WriteLine( " 0 VS 3 => " + lg.Compare( lg[0] , lg[3] ) );

//            Console.ReadKey();


//        }

//    }
//}