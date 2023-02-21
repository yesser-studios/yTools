using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yTools
{
    public static class Doubles
    {
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
    }
}
