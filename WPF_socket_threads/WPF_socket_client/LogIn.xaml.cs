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
using System.Windows.Shapes;

namespace WPF_socket_client {
    /// <summary>
    /// Logique d'interaction pour LogIn.xaml
    /// </summary>
    public partial class LogIn : Window {
        public LogIn() {
            InitializeComponent();
        }

        private void Identification(object sender, RoutedEventArgs e) {

            string login = Login.Text.ToString();

            if (login.Length > 5) {
                MainWindow ma = new MainWindow( login );
                ma.Show();
                this.Close();
            }
        }
    }
}
