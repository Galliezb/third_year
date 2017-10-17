using System;
using System.Collections.Generic;
using System.Text;

namespace methodes_extensions {
    class StackEmptyException : ApplicationException {

        public StackEmptyException() : base() { }
        public StackEmptyException(string message) : base(message) { }

    }
}
