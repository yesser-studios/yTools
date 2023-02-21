using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yTools
{
    public static class Booleans
    {
        /// <summary>
        /// The true boolean value.
        /// </summary>
        public const bool TRUE = true;

        /// <summary>
        /// The false boolean value.
        /// </summary>
        public const bool FALSE = false;

        /// <summary>
        /// Returns the opposite of the given boolean value.
        /// </summary>
        public static bool Invert(bool input) => !input;
    }
}
