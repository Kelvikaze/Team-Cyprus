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
            bool converting = true;

            while (converting)
            {


                Console.WriteLine("Enter an amount of kilos to be converted to pounds");

                string input = Console.ReadLine();

                int kilos = Convert.ToInt32(input);

                int pounds = Convert.ToInt32(kilos * 2.2046226218);

                Console.Clear();

                Console.WriteLine(kilos + " kilos converted to pounds is approximately");

                Console.WriteLine(pounds + " lbs");

                Console.ReadKey();

                Console.Clear();

                converting = PromptDone();
            }
        }

        static bool PromptDone()
        {
            Console.WriteLine("Continue converting kilos to pounds? (Y to continue, N to quit");

            string answer = Console.ReadLine();

            Console.Clear();

            if (answer.ToLower().Contains('n'))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
