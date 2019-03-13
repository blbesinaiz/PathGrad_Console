using PathGrad_Console_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathGrad_Console_.Paths
{
    class Perfect
    {
        //DEFAULTS
        public static string currentSemester = "Fall";
        public static int year = DateTime.Now.Year;
        public static int maxCH = 0;
        public static int yearCounter = 0;

        public static void Generate_Perfect()
        {
            //Get Student Input
            Console.WriteLine("Max number of credits per semester? (i.e. 15)");
            maxCH = Convert.ToInt32(Console.ReadLine());

            //Sort by Ascending Order
            Sort_By_Ascending();

            //Group and Print By Semester
            Group_By_Semester();

            //Save Path Generation
            Save_Path();
        }

        public static void Sort_By_Ascending()
        {
            //Sort courses by numerical sequence (Lower sequence at top)
            Student.courseList.Sort((s1, s2) => s1.num.CompareTo(s2.num));
        }

        public static void Group_By_Semester()
        {
            int creditCounter = 0;

            //While all assigned = false
            while(checkAssigned() == false)
            {
                //Output Starting Semester
                Console.WriteLine("\n{0} {1}", currentSemester, year);
                Console.WriteLine("--------------");
                foreach (var Course in Student.courseList)
                {
                    if (Course.assigned == false)
                    {
                        Section_Semester(Course);
                        Course.assigned = true;
                        creditCounter += Course.ch;
                    }

                    if (creditCounter +  3 > maxCH)
                        break;
                }

                Console.WriteLine("Credit Total: {0}", creditCounter);

                //Reset/Update Values
                creditCounter = 0;
                yearCounter++;

                if (currentSemester == "Fall")
                    currentSemester = "Spring";
                else if(currentSemester == "Spring")
                    currentSemester = "Fall";

                if (yearCounter % 2 == 0)
                    year++;
            }
        }

        //Function Checks to see if course has been previously assigned
        public static bool checkAssigned()
        {
            bool allAssigned = false;

            foreach (var Course in Student.courseList)
            {
                if (Course.assigned == false)
                {
                    allAssigned = false;
                    break;
                }
                else
                    allAssigned = true;
            }
            return allAssigned;
        }

        public static void Section_Semester(Course c)
        {
            //If Course is offered in fall or any other semester
            if ((currentSemester == "Fall") && (c.offered == "FO" || c.offered == "FS" || c.offered == "E" || c.offered == "EE" || c.offered == "SI" || c.offered == "O"))
            {
                Console.WriteLine("{0} {1}  {2}", c.charac, c.num, c.ch);
            }

            else if ((currentSemester == "Spring") && (c.offered == "SO" || c.offered == "E" || c.offered == "EE" || c.offered == "SI" || c.offered == "O"))
            {
                Console.WriteLine("{0} {1}  {2}", c.charac, c.num, c.ch);
            }
        }

        public static void Save_Path()
        {
            Console.WriteLine("Press any key");
            Console.ReadKey();
            var originalConsoleOut = Console.Out; // preserve the original stream

            string savedPath = originalConsoleOut.ToString();

            Console.WriteLine(originalConsoleOut);
        }
    }
}
