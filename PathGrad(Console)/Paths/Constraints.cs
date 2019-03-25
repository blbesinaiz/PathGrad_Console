using PathGrad_Console_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathGrad_Console_.Paths
{
    class Constraints
    {
        public static bool Check_Constraints(Course c)
        {
            bool status = false;

            //Constrainst:

            //Check for prequisite
            status = Met_prequisite(c);

            //Check for co-requisite


            //Check to see if class passed and not failing

            return status;

        }

        public static bool Met_prequisite(Course c)
        {
            bool status = false;
            string requiredPre;
            Course temp = new Course();

            if (c.prerequisites != "")
            {
                //Find course prequisite
                requiredPre = c.prerequisites;
                //Get whole value of course name
                string courseName;
                foreach(var Course in Student.courseList)
                {
                    courseName = Course.charac + " " + Course.num + Course.lab;
                    if(courseName == requiredPre)
                    {
                        temp = Course;
                    }
                }

                Console.WriteLine(temp.assigned);
                //See have been assigned
                if (temp.assigned == true)
                    status = true;
                else
                    status = false;
            }
            else
                status = true;

            return status;
        }
    }
}
