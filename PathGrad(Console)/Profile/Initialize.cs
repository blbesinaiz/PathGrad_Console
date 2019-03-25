using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using PathGrad_Console_.Database;
using PathGrad_Console_.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathGrad_Console_.Profile
{
    class Initialize
    {
        public static void setupProfile()
        {
            Console.WriteLine("Initial Profile");
            Console.WriteLine("------------------------------");

            Console.WriteLine("\nWelcome new user");
            Console.WriteLine("\nBefore Beginning to Plot the Perfect Path,\nyour profile must be initilized");
            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();

            int step = 1;

            while(step < 4)
            {
                switch(step)
                {
                    case 1: Console.Clear(); setTrack(); break;
                    case 2: Console.Clear(); previousCourses(); break;
                    case 3: Console.Clear(); saveProfile(); break;
                }

                step++;
            }

        }

        public static void loadTrack(string track)
        {
            //Make a connection with DB for Login collection
            var conString = "mongodb://localhost:27017";
            var Client = new MongoClient(conString);
            var DB = Client.GetDatabase("Path_To_Grad");
            var collection = DB.GetCollection<BsonDocument>("Tracks");


            var filter = new BsonDocument
            {
                {"_id", track}
            };

            //Search for desired elements
            List<MongoDB.Bson.BsonDocument> list = collection.Find(filter).ToList();

            tempStudent temp = new tempStudent();

            //Deserealize
            var holder = list[0]["curriculum"].ToString();
            temp = JsonConvert.DeserializeObject<tempStudent>(holder);

            Student.courseList = temp.tempCourses;

            /*string path;        //Variable will hold path

            //Find file
            path = Directory.GetCurrentDirectory();
            path = path + @"\Tracks\" + track + ".csv";

            try
            {

                // List<Course> values = File.ReadAllLines(path)
                Student.courseList = File.ReadAllLines(path)
                                        .Skip(1)
                                        .Select(v => Course.FromCsv(v))
                                        .ToList();
            }

            catch (Exception e)
            {
                Console.WriteLine("The file could not be read: ");
                Console.WriteLine(e.Message);
            }*/
        }

        public static void setTrack()
        {
            Console.WriteLine("Step 1/3: Set Curriculum Track");
            Console.WriteLine("------------------------------");
            Console.WriteLine("Please Choose a curriculum Track from following Options: \n");

            Console.WriteLine("(1) BS.CSC.IA Track");
            Console.Write("\n\nOption: ");
            int userResponse = Convert.ToInt32(Console.ReadLine());

            if(userResponse == 1)
            {
                Student.track = "BS.CSC.IA";
                loadTrack(Student.track);
            }
        }

        public static void previousCourses()
        {
            Console.WriteLine("Step 2/3: Select Previous Courses Taken");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("\nPlease denote all previous courses taken, end by entering 999: \n\n");
            Console.WriteLine("Press Any Key to Continue...");
            Console.ReadKey();

            Console.WriteLine("Index    Course Number");
            Console.WriteLine("----------------------");

            int index = 0;
            foreach (var Course in Student.courseList)
            {
                Console.WriteLine("{0}      {1} {2}{3}", index, Course.charac, Course.num, Course.lab);
                index++;
            }

            //Gather indexes of courses taken
            int[] indexAry = new int[50];
            int i = 0;
            int arraySize = 0;

            Console.WriteLine("Enter index of Courses previously taken: ");
            int courseIndex = Convert.ToInt32(Console.ReadLine());
            while(courseIndex != 999)
            {
                indexAry[i] = courseIndex;
                arraySize++;
                i++;
                courseIndex = Convert.ToInt32(Console.ReadLine());
            }

            //Confirm
            Console.WriteLine("\nYou have chosen courses with the following indexes: ");
            for(int j = 0; j < arraySize; j++)
            {
                Console.Write("{0}, ", indexAry[j]);
            }

            Console.WriteLine("\n\nWould you like to confirm this selection (1) or redo selection (2)");
            int userChoice = Convert.ToInt32(Console.ReadLine());

            if(userChoice == 1)
            {
                //Save Selection
                saveSelection(indexAry, arraySize);
            }
            else
            {
                Console.Clear();
                previousCourses();
            }
        }

        public static void saveProfile()
        {
            Console.WriteLine("Step 3/3: Select Previous Courses Taken");
            Console.WriteLine("Would you like to save this profile (1) Yes (2) No: ");
            int userResponse = Convert.ToInt32(Console.ReadLine());

            if(userResponse == 1)
            {
                //Save to student database
                db.newUser();
            }

            else
            {
                Console.WriteLine("Profile NOT saved. Returning to Main Menu");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                Program.menu();
            }
        }

        public static void printTrack()
        {
            Console.WriteLine("Course Number    Title   Credit Hour    Prerequisites    Offered");
            foreach (var Course in Student.courseList)
            {
                //Console.WriteLine("{0} {1}   {2}   {3}   {4}  {5}", Course.charac, Course.num, Course.title, Course.ch,
                //                                                Course.prerequisites, Course.offered);
                Console.WriteLine("{0} {1}{2}", Course.charac, Course.num, Course.lab);
            }
        }

        public static void saveSelection(int[] completedAry, int size)
        {
            int courseIndex;
            //For each course in array, mark as already completed in courseList
            for(int i = 0; i < size; i++)
            {
                courseIndex = completedAry[i];
                Student.courseList[courseIndex].completed = true;
                //Course temp = new Course();
                //temp = Student.courseList[courseIndex];

                //Student.takenCourses.Add(temp);

            }

            Console.WriteLine("Print of courses marked true: ");
            foreach(var Course in Student.courseList)
            {
                Console.WriteLine("{0} {1}{2}  {3}", Course.charac, Course.num, Course.lab, Course.completed);

            }

            Console.WriteLine("\nSelection of previous courses Saved");
            Console.WriteLine("\n\nPress Any Key to Continue...");

            Console.ReadKey();
            Console.Clear();
        }

        public static void restorProfile()
        {

        }
    }
}
