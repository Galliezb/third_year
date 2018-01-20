using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_ex_janvier_2018.Models {
    public class MVM {

        public List<GetAllResult> Tout { get;set; }
        public List<GetAllGenreResult> ListGenre { get;set; }
        public List<GetCollectionResult> ListCollection { get;set; }

    }
}