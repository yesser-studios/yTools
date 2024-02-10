using System.Globalization;

namespace yTools.ConsoleTryout
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Doubles.MaxDouble.ToString(CultureInfo.InvariantCulture));
        }
    }
}