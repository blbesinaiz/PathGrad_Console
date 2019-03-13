using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathGrad_Console_.Account
{
    class ResetPassword
    {
        public static void Reset()
        {
            //Gather user information
            Console.WriteLine("Reset Password");
            Console.WriteLine("------------------------------");

            Console.Write("\nEnter Student ID associated with account: ");
            int userID = Convert.ToInt32(Console.ReadLine());

            //Create Connection
            var conString = "mongodb://localhost:27017";
            var Client = new MongoClient(conString);
            var DB = Client.GetDatabase("Path_To_Grad");
            var collection = DB.GetCollection<BsonDocument>("Login");

            //Create filter to search through DB
            var filter = new BsonDocument
            {
                {"_id", userID},
            };

            //Search for desired elements
            List<MongoDB.Bson.BsonDocument> list = collection.Find(filter).ToList();
            if (list.Count == 1)
            {
                Console.Write("\nPlease enter in new password: ");
                string newPass = Console.ReadLine();

                var result = collection.FindOneAndUpdateAsync(
                    Builders<BsonDocument>.Filter.Eq("_id", userID),
                    Builders<BsonDocument>.Update.Set("password", newPass)
                    );

                Console.WriteLine("Password Successfully Reset");
                Console.WriteLine("\n\nPress any key to return to Main Menu");
                Console.ReadKey();
                Console.Clear();
                Program.menu();
            }
            else
            {
                Console.WriteLine("Reset Attempt Failed:" +
                    "\n Could not locate user with student ID {0}" +
                    "\n Press any key to return to Main Menu \n", userID);

                Console.ReadKey();
                Console.Clear();
                Program.menu();
            }
        }
    }
}
