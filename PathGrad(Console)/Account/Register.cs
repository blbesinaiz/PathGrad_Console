using MongoDB.Bson;
using MongoDB.Driver;
using PathGrad_Console_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathGrad_Console_.Account
{
    class Register
    {
        public static void newUser()
        {
            //Gather User Information
            Console.WriteLine("Register New Account");
            Console.WriteLine("------------------------------");

            Console.WriteLine("Please Enter the Following Information: \n");

            Console.Write("Student ID: ");
            int userID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Full Name (First Last): ");
            string userName = Console.ReadLine();

            Console.Write("Email: ");
            string userEmail = Console.ReadLine();

            Console.Write("Password: ");
            string userPass = Console.ReadLine();

            int LoginAttempts = 0;

            //Initialize Session with Student Values
            Student.ID = userID;
            Student.name = userName;

            //Create Bson Document
            var document = new BsonDocument
            {
              {"_id", userID},
              {"password", userPass},
              { "name", userName},
              { "email", userEmail},
              { "Login_Attempts", LoginAttempts}
            };

            //Make Connection with database
            var conString = "mongodb://localhost:27017";
            var Client = new MongoClient(conString);
            var DB = Client.GetDatabase("Path_To_Grad");
            var collection = DB.GetCollection<BsonDocument>("Login");

            //Insert into Database
            collection.InsertOne(document);

            //Give Status Update, Redirect to Main Menu
            Console.WriteLine("\n\nUser Successfully Added \nPress Any Key to be Redirected to Main Menu...");
            Console.ReadKey();
            Console.Clear();
            Program.menu();
        }
    }
}
