using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testDiversPersos.Models {
    public class Transaction {
        public int ID { get;set; }
        public int IDUserEmitter { get;set; }
        public int IDUserReceiver { get;set; }
        public int Amount { get;set; }
    }
}