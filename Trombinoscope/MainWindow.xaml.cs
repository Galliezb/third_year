using System;
using System.Collections.Generic;
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
        public GetAllFromUserIdResult UserSelected { get; set; }

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
            UserSelected = new  User2DataContext().GetAllFromUserId(result.Nom,result.Prenom).FirstOrDefault<GetAllFromUserIdResult>();
        }
    }
}
