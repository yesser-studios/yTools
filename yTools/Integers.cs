using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yTools
{
    public static class Integers
    {
        static List<long> primeNumbers = new();
        static List<long> notPrimeNumbers = new();

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
    }
}
