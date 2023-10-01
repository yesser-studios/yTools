using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yTools
{
    public static class Strings
    {
        /// <summary>
        /// Writes the given string into the console with a new line at the end.
        /// </summary>
        public static void Write(string text)
        {
            Console.WriteLine(text);
        }

        /// <summary>
        /// Writes the given string into the console without a new line at the end.
        /// </summary>
        public static void WriteWithoutEndLine(string text)
        {
            Console.Write(text);
        }

        /// <summary>
        /// Writes the given string into the console colored with a new line at the end.
        /// </summary>
        public static void WriteColored(string text, ConsoleColor color)
        {
            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = prevColor;
        }

        /// <summary>
        /// Writes the given string into the console colored without a new line at the end.
        /// </summary>
        public static void WriteColoredWithoutEndLine(string text, ConsoleColor color)
        {
            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = prevColor;
        }

        /// <summary>
        /// Joins an array of strings together into one string, without separating the characters.
        /// </summary>
        public static string JoinStrings(params string[] strings)
        {
            string output = "";
            foreach (string item in strings)
            {
                output += item;
            }
            return output;
        }

        /// <summary>
        /// Joins an array of characters together into one string, without separating the characters.
        /// </summary>
        public static string JoinChars(params char[] chars)
        {
            string output = "";
            foreach (char item in chars)
            {
                output += item;
            }
            return output;
        }

        #region LowerUpper
        /// <summary>
        /// Converts the given string to lowercase.
        /// </summary>
        public static string Lower(string text) => text.ToLower();
        /// <summary>
        /// Converts the given string to uppercase.
        /// </summary>
        public static string Upper(string text) => text.ToUpper();
        #endregion

        /// <summary>
        /// Returns true if the given string is equal to null or whitespace.
        /// </summary>
        public static bool IsNullOrWhitespace(string text) => string.IsNullOrWhiteSpace(text);

        /// <summary>
        /// Converts the given IConvertible input to a string value. May return null.
        /// </summary>
        /// <param name="value">The value to convert. Its type must be a descendand of IConvertible.</param>
        /// <returns>A string representation of the given input. May be null.</returns>
        public static string? ToString(IConvertible value) => value.ToString();
    }
}
