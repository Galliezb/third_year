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

        Socket socketSender;

        public MainWindow() {
            InitializeComponent();
        }

        private void ConnectToServer(object sender, RoutedEventArgs e) {

            // Data buffer for incoming data.
            byte[] bytes = new byte[1024];

            // l'hote à contacter
            IPEndPoint remoteEP = new IPEndPoint( IPAddress.Parse("127.0.0.1"), 11000 );
            // Create a TCP/IP  socket.
            socketSender = new Socket( AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp );

            try {
                socketSender.Connect( remoteEP );

                Console.WriteLine( "Socket connected to {0}",
                    socketSender.RemoteEndPoint.ToString() );

                // Encode the data string into a byte array.
                byte[] msg = Encoding.ASCII.GetBytes( "This is a test<EOF>" );

                // Send the data through the socket.
                int bytesSent = socketSender.Send( msg );

                // Receive the response from the remote device.
                int bytesRec = socketSender.Receive( bytes );
                Console.WriteLine( "Echoed test = {0}",
                    Encoding.ASCII.GetString( bytes, 0, bytesRec ) );



            } catch (ArgumentNullException ane) {
                Console.WriteLine( "ArgumentNullException : {0}", ane.ToString() );
            } catch (SocketException se) {
                Console.WriteLine( "SocketException : {0}", se.ToString() );
            } catch (Exception er) {
                Console.WriteLine( "Unexpected exception : {0}", er.ToString() );
            }

        }

        private void DisconnectFromServer(object sender, RoutedEventArgs e) {

            if ( socketSender!= null) {

                // Release the socket.
                socketSender.Shutdown( SocketShutdown.Both );
                socketSender.Close();

            }

        }
    }
}
