using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ex03.Models {
    public class TraiteGet {
        public string login { get; set; }
        public string passwd { get; set; }
        public DateTime born { get; set; }

        public TraiteGet ( string login , string passwd , string dt ) {
            this.login = login;
            this.passwd = passwd;
            //this.born = DateTime.Parse( dt );
            this.born = DateTime.Now;
        }
    }
}