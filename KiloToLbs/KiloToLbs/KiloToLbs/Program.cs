using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiloToLbs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an amount of kilos to be converted to pounds");

            string input = Console.ReadLine();

            int kilos = Convert.ToInt32(input);

            int pounds = Convert.ToInt32(kilos * 2.2046226218);

            Console.Clear();

            Console.WriteLine(kilos + " kilos converted to pounds is approximately");

            Console.WriteLine(pounds + " lbs");

            Console.ReadKey();
        }
    }
}
