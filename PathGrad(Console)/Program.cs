using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PathGrad_Console_.Account;
using PathGrad_Console_.Models;

namespace PathGrad_Console_
{
    class Program
    {

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Path to Graduation");
            Console.WriteLine("------------------------------");

            menu();
         
            Console.ReadKey();
        }

        public static void menu()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("------------------------------");
            int userResponse;

            Console.WriteLine("(1) Login");
            Console.WriteLine("(2) Register New Account");
            Console.WriteLine("(3) Forgot Password");
            Console.WriteLine("(0) Back Door");

            Console.Write("\n\n Option: ");
            userResponse = Convert.ToInt32(Console.ReadLine());

            switch (userResponse)
            {
                case 1:
                    Console.Clear();
                    Login.LoginScreen();
                    break;
                case 2:
                    Console.Clear();
                    Register.newUser();
                    break;
                case 3:
                    Console.Clear();
                    ResetPassword.Reset();
                    break;
                case 0:
                    Console.Clear();
                    Backdoor.shortcut();
                    break;
                default:
                    Console.WriteLine("Incorrect option, please choose 1 - 3");
                    break;
            }
        }
    }
}
