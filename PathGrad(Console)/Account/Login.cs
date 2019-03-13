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
using PathGrad_Console_.Database;

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
                updateAttempts(userID);

                //After settingup/restore session, transition to student profile page
                MainPage.welcomePage();
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

        //Function determines if intial login
        //If initial, then initialize student profile
        //If not, update login attempt and restore session
        public static void updateAttempts(int ID)
        {
            //Make a connection with DB for Login collection
            var conString = "mongodb://localhost:27017";
            var Client = new MongoClient(conString);
            var DB = Client.GetDatabase("Path_To_Grad");
            var collection = DB.GetCollection<BsonDocument>("Login");


            var filter = new BsonDocument
            {
                {"_id", ID},
                {"Initial_Login", 1}
            };

            //Search for desired elements
            List<MongoDB.Bson.BsonDocument> list = collection.Find(filter).ToList();
            if (list.Count == 1)
            {
                //Initialize Account
                Console.Clear();
                Initialize.setupProfile();

                //Take off initial login
                string param = "{$set: { 'Initial_Login' : '0' } }";
                string filter2 = "{ '_id' : " + ID + " }";

                BsonDocument filterDoc = BsonDocument.Parse(filter2);
                BsonDocument document = BsonDocument.Parse(param);
                collection.UpdateOne(filterDoc, document);

            }
            else
            {
                //Restore Account
                db.restoreSession();

            }
        }
    }
}
