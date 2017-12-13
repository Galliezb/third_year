using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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

namespace WPF_socket_threads {
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        List<ConnectedClient> mesClients = new List<ConnectedClient>();
        Thread th;
        TcpListener listener;

        public MainWindow() {
            InitializeComponent();
        }

        private void ConnectSocket(object sender, RoutedEventArgs e) {

            // on va créer lancer l'acceptation des connexions dans un thread à qui on envoi le listener ouvert
            th = new Thread( GetSocketConnection );
            th.Start();

            // on mets à jours l'interface sur l'état
            statusSocket.Text = "Ouvert";
            statusSocket.Foreground = Brushes.Green;
        }

        private void CloseAllSocket(object sender, RoutedEventArgs e) {

            // mise à jour de l'interface sur le status de la connection
            statusSocket.Text = "Fermé";
            statusSocket.Foreground = Brushes.Red;

            ConnectedClient.NbrConnection=0;
            nbrSocketOuvert.Text = "0";

            // on notifie les clients qu'on va fermer la connection.
            foreach(ConnectedClient c in mesClients) {

                if (c.TcpConnection != null) {
                    // on ferme la connection et on ferme le thread associé
                    c.TcpConnection.Close();
                    c.Th.Abort();
                }

            }

            // arrête le listener
            listener.Stop();
            // stop le thread d'écoute
            th.Abort();

        }

        public void GetSocketConnection() {

            // créer le listener
            listener = new TcpListener( new System.Net.IPEndPoint( IPAddress.Parse( "127.0.0.1" ), 8750 ) );
            // commence à écouter les connections
            listener.Start();

            while ( true ) {

                try {

                    TcpClient mclient = listener.AcceptTcpClient();
                    Thread leThreadClient = new Thread( GestionClient );
                    // on créer un connectedClient et on démarre ele Thread
                    ConnectedClient monClient = new ConnectedClient { TcpConnection = mclient, Th = leThreadClient };
                    leThreadClient.Start( monClient );
                    // stock dans la liste pour gérer plus tard toutes les fermetures par exemple
                    mesClients.Add( monClient );
                    
                    ConnectedClient.NbrConnection++;
                    // ne pouvant pas atteindre l'interface graphique depuis ce Thread
                    // on passe par un délégué anonyme, vive les Action et Func :D
                    this.Dispatcher.Invoke( new Action(() => nbrSocketOuvert.Text = ConnectedClient.NbrConnection.ToString() ) );
                   
                
                // si le programme principale coupe le listener, alors un socketException est levé
                // on utilise cette levé d'exception pour sortir de la boucle et finir le thread
                } catch ( SocketException se) {
                    break;
                }


            }
            // BLOQUANT
            // attend la connection d'un client

            // dès qu'une client se connecte, on va relancer un thread d'écoute pour d'autres clients
            // ainsi on a toujours un socket qui écoute les clients




        }

        public void GestionClient( object o) {

            ConnectedClient cc = (ConnectedClient)o;

            NetworkStream netstream = cc.TcpConnection.GetStream();
            string message = "200 OK";
            byte[] sendbyte = Encoding.ASCII.GetBytes( message );
            netstream.Write( sendbyte, 0, sendbyte.Length );

            int tailleBuffer = 255;
            byte[] monBuffer = new byte[tailleBuffer];
            int bytecount;
            string dataReceive = string.Empty;

            while ( true) {


                // délimite la taille des message à 255 caracatères
                bytecount = netstream.Read( monBuffer, 0, tailleBuffer );


                if ( bytecount != 0 ) {

                    dataReceive += Encoding.ASCII.GetString( monBuffer, 0, bytecount );
                    // si la ligne est terminé, on lance le traitment
                    if (dataReceive.EndsWith("\r\n") ) {

                        sendbyte = Encoding.ASCII.GetBytes( dataReceive );
                        netstream.Write( sendbyte, 0, sendbyte.Length );
                        dataReceive = "";

                    }


                } else {

                    // si le byte vayt 0, a connexion est interrompue, il faudra donc gérer cela
                    // et ensuite il faudra retirer ce thread dans la liste du serveur

                    // on ferme la connection qui n'existe plus
                    cc.TcpConnection.Close();

                    // on retire cette connection de la liste en passant par une méthode dans la programme principal
                    this.Dispatcher.Invoke( new Action(() => DeleteClientFromList(cc)) );

                    // on arrête le thread
                    Thread.CurrentThread.Abort();

                }

            }
            // il faut en glober tout ceci dans un try catch, car si le client ferme la connection
            // soulèvement d'une exce

        }

        private void DeleteClientFromList(ConnectedClient c) {

            int toDelete = mesClients.IndexOf( c );
            mesClients.RemoveAt( toDelete );

        }
    }
}
