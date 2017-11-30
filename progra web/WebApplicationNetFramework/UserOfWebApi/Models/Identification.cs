using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserOfWebApi.Models {
    public class Identification {
        public string Login { get; set; }
        public string Token { get; set; }
    }
}