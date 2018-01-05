using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.EnterpriseServices;
using System.Runtime.InteropServices;

namespace ServeurCom3
{
    [Transaction(TransactionOption.Required),Guid( "716AFBFC-A6BE-433A-8F75-F79330E4C0D6")]
    public class Personne: ServicedComponent, IPersonne {

        //le COM+ nécessite une interface pour présenter les différentes ressources nécessaire
        // donc on créer une interface lié à Personne via un plugin pour plus de rapiditié ( voir sur le net )
        // obscurateur pour changer le code source décompilable
        //
        /*
         * Ajouter une référence System.entrepriseServices
         * Pas compatible avec le COM présent dans les références
         * AJouter le using system.entrepriseServices
         * Ajouter l'héritage du ServiceComponent
         * Outil => créer un GUID et l'intégrer dans els Transaction
         * Ajouter l'autocomplete sur la méthode enregistrer ( voir la doc )
         * !!! => la dll est conseillé dans la GAC
         * Ajouter les infos dans l'assemblyInfo
         * utiliser les outils VS2017 pour ajouter l'assembly avec regsvsc
         */

        public Personne() {

        }

        public string Nom { get; set; }
        public string Prenom { get; set; }

        // A voir : 
        // un constructeur est peut-être obligatoire
        [AutoComplete]
        public void Enregistrer( string PathName ) {

            // on enregistre le fichie dans le format xml
            // basé sur la classe elle meme ( this )
            StreamWriter sw = new StreamWriter( PathName );
            XmlSerializer xs = new XmlSerializer(typeof(Personne));
            xs.Serialize( sw, this );
            // purge la mémoire
            sw.Flush();
            // ferme le writer
            sw.Close();

        }

    }
}
