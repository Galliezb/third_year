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
using System.Windows.Shapes;

namespace property_collection_changed {
    /// <summary>
    /// Logique d'interaction pour AjouterUtilisateur.xaml
    /// </summary>
    public partial class AjouterUtilisateur : Window {

        Users UserToAdd { get; set; } = new Users();
        ObservableCollection<Users> UserListFromMainWindow = new ObservableCollection<Users>();

        public AjouterUtilisateur ( ObservableCollection<Users> l ) {
            InitializeComponent();
            // recupère la liste depuis mainwindow ( ceci copie la référence ^^ )
            UserListFromMainWindow = l;
            // binding
            DataContext = UserToAdd;
        }

        private void AddUser ( object sender , RoutedEventArgs e ) {

            // generation guid
            UserToAdd.ID = new Guid();

            UserListFromMainWindow.Add( UserToAdd );

            this.Close();

        }
    }
}
