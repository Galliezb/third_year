using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lesFiltres.Models {
    public class User {
        public string UserName { get; set; }
        public string Passwd { get; set; }
    }
}