using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver.Builders;
using PathGrad_Console_.Profile;
using PathGrad_Console_.Models;

namespace PathGrad_Console_.Account
{
    class Login
    {
        //Function Contains Login Menu Screen and functionalities
        public static void LoginScreen()
        {

            Console.WriteLine("Login Screen");
            Console.WriteLine("------------------------------");

            //Ask User for ID and Pass
            Console.Write("Student ID: ");
            int userID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Password: ");
            string userPassword = Console.ReadLine();

            //Call Verify Login Function
            if(verifyLogin(userID, userPassword) == true)
            {
                //Initialize Session with Student Values
                Student.ID = userID;
                //Student.name = userName;

                //Console.WriteLine("\nSuccessfully Logged In");
                checkAttempts(userID);
            }
            else
            {
                //Login Fail
                int choice;
                Console.WriteLine("\nLogin Failed");
                Console.WriteLine("Choose one of the following");
                Console.WriteLine("(1) Retry Login");
                Console.WriteLine("(0) Return to Main Menu");

                Console.Write("\n\n Option: ");
                choice = Convert.ToInt32(Console.ReadLine());

                Console.Clear();

                if (choice == 1)
                    LoginScreen();
                else
                    Program.menu();
            }
        }

        //Function verfies if user in database
        public static bool verifyLogin(int ID, string Password)
        {
            //Search Login Database
            bool success = false;

            //Make a connection with DB for Login collection
            var conString = "mongodb://localhost:27017";
            var Client = new MongoClient(conString);
            var DB = Client.GetDatabase("Path_To_Grad");
            var collection = DB.GetCollection<BsonDocument>("Login");

            //Create filter to search through DB
            var filter = new BsonDocument
            {
                {"_id", ID},
                {"password", Password}
            };

            //Search for desired elements
            //If specified user found then add to list
            List<MongoDB.Bson.BsonDocument> list = collection.Find(filter).ToList();
            if (list.Count == 1)
            {
                
                success = true;
            }
            else
                success = false;
            return success;
        }

        public static void checkAttempts(int ID)
        {
            //Make a connection with DB for Login collection
            var conString = "mongodb://localhost:27017";
            var Client = new MongoClient(conString);
            var DB = Client.GetDatabase("Path_To_Grad");
            var collection = DB.GetCollection<BsonDocument>("Login");


            var filter = new BsonDocument
            {
                {"_id", ID},
                {"Login_Attempts", 0}
            };

            //Search for desired elements
            List<MongoDB.Bson.BsonDocument> list = collection.Find(filter).ToList();
            if (list.Count == 1)
            {
                //Initialize Account
                Console.Clear();
                Initialize.setupProfile();
            }
            else
            {
                //Restore Account
            }
                

        }

    }
}
