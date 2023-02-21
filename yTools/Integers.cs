using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yTools
{
    public static class Integers
    {
        #region MaxValues
        /// <summary>
        /// The maximum number for 16-bit intengers.
        /// </summary>
        public const short maxShort = short.MaxValue;
        /// <summary>
        /// The maximum number for 32-bit intengers.
        /// </summary>
        public const int maxInt = int.MaxValue;
        /// <summary>
        /// The maximum number for 64-bit intengers.
        /// </summary>
        public const long maxLong = long.MaxValue;
        #endregion

        #region MinValues
        /// <summary>
        /// The minimum number for 16-bit intengers.
        /// </summary>
        public const short minShort = short.MinValue;
        /// <summary>
        /// The minimum number for 32-bit intengers.
        /// </summary>
        public const int minInt = int.MinValue;
        /// <summary>
        /// The minimum number for 64-bit intengers.
        /// </summary>
        public const long minLong = long.MinValue;
        #endregion

        /// <summary>
        /// The pi constant.
        /// </summary>
        public const double PI = Math.PI;

        static readonly List<long> primeNumbers = new();
        static readonly List<long> notPrimeNumbers = new();

        /// <summary>
        /// Returns true if the given number is prime.
        /// It will save prompts to lists so it doesn't have to compute the same number every time.
        /// </summary>
        public static bool IsPrime(long number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            if (primeNumbers.Contains(number)) return true;
            if (notPrimeNumbers.Contains(number)) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                {
                    notPrimeNumbers.Add(number);
                    return false;
                }

            primeNumbers.Add(number);
            return true;
        }

        /// <summary>
        /// Returns true if the given number is prime.
        /// </summary>
        public static bool IsPrimeWithoutSaving(long number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }

        /// <summary>
        /// Returns the length of the given array.
        /// </summary>
        public static int Count<T>(T[] array) => array.Length;
    }
}
