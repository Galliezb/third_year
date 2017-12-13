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

namespace WPF_serveur {
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        List<MesClients> mesClientConnecte = new List<MesClients>();
        TcpListener listener;
        int test = 0;


        public MainWindow () {
            InitializeComponent();

            //NetworkStream stream = myclient.GetStream();
            //string message = "200 ok \n";
            //byte[] sendbyte = Encoding.ASCII.GetBytes( message );
            //stream.Write( sendbyte , 0 , sendbyte.Length );
            //myclient.Close();
            //listener.Stop();


        }

        private void StartListener ( object sender , RoutedEventArgs e ) {

            // affiche l'état du listener
            statusListener.Text = "Listener à l'écoute";
            statusListener.Foreground = Brushes.Green;

            // instancie le listener qui écoute toutes les interfaces réseaux ( . any )
            listener = new TcpListener( new IPEndPoint( IPAddress.Any , 8000 ) );
            listener.Start();

            Thread th = new Thread( GetClientConnection );
            th.Start();

        }
        private void StopListener ( object sender , RoutedEventArgs e ) {

            // affiche l'état du listener
            statusListener.Text = "Listener fermé";
            statusListener.Foreground = Brushes.Red;

            // fermeture de tous les clients
            lock ( mesClientConnecte ) {
                foreach ( MesClients ms in mesClientConnecte ) {

                    ms.Tcpclient.Close();
                    ms.Th.Abort();

                }
                MesClients.Cpt = 0;
                // fermeture du listener
                listener.Stop();

            }


        }

        public void GetClientConnection () {

            
            while ( true ) {

                // on stock la connexion cliente
                TcpClient myclient = listener.AcceptTcpClient();
                // pour mettre à jour l'interface depuis un thread
                nbrClientConnecte.Dispatcher.Invoke( UpdateInterfaceNbrClientConnected );

                // on lock la liste et on inscrit le nouveau client dedans
                lock ( mesClientConnecte ) {

                    MesClients.Cpt++;

                    mesClientConnecte.Add( new MesClients {
                        Th = new Thread( new ThreadStart( GestionTchatClient ) ) ,
                        Tcpclient = myclient
                    } );

                }

            }


        }

        public void UpdateInterfaceNbrClientConnected () {
            nbrClientConnecte.Text = MesClients.Cpt.ToString()+ " / "+ test.ToString();
        }

        public void GestionTchatClient () {

            // WO WO WO, t'es ki toi d'abord ?

             
            while ( true ) {

                Thread.Sleep( 1000 );
                this.Dispatcher.Invoke( SendMessageToClient() );
            }

        }


    }
}
