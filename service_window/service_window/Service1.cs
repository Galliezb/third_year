using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace service_window {
    public partial class Service1 : ServiceBase {

        private Thread th;


        public Service1() {
            InitializeComponent();
        }

        protected override void OnStart(string[] args) {

            // un service n'est qu'un Thread qui tourne en tâche de fond
            th = new Thread(new ThreadStart(Traitement)); 

        }

        private void Traitement() {

            while (true) {

                try {
                
                // capture l'exception levée lors du th.abort();
                } catch ( Exception ex) {

                }

            }

        }

        protected override void OnStop() {
            th.Abort();
            th = null;
        }
    }
}
