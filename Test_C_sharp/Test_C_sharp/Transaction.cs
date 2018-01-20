using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Test_C_sharp {
    class Transaction : IEnumerator, IEnumerable {

        string dateTransaction;
        static int nombreTransaction;
        int numero_ordre;
        double montant;

        int[] mesInts = new int[] { 1 , 2 , 3 , 4 , 5 , 6 , 7 };
        int CurrentPosition = 0;


        public Transaction ( double m ) {
            nombreTransaction++;
            numero_ordre = nombreTransaction;
            montant = m;
            dateTransaction = DateTime.Now.ToString( "dd/MM/YYYY" );
        }
        static Transaction () {
            nombreTransaction = 0;
        }

        public void Dispose () { }
        public bool MoveNext () {
            if ( CurrentPosition < 2 ) {
                return true;
            } else {
                return false;
            }
        }
        public void Reset () {
            CurrentPosition = 0;
        }
        public object Current {
            get {
                return CurrentPosition;
            }
        }
        public IEnumerator GetEnumerator () {
            //{ 1 , 2 , 3 , 4 , 5 , 6 , 7 }
            for ( int i = 0; i < mesInts.Length; i++ ) {
                yield return mesInts[i];
            }

        }

        public IEnumerable Reverse() {
            //{ 1 , 2 , 3 , 4 , 5 , 6 , 7 }
            for ( int i = mesInts.Length-1; i > -1; i-- ) {
                    yield return mesInts[i];
                }

        }
    }

}

