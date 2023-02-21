using System;

namespace yTools
{
    public static class Doubles
    {
        #region MaxValues
        /// <summary>
        /// The maximum number for 32-bit decimals.
        /// </summary>
        public const float maxFloat = float.MaxValue;
        /// <summary>
        /// The maximum number for 64-bit decimals.
        /// </summary>
        public const double maxDouble = double.MaxValue;
        /// <summary>
        /// The maximum number for 128-bit decimals.
        /// </summary>
        public const decimal maxDecimal = decimal.MaxValue;
        #endregion

        #region MinValues
        /// <summary>
        /// The minimum number for 32-bit decimals.
        /// </summary>
        public const float minFloat = float.MinValue;
        /// <summary>
        /// The minimum number for 64-bit decimals.
        /// </summary>
        public const double minDouble = double.MinValue;
        /// <summary>
        /// The minimum number for 128-bit decimals.
        /// </summary>
        public const decimal minDecimal = decimal.MinValue;
        #endregion

        /// <summary>
        /// Returns the average of the given number array.
        /// </summary>
        public static double Average(double[] nums)
        {
            double sum = Sum(nums);
            int count = Integers.Count(nums);
            double result = sum / count;
            return result;
        }
        /// <summary>
        /// Returns the sum of the given number array.
        /// </summary>
        public static double Sum(double[] nums)
        {
            double sum = 0;
            foreach (double item in nums)
            {
                sum += item;
            }
            return sum;
        }
        
        /// <summary>
        /// Returns the highest number of the given number array.
        /// </summary>
        public static double Max(double[] nums)
        {
            double max = nums[0];
            for (int i = 0; i < Integers.Count(nums); i++)
            {
                foreach (int item in nums)
                {
                    if (max < item)
                    {
                        max = item;
                    }
                }
            }
            return max;
        }
        /// <summary>
        /// Returns the lowest number of the given number array.
        /// </summary>
        public static double Min(double[] nums)
        {
            double min = nums[0];
            for (int i = 0; i < Integers.Count(nums); i++)
            {
                foreach (int item in nums)
                {
                    if (min > item)
                    {
                        min = item;
                    }
                }
            }
            return min;
        }

        #region Arithmetic
        /// <summary>
        /// Returns num1 to the power of num2 (num1^num2).
        /// </summary>
        public static double Power(double num1, double num2)
            => Math.Pow(num1, num2);

        /// <summary>
        /// Returns the square root of the given number.
        /// </summary>
        public static double SquareRoot(double number)
            => Math.Sqrt(number);

        /// <summary>
        /// Returns the cube root of the given number.
        /// </summary>

        public static double CubeRoot(double number)
            => Math.Cbrt(number);

        /// <summary>
        /// Returns num1 + num2.
        /// </summary>
        public static double Add(double num1, double num2) => num1 + num2;

        /// <summary>
        /// Returns num1 - num2.
        /// </summary>
        public static double Substract(double num1, double num2) => num1 - num2;

        /// <summary>
        /// Returns num1 × num2.
        /// </summary>
        public static double Multiply(double num1, double num2) => num1 * num2;

        /// <summary>
        /// Returns num1 ÷ num2.
        /// </summary>
        public static double Divide(double num1, double num2) => num1 / num2;

        /// <summary>
        /// Returns the remainder after the division of num1 ÷ num2.
        /// </summary>
        public static double Remainder(double num1, double num2) => num1 % num2;
        #endregion
    }
}
