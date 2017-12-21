using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace console_test_com {
    class Program {
        public static BindingFlags BindingFLags { get; private set; }

        static void Main(string[] args) {


            String ProgrammeID = "ServeurCom3.Personne";
            String Serveur = "localhost";

            // travaillons par réflectrométrie
            // découverte de la structure du serveur
            Type mType = Type.GetTypeFromProgID( ProgrammeID, Serveur, true );


            // même su le serveur est non dispo, car via la registry il permet de récuéper
            // le GUID
            // c'est la nécessité du Transaction ( TransactionOption ... )
            if ( mType != null) {
                Console.WriteLine( "GUID is {0}.", mType.GUID );

                // ceci ne fonctionnera pas dpeuis qu'on a ajouter une référence
                //Object simpleObjt = Activator.CreateInstance( mType );
                //mType.InvokeMember( "Nom", System.Reflection.BindingFlags.SetProperty, null, simpleObjt, new object[] { "toto" } );
                //mType.InvokeMember( "Prenom", System.Reflection.BindingFlags.SetProperty, null, simpleObjt, new object[] { "dudule" } );
                //mType.InvokeMember( "Enregistrer", System.Reflection.BindingFlags.InvokeMethod, null, simpleObjt, new object[] { @"c:\data\test.txt" } );

                // impossibilité de faire tourner les 2 mécanismes simultanément

                ServeurCom3.Personne simpleObjt = ( ServeurCom3.Personne)Activator.CreateInstance( mType );
                simpleObjt.Nom = "toto";
                simpleObjt.Prenom = "dudule";
                simpleObjt.Enregistrer(@"c:\data\test2.txt");
            }


            Console.ReadKey();
        }
    }
}
