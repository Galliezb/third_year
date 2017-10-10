using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ex03.Models {

    // les noms des propriétés doivent avoir le même nom que les nom du form pour
    // fonctionner sans soucis.

    public class TraiteGet {
        public string pseudo { get; set; }
        public string passwd { get; set; }
        public string bornDate { get; set; }

        //public TraiteGet ( string login , string passwd , string dt ) {
        //    this.pseudo = login;
        //    this.passwd = passwd;
        //    //this.born = DateTime.Parse( dt );
        //    this.bornDate = DateTime.Now;
        //}

        //public TraiteGet() {
        //    this.pseudo = "defaultLogin";
        //    this.passwd = "defaultpwd";
        //    this.bornDate = DateTime.Now;
        //}
    }
}