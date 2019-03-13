using Newtonsoft.Json;
using PathGrad_Console_.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace PathGrad_Console_.Profile
{
    class Save
    {
        public class tempStudent
        {
            public int tempID;
            public string tempName;
            public string tempTrack;
            public List<Course> tempCourses;
            public List<Course> tempTaken;

        }

        //public tempStudent t = new tempStudent();
        public static void serialize()
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

            //Deserealize
            //BlogSites bsObj = JsonConvert.DeserializeObject<BlogSites>(json);
            //https://www.c-sharpcorner.com/article/json-serialization-and-deserialization-in-c-sharp/
        }

    }


}
