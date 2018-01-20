using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Test_C_sharp {
    class CompteBancaire : IEnumerable {

        string numeroBancaire;
        string titulaire;
        double solde;
        uint facilite;
        List<Transaction> listTransaction;
        static uint maxFacilite;


        public CompteBancaire ( string t , string n , uint f ) {

            numeroBancaire = n;
            titulaire = t;
            facilite = f;
            solde = 0;

        }

        public CompteBancaire ( string t , string n ) : this( t , n , maxFacilite ) { }

        public void Depot ( double montant ) {
            solde += montant;
            listTransaction.Add( new Transaction( montant ) );
        }

        static CompteBancaire () {
            maxFacilite = 500;
        }

        public void Retrait ( double montant ) {

            if ( solde - montant > -facilite ) {
                solde -= montant;
                listTransaction.Add( new Transaction( montant ) );
            } else {
                throw new SoldeInsuffisant( "Vous n'avez plus de tune !" );
            }

        }

        public void Retrait ( params double[] montants ) {

            for ( int i = 0; i < montants.Length; i++ ) {
                Retrait( montants[i] );
            }

        }


        public string NumeroBancaire {
            get { return numeroBancaire; }
        }

        public double Solde {
            get { return solde; }
        }
        public uint Facilite {
            get { return facilite; }
            set { facilite = value; }
        }

        static public explicit operator double ( CompteBancaire cb ) {
            return cb.solde;
        }

        public Transaction this[int i] {
            get { return listTransaction[i]; }
            set { listTransaction[i] = value; }
        }

        public IEnumerator GetEnumerator () {
            foreach ( Transaction t in listTransaction ) {
                yield return t;
            }
        }

        static public bool operator == ( CompteBancaire x , CompteBancaire y ) {
            return ( x.solde == y.solde );
        }
        static public bool operator != ( CompteBancaire x , CompteBancaire y ) {
            return ( x.solde != y.solde );
        }

        virtual public void CalculInteret () {
            Console.WriteLine( "C => classe mere" );
        }

        public static async Task<List<Transaction>> GetTransaction (CompteBancaire c) {

            List<Transaction> maListe = new List<Transaction>();

            await Task.Run( () => {
                maListe = BankTools.PrintAccounts(c);
            } );

            return maListe;

        }
    }

    static class BankTools {
        static public List<Transaction> PrintAccounts ( CompteBancaire c) {
            return new List<Transaction>();
        }
    }

    class CompteAvue : CompteBancaire {

        public CompteAvue ( string t , string n , uint f ) : base( t , n , f ) { }
        public CompteAvue ( string t , string n ) : base( t , n ) { }

        override public void CalculInteret () {
            Console.WriteLine( "C => classe compteAvue" );
        }

    }
    class CompteEpargne : CompteBancaire {

        public CompteEpargne ( string t , string n , uint f ) : base( t , n , f ) { }
        public CompteEpargne ( string t , string n ) : base( t , n ) { }

        override public void CalculInteret () {
            Console.WriteLine( "C => classe compteEpargne" );
        }

    }
}
