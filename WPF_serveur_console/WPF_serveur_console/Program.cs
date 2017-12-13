using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WPF_serveur_console {
    class Program {

        static List<TcpClient> mesClientConnecte = new List<TcpClient>();

        static void Main ( string[] args ) {


            // instancie le listener qui écoute toutes les interfaces réseaux ( . any )
            TcpListener listener = new TcpListener( new IPEndPoint( IPAddress.Any , 8000 ) );
            listener.Start();
            TcpClient myclient = listener.AcceptTcpClient();

            NetworkStream stream = myclient.GetStream();
            string message = "200 ok \n";
            byte[] sendbyte = Encoding.ASCII.GetBytes( message );
            stream.Write( sendbyte , 0 , sendbyte.Length );
            myclient.Close();
            listener.Stop();

            Console.ReadKey();

        }

        //public TcpClient GetClient ( TcpListener listener ) {

        //    listener.Start();
        //    TcpClient myclient = listener.AcceptTcpClient();

        //    return myclient;
        //}
    }
}
