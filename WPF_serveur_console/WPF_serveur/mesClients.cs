using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WPF_serveur {
    class MesClients {

        public static int Cpt { get; set; } = 0;
        public TcpClient Tcpclient { get; set; }
        public Thread Th { get; set; }
        public string Nom { get; set; }
        public Guid Userid { get; set; }


        public void SendMessageToClient ( string message ) {
            try {
                NetworkStream stream = Tcpclient.GetStream();
                byte[] sendbyte = Encoding.ASCII.GetBytes( message );
                stream.Write( sendbyte , 0 , sendbyte.Length );
            } catch ( Exception e ) {
                Console.WriteLine( "TcpClient n'est pas défini" );
            }

        }
    }
}
