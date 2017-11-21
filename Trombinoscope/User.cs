using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel;
using System.Collections;

namespace Trombinoscope {
    public class User : INotifyPropertyChanged {

        public int _UserId;
        public string _Nom;
        public string _Prenom;
        public string _Email;
        public string _Tel;
        public string _Adresse;
        public string _CodePostal;
        public string _Ville;


        public int UserId {
            get { return _UserId; }
            set { _UserId = value; OnPropertyChanged( "UserId" ); }
            }
        public string Nom {
            get { return _Nom; }
            set { _Nom = value; OnPropertyChanged( "Nom" ); }
        }
        public string Prenom {
            get { return _Prenom; }
            set { _Prenom = value; OnPropertyChanged( "Prenom" ); }
        }
        public string Email {
            get { return _Email; }
            set { _Email = value; OnPropertyChanged( "Email" ); }
        }
        public string Tel {
            get { return _Tel; }
            set { _Tel = value; OnPropertyChanged( "Tel" ); }
        }
        public string Adresse {
            get { return _Adresse; }
            set { _Adresse = value; OnPropertyChanged( "Adresse" ); }
        }
        public string CodePostal {
            get { return _CodePostal; }
            set { _CodePostal = value; OnPropertyChanged( "CodePostal" ); }
        }
        public string Ville {
            get { return _Ville; }
            set { _Ville = value; OnPropertyChanged( "Ville" ); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String property) {
            if (PropertyChanged != null) {
                PropertyChanged( this, new PropertyChangedEventArgs( property ) );
            }
        }

    }

}
