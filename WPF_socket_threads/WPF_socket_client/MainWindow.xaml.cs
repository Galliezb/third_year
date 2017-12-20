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
        IPEndPoint remoteEP;

        public MainWindow(TcpClient tmpTcpClient, IPEndPoint tmpRemoteEndPont, string login) {
            LoginRenseigne = login;
            connectionToServer = tmpTcpClient;
            remoteEP = tmpRemoteEndPont;
            InitializeComponent();
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
