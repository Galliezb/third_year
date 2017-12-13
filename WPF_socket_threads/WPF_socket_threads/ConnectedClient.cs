using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WPF_socket_threads {
    class ConnectedClient {
        public TcpClient TcpConnection { get; set; } = null;
        public Thread Th { get; set; } = null;
        static public int NbrConnection { get; set; } = 0;
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
