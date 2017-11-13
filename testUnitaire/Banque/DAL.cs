using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compteBancaire {

    public interface IDAL {
        Banque RetournerBanque(string nom);
    }

    class DAL:IDAL {

        public Banque RetournerBanque(string nom) {

            return new Banque( 100, nom );

        }

    }
}
