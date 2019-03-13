using Newtonsoft.Json;
using PathGrad_Console_.Models;
using PathGrad_Console_.Profile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathGrad_Console_
{
    class Backdoor
    {
        public class tempStudent
        {
            public int tempID;
            public string tempName;
            public string tempTrack;
            public List<Course> tempCourses;
            public List<Course> tempTaken;

        }
        public static void shortcut()
        {
            string filename = "337140.txt";
            //var reader = new StreamReader(File.OpenRead(filename));
            string contents = File.ReadAllText(filename);

            //Make Instance of tempStudent Object
            tempStudent temp = new tempStudent();

            //Deserealize
            temp = JsonConvert.DeserializeObject<tempStudent>(contents);

            //Reasign to Student in program
            Student.ID = temp.tempID;
            Student.name = temp.tempName;
            Student.track = temp.tempTrack;
            Student.courseList = temp.tempCourses;
            Student.takenCourses = temp.tempTaken;

            Console.Clear();

            MainPage.welcomePage();
        }
    }
}
