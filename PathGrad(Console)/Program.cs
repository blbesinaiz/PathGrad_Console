using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PathGrad_Console_.Account;
using PathGrad_Console_.Database;
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
            Console.WriteLine("(4) Upload new curriculum");
            Console.WriteLine("(5) Exit");
            //Console.WriteLine("(0) Back Door");

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
                case 4:
                    Console.Clear();
                    Tracks.Upload();
                    break;
                case 5:
                    Console.WriteLine("Happy Journeys");
                    Console.ReadKey();
                    System.Environment.Exit(0);
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

        public static void uplodadTrack()
        {
            Console.WriteLine("Please provide the file path of file to upload");
            string path = Console.ReadLine();


        }
    }
}
