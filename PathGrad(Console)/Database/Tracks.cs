using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using PathGrad_Console_.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathGrad_Console_.Database
{
    class Tracks
    {
        public static void Upload()
        {
            //Get CSV to convert
            string path;        //Variable will hold path
            string track = "BS.CSC.IA";

            //Find file
            path = Directory.GetCurrentDirectory();
            path = path + @"\Tracks\" + track + ".csv";

            tempStudent temp = new tempStudent();

            //Load CSV into Student Course List
            try
            {

                // List<Course> values = File.ReadAllLines(path)
                temp.tempCourses = File.ReadAllLines(path)
                                        .Skip(1)
                                        .Select(v => Course.FromCsv(v))
                                        .ToList();
            }

            catch (Exception e)
            {
                Console.WriteLine("The file could not be read: ");
                Console.WriteLine(e.Message);
            }

            //Save CSV into Mongo DB

            //Serialize Object (JSON.NET method)
            string jsonData = JsonConvert.SerializeObject(temp);

            //Create Bson Document
            var document = new BsonDocument
            {
              {"_id", track},
              {"curriculum", jsonData}
            };

            //Insert into MongoDB
            //Make Connection with database
            var conString = "mongodb://localhost:27017";
            var Client = new MongoClient(conString);
            var DB = Client.GetDatabase("Path_To_Grad");
            var collection = DB.GetCollection<BsonDocument>("Tracks");

            //Insert into Database
            collection.InsertOne(document);

            //Give confirmation
            Console.WriteLine("Successfully Inserted {0} into database", track);
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
            Console.Clear();
            Program.menu();

        }
    }
}
