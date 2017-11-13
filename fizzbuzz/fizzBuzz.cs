using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSfizzbuzz {
    static public class FizzBuzz {

        static public string GetFizzBuzz(int nb) {

            string toReturn = string.Empty;
            bool fizz = nb % 3 == 0;
            bool buzz = nb % 5 == 0;

            if ( fizz && buzz) {
                return "fizzbuzz";
            } else if ( fizz && !buzz) {
                return "fizz";
            } else if ( !fizz && buzz) {
                return "buzz";
            } else {
                return "Quedal";
            }

        }

    }
}
