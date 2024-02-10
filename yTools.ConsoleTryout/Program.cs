using System.Globalization;

namespace yTools.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Doubles.MaxDouble.ToString(CultureInfo.InvariantCulture));
        }
    }
}