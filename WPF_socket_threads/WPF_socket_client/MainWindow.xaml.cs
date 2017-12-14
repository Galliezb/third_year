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

namespace WPF_socket_client {
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        internal string LoginRenseigne;
        TcpClient connectionToServer;

        public MainWindow(string login) {
            LoginRenseigne = login;
            InitializeComponent();
        }

        private void ConnectToServer(object sender, RoutedEventArgs e) {

            // Data buffer for incoming data.
            byte[] receiveBuffer = new byte[1024];

            // l'hote à contacter
            IPEndPoint remoteEP = new IPEndPoint( IPAddress.Parse("127.0.0.1"), 8750 );
           

            try {

                //connectionToServer = new TcpClient(remoteEP );
                connectionToServer = new TcpClient();
                connectionToServer.Connect( remoteEP );

                // Encode the data string into a byte array.
                byte[] msg = Encoding.ASCII.GetBytes( "This is a test<EOF>" );

                // Send the data through the socket.
                int bytesSent = connectionToServer.Client.Send( msg );

                // Receive the response from the remote device.
                int NbrByteReceive = connectionToServer.Client.Receive( receiveBuffer );

                connectionStatus.Text = "Server => "+ Encoding.ASCII.GetString( receiveBuffer, 0, NbrByteReceive );
                connectionStatus.Foreground = Brushes.Green;

            } catch (ArgumentNullException ane) {
                connectionStatus.Text = "ArgumeetNullException levée";
                connectionStatus.Foreground = Brushes.Red;
            } catch (Exception er) {
                connectionStatus.Text = "Exception levée";
                connectionStatus.Foreground = Brushes.Red;
            } finally {
                connectionToServer.Close();

            }

        }

        private void DisconnectFromServer(object sender, RoutedEventArgs e) {

            if (connectionToServer != null) {

                // Release the socket.
                connectionToServer.Client.Shutdown( SocketShutdown.Both );
                connectionToServer.Client.Close();

            }

        }
    }
}
