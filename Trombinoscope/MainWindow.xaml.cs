using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Trombinoscope {
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        // Les collections observable intègre directement le Inotifypropiety et Icollectionchanged
        // nous permettant de gérer directement les changement de propriété et collection
        // pour mettre à jour nos vus via le binding.
        public MonObservableCollection<Users> UsersList { get; set; } = new MonObservableCollection<Users>();
        public Users UserSelected { get; set; } = new Users();

        public MainWindow() {
            InitializeComponent();
            User2DataContext DBUsers = new User2DataContext();
            List<Users> l = DBUsers.GetListOfUsers().ToList();
            foreach ( Users u in l ) {
                UsersList.Add( u );
            }
            DataContext = this;

        }


        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            Console.WriteLine( "Event recepetion" );
            ListBox lb = (ListBox)sender;
            Users result = (Users)lb.SelectedItem;


            // testons avec les setters
            //UserSelected = new  User2DataContext().GetAllFromUserId(result.UserId).FirstOrDefault<GetAllFromUserIdResult>();
            Users tmp = new User2DataContext().GetAllFromUserId(result.UserId).FirstOrDefault<Users>();

            UserSelected.UserId = tmp.UserId;
            UserSelected.Nom = tmp.Nom;
            UserSelected.Prenom = tmp.Prenom;
            UserSelected.Email = tmp.Email;
            UserSelected.Tel = tmp.Tel;
            UserSelected.Adresse = tmp.Adresse;
            UserSelected.CodePostal = tmp.CodePostal;
            UserSelected.Ville = tmp.Ville;

        }

        private void UpdateDbUser(object sender, RoutedEventArgs e) {

            //User2DataContext context = new User2DataContext();
            // récupère l'int pour le retour et vérification en mode débogage que tout est ok de ce côté ci
            //int retour = context.UpdateUser( UserSelected.UserId, UserSelected.Nom, UserSelected.Prenom, UserSelected.Email, UserSelected.Tel,
            //                                 UserSelected.Adresse, UserSelected.CodePostal, UserSelected.Ville );

            // pour modifier les items de la liste
            // on peut créer une classe partial GetListOFUser : InotifyInterface
            // Mettre à jour la liste pour que le cote gauche puisse se mettre à jour

            // en injectant la table dans Linq on obtient une classe "Users" qui intègre le InotifyPropertyChanged
            // en allant dans les propriétés des procédures stockées, on peut demander à ce que le retour d'une procédure soit
            // stocké dans un type particulière ( ici la classe linq généré par le drag and drop de la table )
            // TODO => pas encore réussi à le faie intégrer dans une des mes classes

            int indexOf = UsersList.UsersList.IndexOf( UserSelected );
            if ( indexOf != -1 ) {
                UsersList.UsersList[indexOf].UserId = UserSelected.UserId;
                UsersList.UsersList[indexOf].Nom = UserSelected.Nom;
                UsersList.UsersList[indexOf].Prenom = UserSelected.Prenom;
                UsersList.UsersList[indexOf].Email = UserSelected.Email;
                UsersList.UsersList[indexOf].Tel = UserSelected.Tel;
                UsersList.UsersList[indexOf].Adresse = UserSelected.Adresse;
                UsersList.UsersList[indexOf].CodePostal = UserSelected.CodePostal;
                UsersList.UsersList[indexOf].Ville = UserSelected.Ville;
            }


        }

        private void AddUser(object sender, RoutedEventArgs e) {
            Ajouter maFenetreAjoutUser = new Ajouter( UsersList );
            maFenetreAjoutUser.ShowDialog();
        }

        // Permet de supprimer un utilisateur depuis son ID grace au menu contextuel
        private void DeleteUser(object sender, RoutedEventArgs e) {

            MenuItem menuClicked = (MenuItem) sender;
            int idToDelete = Convert.ToInt32( menuClicked.Tag );

            User2DataContext u2 = new User2DataContext();
            u2.DeleteUser( idToDelete );


        }

        // TODO
        // * Modfier les données d'un utilisateur sélectionné
        // * Ajouter un nouvelle utilisateur avec une nouvelle vue + Photo
        // Ex 2 Données complètes, listes et détails automatique ( ce qui est déjà présente non ? )
        // TODO
        // * Check Source="{Binding Path=Photo,Converter={}}"
        // ajouter une photo directement en SQL :
        // SELECT MyImage.* from Openrowset(Bulk 'C:\data\trump.png', Single_Blob MyImage) WHERE ........
    }

}
