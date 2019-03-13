using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using PathGrad_Console_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathGrad_Console_.Database
{
    class db
    {
        public class tempStudent
        {
            public int tempID;
            public string tempName;
            public string tempTrack;
            public List<Course> tempCourses;
            public List<Course> tempTaken;

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

            //Give Confirmation
            Console.WriteLine("Profile Successfully saved!");
            Console.WriteLine("Press any key to be directed to Student Profile...");
            Console.ReadKey();

            Console.Clear();

            //Deserealize
            //BlogSites bsObj = JsonConvert.DeserializeObject<BlogSites>(json);
            //https://www.c-sharpcorner.com/article/json-serialization-and-deserialization-in-c-sharp/
        }
    }
}
