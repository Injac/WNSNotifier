using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WNSNotifier.DataValidation
{
    class DataValidator
    {

        /// <summary>
        /// Determines whether the specified string to test is numeric.
        /// </summary>
        /// <param name="stringToTest">The string to test.</param>
        /// <returns></returns>
        public static Boolean IsNumeric(string stringToTest)
        {

            int result;

            return int.TryParse(stringToTest, out result);

        }


        /// <summary>
        /// Determines whether [is well formed uir] [the specified URI].
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns></returns>
        public static Boolean IsWellFormedUri(string uri)
        {

            // regex pattern for url validation string
            
            if (Uri.IsWellFormedUriString(uri,UriKind.Absolute))
            {
                return true;
            }
            else
            {
                return false;
            }


        }

    }
}
