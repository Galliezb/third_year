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

        public List<GetListOfUsersResult> UsersList { get; set; }
        public GetAllFromUserIdResult UserSelected { get; set; } = new GetAllFromUserIdResult();

        public MainWindow() {
            InitializeComponent();
            User2DataContext DBUsers = new User2DataContext();
            UsersList = DBUsers.GetListOfUsers().ToList();
            DataContext = this;
        }


        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            Console.WriteLine( "Event recepetion" );
            ListBox lb = (ListBox)sender;
            GetListOfUsersResult result = (GetListOfUsersResult)lb.SelectedItem;

            // testons avec les setters
            //UserSelected = new  User2DataContext().GetAllFromUserId(result.UserId).FirstOrDefault<GetAllFromUserIdResult>();
            GetAllFromUserIdResult tmp = new User2DataContext().GetAllFromUserId(result.UserId).FirstOrDefault<GetAllFromUserIdResult>();

            UserSelected.Nom = tmp.Nom;
            UserSelected.Prenom = tmp.Prenom;
            UserSelected.Email = tmp.Email;
            UserSelected.tel = tmp.tel;
            UserSelected.Rue = tmp.Rue;
            UserSelected.codePostal = tmp.codePostal;
            UserSelected.Ville = tmp.Ville;

        }
    }
}
