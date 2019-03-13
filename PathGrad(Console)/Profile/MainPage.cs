using PathGrad_Console_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathGrad_Console_.Profile
{
    class MainPage
    {
        public static void welcomePage()
        {
            Console.WriteLine("Welcome {0}", Student.name);
            Console.WriteLine("-------------------------");

            Console.WriteLine("\n\n Student Menu");
            Console.WriteLine("-------------------------");

            Console.WriteLine("Please Choose an Option: ");
            Console.WriteLine("(1) Generate Perfect Path");
            Console.WriteLine("(2) View Previous Perfect Path");
            Console.WriteLine("(3) Develop an Alternate Path to Graduation");
            Console.WriteLine("(4) What-If Central");
            Console.WriteLine("(0) Exit");

            int userOption = Convert.ToInt32(Console.ReadLine());

            switch (userOption)
            {
                case 1: //Generate perfect path
                    break;
                case 2: //View Previous perfect path generations
                    break;
                case 3: //Develop alternat paths to graduation
                    break;
                case 4: //What-If central
                    break;
                case 0: //Exit
                    break;
                default: //Bad selection
                    break;
            }
        }
        
    }
}
