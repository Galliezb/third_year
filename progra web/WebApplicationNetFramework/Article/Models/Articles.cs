using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Article.Models {
    public class Articles {

        public string Nom { get; set; }
        public string Descriptif { get; set; }
        public bool Promo { get; set; }
        public int IdImg { get; set; }
        public string UniqueIdentifier { get; set; } = "";
        public string ImgSrc { get; set; } = null;

    }
}