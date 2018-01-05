using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace property_collection_changed {
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public Users UserSelected { get; set; }
        public Users TmpUserForUpdate { get; set; }

        public ObservableCollection<Users> ListUtilisateur { get; set; }

        public MainWindow () {

            InitializeComponent();

            // initialisation des variables publiques
            UserSelected = new Users { ID = new Guid() , Nom = "" , Prenom = "" };
            ListUtilisateur = new ObservableCollection<Users>();

            // Ajout des infos depuis la BDD
            // ici on les crée à la volé pour simplifier
            ListUtilisateur.Add( new Users { ID = new Guid() , Nom = "Adrien" , Prenom = "IsTheBest" } );
            ListUtilisateur.Add( new Users { ID = new Guid() , Nom = "Kahim" , Prenom = "IsBetter" } );
            ListUtilisateur.Add( new Users { ID = new Guid() , Nom = "Bruno" , Prenom = "IsCraignos" } );
            ListUtilisateur.Add( new Users { ID = new Guid() , Nom = "Norbert" , Prenom = "IsTooStrange" } );

            // On va dire que notre DataContext est notre classe
            // on aura donc accès en XAML a SelectedUser et ListUtilisateur
            DataContext = this;


        }

        private void UpdateUser ( object sender , RoutedEventArgs e ) {

            // on récupère l'index dans la liste
            int index = ListUtilisateur.IndexOf( TmpUserForUpdate );

            if ( index != -1 ) {

                // on mets à jour l'utilisateur par les SETTERS pour soulever l'event
                ListUtilisateur[index].ID = UserSelected.ID;
                ListUtilisateur[index].Nom = UserSelected.Nom;
                ListUtilisateur[index].Prenom = UserSelected.Prenom;

            } else {

                MessageBox.Show( "Error, User not found in list" );

            }



        }

        private void ChangementDeSelectionDansLaListeBox ( object sender , SelectionChangedEventArgs e ) {

            // on cast en listbox pour récupérer l'item selectionné
            ListBox l = (ListBox) sender;
            // on récupère l'user qui est selectionné par la listebox
            Users u = (Users)l.SelectedItem;
            // va permettre de chercher dans la liste en mode easy ensuite
            TmpUserForUpdate = u;

            // On modifiant les propriété ( les SET{} ) l'evenement sera soulevé
            // donc l'interface sera notifié
            UserSelected.ID = u.ID;
            UserSelected.Nom = u.Nom;
            UserSelected.Prenom = u.Prenom;

        }

        private void AjoutUtilisateur ( object sender , RoutedEventArgs e ) {

            // nouvelle fenetre a qui on envye la référence de la liste ^^
            AjouterUtilisateur a = new AjouterUtilisateur( ListUtilisateur );
            // ou showdialog selon les préférences
            a.Show();


        }
    }
}
