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
using System.Windows.Shapes;

namespace WPF_socket_client {
    /// <summary>
    /// Logique d'interaction pour LogIn.xaml
    /// </summary>
    public partial class LogIn : Window {

        TcpClient connectionToServer;

        public LogIn() {
            InitializeComponent();
        }

        private void Identification(object sender, RoutedEventArgs e) {

            string login = Login.Text.ToString();
            string Password = Pwd.Text.ToString();

            // Data buffer for incoming data.
            byte[] receiveBuffer = new byte[1024];

            // l'hote à contacter
            IPEndPoint remoteEP = new IPEndPoint( IPAddress.Parse( "127.0.0.1" ), 8750 );


            try {

                //connectionToServer = new TcpClient(remoteEP );
                connectionToServer = new TcpClient();
                connectionToServer.Connect( remoteEP );

                // Récupère la réponse du serveur
                int NbrByteReceive = connectionToServer.Client.Receive( receiveBuffer );
                string retour = Encoding.ASCII.GetString( receiveBuffer, 0, NbrByteReceive ).ToString();
                //MessageBox.Show( retour );


                // On va envoyer le LOGIN, PWD et demander une authentification
                byte[] msg = Encoding.ASCII.GetBytes( "LOGIN:" + login + "\r\n" );
                // Envoi les datas via le socket
                int bytesSent = connectionToServer.Client.Send( msg );

                // Récupère la réponse du serveur
                NbrByteReceive = connectionToServer.Client.Receive( receiveBuffer );
                retour = Encoding.ASCII.GetString( receiveBuffer, 0, NbrByteReceive ).ToString();
                //MessageBox.Show( retour );

                msg = Encoding.ASCII.GetBytes( "PWD:" + Password + "\r\n" );
                bytesSent = connectionToServer.Client.Send( msg );

                // Récupère la réponse du serveur
                NbrByteReceive = connectionToServer.Client.Receive( receiveBuffer );
                retour = Encoding.ASCII.GetString( receiveBuffer, 0, NbrByteReceive ).ToString();
                //MessageBox.Show( retour );


                // on demande une identification et on attend une réponse
                msg = Encoding.ASCII.GetBytes( "SAYMEMYFUTUR:" + "\r\n" );
                bytesSent = connectionToServer.Client.Send( msg );

                // Récupère la réponse du serveur
                NbrByteReceive = connectionToServer.Client.Receive( receiveBuffer );
                retour = Encoding.ASCII.GetString( receiveBuffer, 0, NbrByteReceive ).ToString();
                MessageBox.Show( retour );
                string[] reponse = retour.Split( ':' );

                // on est identifié correctement auprès du serveur
                if (reponse.Length > 0 && reponse[1].Substring( 0, 9 ) == "connected") {
                    MessageBox.Show( "Bienvenue " + login );
                    MainWindow m = new MainWindow( connectionToServer, remoteEP, login );
                    m.Show();
                    this.Close();
                } else {
                    displayError.Text = retour;
                }

            } catch (Exception ex) {
                MessageBox.Show( ex.ToString() );
            } finally {
                connectionToServer.Close();

            }
        }
    }
}
