using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

namespace client01 {
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow () {
            InitializeComponent();
        }

        private void Identification ( object sender , RoutedEventArgs e ) {

            contactLinqDataContext maco = new contactLinqDataContext();
            ContactIdentificationResult result = maco.ContactIdentification( pseudo.Text , mdp.Password ).FirstOrDefault();

            // idenfitication raté
            if ( result.Column1 == 0 ) {

                errorIdentification.Text = "Erreur : login / mdp incorrect";

                // identification réussi
            } else {

                errorIdentification.Text = "Identification correcte. Bonjour " + pseudo.Text;

                IPEndPoint ipep = new IPEndPoint( IPAddress.Parse( "127.0.0.1" ) , 8000 );
                Socket server = new Socket( AddressFamily.InterNetwork ,
                                  SocketType.Stream , ProtocolType.Tcp );
                server.Connect( ipep );

                if ( server.Connected ) {
                    errorIdentification.Text = "Connexion établi";

                    //Tchat chat = new Tchat();
                    //chat.Show();

                } else {
                    errorIdentification.Text = "ERROR : Connexion non établi";
                }

            }


        }
    }
}
