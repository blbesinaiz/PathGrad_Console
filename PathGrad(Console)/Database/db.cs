using MongoDB.Bson;
using MongoDB.Bson.Serialization;
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
    class db
    {
        /*public class tempStudent
        {
            public int tempID;
            public string tempName;
            public string tempTrack;
            public List<Course> tempCourses;
            public List<Course> tempTaken;

        }*/

        public class tempProfile
        {
            public int id;
            public string studentData;
        }

        public static void newUser()
        {
            //Create instance of class and assign values
            tempStudent t = new tempStudent();

            t.tempID = Student.ID;
            t.tempName = Student.name;
            t.tempTrack = Student.track;
            t.tempCourses = Student.courseList;
            t.tempTaken = Student.takenCourses;

            //Serialize Object (JSON.NET method)
            string jsonData = JsonConvert.SerializeObject(t);

            Console.WriteLine("Serialized Student Object:\n {0}", JsonConvert.SerializeObject(t, Formatting.Indented));

            //Insert into database

            //Create Bson Document
            var document = new BsonDocument
            {
              {"_id", t.tempID},
              {"profile", jsonData}
            };

            //Make Connection with database
            var conString = "mongodb://localhost:27017";
            var Client = new MongoClient(conString);
            var DB = Client.GetDatabase("Path_To_Grad");
            var collection = DB.GetCollection<BsonDocument>("Student_Profiles");

            //Insert into Database
            collection.InsertOne(document);

            /*
            //Database not working so save to text file!!
            string filename = Student.ID.ToString() + ".txt";
            var writer = new StreamWriter(File.OpenWrite(filename));
            writer.WriteLine(jsonData);
            writer.Close();
            */

            //Give Confirmation
            Console.WriteLine("Profile Successfully saved!");
            Console.WriteLine("Press any key to be directed to Student Profile...");
            Console.ReadKey();

            Console.Clear();

            
            //https://www.c-sharpcorner.com/article/json-serialization-and-deserialization-in-c-sharp/
        }

        public static void restoreSession()
        {
            //string filename = Student.ID.ToString() + ".txt";
            //var reader = new StreamReader(File.OpenRead(filename));
            //string contents = File.ReadAllText(filename);

            //Make Instance of tempStudent Object
            tempStudent temp = new tempStudent();

            //Make Connection with database
            var conString = "mongodb://localhost:27017";
            var Client = new MongoClient(conString);
            var DB = Client.GetDatabase("Path_To_Grad");
            var collection = DB.GetCollection<BsonDocument>("Student_Profiles");

            //Query Database
            var filter = new BsonDocument
            {
                {"_id", Student.ID}
            };
            List<MongoDB.Bson.BsonDocument> list = collection.Find(filter).ToList();

            //Deserealize
            var holder = list[0]["profile"].ToString();
            temp = JsonConvert.DeserializeObject<tempStudent>(holder);

            //Reasign to Student in program
            Student.ID = temp.tempID;
            Student.name = temp.tempName;
            Student.track = temp.tempTrack;
            Student.courseList = temp.tempCourses;
            Student.takenCourses = temp.tempTaken;

            Console.Clear();
        }
    }
}
