using System;
using System.Collections.Generic;
using System.Text;

namespace Enumeration
{
    class GaragePleinException:ApplicationException
    {
        public GaragePleinException() : base() { }
        public GaragePleinException(string message) : base( message ) { }
        public GaragePleinException(string message, Exception inner) : base(message,inner) { }
    }
}
