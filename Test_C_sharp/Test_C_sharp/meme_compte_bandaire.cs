//using System;
//using global::System.Collections.Generic;
//using test = System.Threading;


//namespace Test_C_sharp {

//    class CompteBancaire {

//        public List<Transaction> l;

//        public CompteBancaire () {
//            l = new List<Transaction>();
//        }

//        public async void DisplayTransaction () {

//            //async DisplayAllTransactions

//        }
//        private void DisplayAllTransactions () {
//            // synchrone, affiche 1 par 1 les trasanctions
//            test.Thread.Sleep( 30 );
//            global::System.Threading.Thread.Sleep( 30 );
//        }

//        public void AddTransaction ( Transaction t ) {
//            l.Add( t );
//        }
//        public void AddTransaction ( params Transaction[] t ) {
//            if ( t.Length > 0 ) {
//                foreach ( Transaction tr in t ) {

//                    l.Add( tr );
//                }
//            }

//        }

//        public virtual void CalculInteret () {
//            Console.WriteLine( "COMPTEBANCAIRE : calcule interet" );
//        }

//        public IEnumerator<Transaction> GetEnumerator () {
//            for ( int i = 0; i < l.Count; i++ ) {
//                yield return l[i];
//            }
//        }

//        public IEnumerable<Transaction> MonReverse {
//            get {
//                for ( int i = l.Count - 1; i > -1; i-- ) {
//                    yield return l[i];
//                }
//            }
//        }

//    }

//    class CompteAVue : CompteBancaire {

//        public override void CalculInteret () {
//            Console.WriteLine( "COMPTEAVUE : calcule interet" );
//        }

//    }

//    class Transaction {

//        public int montantTransfere { get; set; } = 0;
//        public Transaction ( int tmp ) {
//            montantTransfere = tmp;
//        }

//    }

//    //class ListTransaction<T> {

//    //    List<T> list = new List<T>();

//    //    public void AddClassToMyListGenerique ( T t ) {
//    //        list.Add( t );
//    //    }


//    //    public T this[int i] {
//    //        get {
//    //            return list[i];
//    //        }
//    //    }

//    //    public int NbrElement () {
//    //        return list.Count;
//    //    }


//    //}


//    class Program {

//        static void Main ( string[] args ) {


//            CompteBancaire b = new CompteBancaire();
//            b.AddTransaction( new Transaction( 1 ) );
//            b.AddTransaction( new Transaction( 2 ) );
//            b.AddTransaction( new Transaction( 3 ) );
//            b.AddTransaction( new Transaction( 4 ) );
//            b.AddTransaction( new Transaction( 5 ) );

//            foreach ( Transaction t in b ) {
//                Console.WriteLine( t.montantTransfere );
//            }
//            int a1 = 0;
//            int b1 = 2;
//            int a2 = 15200;
//            int b2 = 15200;
//            Console.WriteLine( " a1 => " + a1.CompareTo( b1 ).ToString() );
//            Console.WriteLine( " a2 => " + a2.CompareTo( b2 ).ToString() );


//            b.CalculInteret();
//            CompteAVue cpt = new CompteAVue();
//            cpt.CalculInteret();

//            var now = new DateTime();
//            var greeting = "Good" + ( ( now.Hour > 17 ) ? " evening." : " day." );
//            Console.WriteLine( " greeting => " + greeting );
//            Console.ReadKey();


//            int[] tab = { 0 , 0 , 0 , 0 , 0 , };
//            int[][] tab2 = new int[2][] { new int[] { 0 , 0 , 0 , 0 , 0 , 0 } , new int[] { 0 , 1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 , 9 , 9 , 9 , 9 , 9 , 0 , 9 , 9 , 9 , 9 } };
//            //int[,] tab3 = new int[2 , 2];
//            int[,] tab3 = new int[2 , 2] { { 0 , 0 } , { 0 , 0 } };

//            Dictionary<CompteAVue , List<CompteBancaire>> fdfdssfsdf = new Dictionary<CompteAVue , List<CompteBancaire>>();

//        }

//    }
//}