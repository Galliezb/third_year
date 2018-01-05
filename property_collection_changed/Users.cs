using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace property_collection_changed {
    public class Users : INotifyPropertyChanged {

        // variables privées pour contenir la data
        private Guid _ID { get; set; }
        private string _Nom { get; set; }
        private string _Prenom { get; set; }


        public Users(){
            _ID = new Guid();
            _Nom = "constructor";
            _Prenom = "constructor";
        }

        // les accesseurs public pour levé la notification quand on change la valeur
        public Guid ID {
            get { return _ID; }
            set {

                _ID = value;
                MaProprieteVientDeChanger( "ID" );

            }
        }
        // les accesseurs public pour levé la notification quand on change la valeur
        public string Nom {
            get { return _Nom; }
            set {

                _Nom = value;
                MaProprieteVientDeChanger( "Nom" );

            }
        }
        // les accesseurs public pour levé la notification quand on change la valeur
        public string Prenom {
            get { return _Prenom; }
            set {

                _Prenom = value;
                MaProprieteVientDeChanger( "Prenom" );

            }
        }

        // Le truc à copier coller :D qui gère nos events
        public event PropertyChangedEventHandler PropertyChanged;
        protected void MaProprieteVientDeChanger ( string name ) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if ( handler != null ) {
                handler( this , new PropertyChangedEventArgs( name ) );
            }
        }
    }
}
