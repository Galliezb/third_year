using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServeurCom3 {
    public interface IPersonne {

        string Nom { get; set; }
        string Prenom { get; set; }

        void Enregistrer(string PathName);

    }
}
