using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
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
            byte[] transferByte;
            sendMessageToClient( "CONNECTION: 200 OK" );


            int tailleBuffer = 255;
            byte[] monBuffer = new byte[tailleBuffer];
            int bytecount;
            string dataReceive = string.Empty;

            while ( true) {

                // délimite la taille des message à 255 caracatères
                bytecount = netstream.Read( monBuffer, 0, tailleBuffer );


                // si le byte vaut 0 c'est qu'une déconnection est survenu
                if ( bytecount != 0 ) {

                    dataReceive += Encoding.ASCII.GetString( monBuffer, 0, bytecount );
                    // si la ligne est terminé, on lance le traitment
                    if (dataReceive.EndsWith("\r\n") ) {

                        // renvoi ce qu'on lui a envoyé, c'est pas mal pour tester
                        //transferByte = Encoding.ASCII.GetBytes( dataReceive );
                        //netstream.Write( sendbyte, 0, sendbyte.Length );

                        // on transforme les bytes en string et on traite le retour
                        string[] orders = dataReceive.Split( ':' );

                        if (  orders[0].Length == 0) {
                            sendMessageToClient( "ERROR: incorrect format request" );
                        // vérification login mdp
                        } else if ( orders[0] == "LOGIN" ) {
                            cc.UserName = orders[1].Substring(0,orders[1].Length-2);
                            sendMessageToClient( "Login reception confirm" );
                        } else if (orders[0] == "PWD") {
                            cc.Password = orders[1].Substring( 0, orders[1].Length - 2 );
                            sendMessageToClient( "Password reception confirm" );
                        } else if (orders[0] == "SAYMEMYFUTUR") {

                            if ( cc.UserName != null && cc.Password != null) {

                                socketServerDataContext db = new socketServerDataContext();
                                // !!! renvoi un null si rien n'est trouvé
                                isLoginPasswordGoogResult result = db.isLoginPasswordGoog( cc.UserName, cc.Password ).FirstOrDefault();
                                int id = 0;
                                if ( result!= null) { id = result.id; }

                                if ( id != 0) {
                                    sendMessageToClient( "IDENT:connected with server. Welcome back " + cc.UserName );
                                    cc.IsIdentified = true;
                                    //TODO envoyer vers une fonction de traitement du tchat
                                } else {
                                    sendMessageToClient( "IDENT:Identification failed" );
                                }

                            } else {
                                sendMessageToClient( "ERROR: need login/pwd for identification" );
                            }
                        
                        // renvoi la liste des clients connectés et identifié
                        } else if (orders[0] == "GETLISTUSERCONNECTED") {

                            string toSend = "";
                            foreach( ConnectedClient c in mesClients) {
                                // si pas encore identifié, on n'affiche pas.
                                if ( c.IsIdentified) {
                                    toSend += c.UserName + ";";
                                }
                            }
                            if ( toSend.Length > 0) {
                                toSend = toSend.Substring( 0, toSend.Length - 1 );
                            }
                            sendMessageToClient( toSend );

                        // Envoyer un message vers un autre poste
                        } else if (orders[0] == "SENDMSGTO") {

                            Regex r = new Regex("(.*) (.*)");
                            string[] resultSplit = r.Split( orders[1] );

                            bool destFind = false;

                            foreach ( ConnectedClient c in mesClients) {
                                // destinataire trouvé, on envoi
                                if ( c.UserName == resultSplit[1]) {
                                    destFind = true;
                                    sendMessageToClient( "REP:message send with success" );
                                    break;
                                }
                                
                            }

                            if ( !destFind) {
                                sendMessageToClient( "ERROR:Receiver not found" );
                            }

                        } else {
                            sendMessageToClient( "ERROR:data unreadable" );
                        }

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

            void sendMessageToClient( string message) {
                message += "\r\n";
                transferByte = Encoding.ASCII.GetBytes( message );
                netstream.Write( transferByte, 0, transferByte.Length );
            }

        }

        private void DeleteClientFromList(ConnectedClient c) {

            int toDelete = mesClients.IndexOf( c );
            mesClients.RemoveAt( toDelete );

        }

    }
}
