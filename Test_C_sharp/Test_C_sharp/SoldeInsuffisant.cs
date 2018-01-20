using System;
using System.Collections.Generic;
using System.Text;

namespace Test_C_sharp {

    class SoldeInsuffisant : Exception {
        public SoldeInsuffisant ( string s ) : base( s ) { }
        public SoldeInsuffisant ( string s , Exception e ) : base( s , e ) { }
    }

}
