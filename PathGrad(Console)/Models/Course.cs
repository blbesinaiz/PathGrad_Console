using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathGrad_Console_.Models
{
    class Course
    {
        public string charac { get; set; }       //Better name?? CSC
        public int num { get; set; }           //101
        public string lab { get; set; }                //L = lab
        public string title { get; set; }            //Introduction to Computer Science
        public int ch { get; set; }                  // credit hour 1
        public string prerequisites { get; set; } = null;
        public string type { get; set; }             //core
        public string offered { get; set; }          //FO (Fall Only), SO (Spring Only), E (Each Semester),
                                                     //EE (Each Semester, excludes summber), FS (Fall/Summer Only),
                                                     //SI (Sufficient Student Interest), O (Offered every other year)
        public bool assigned { get; set; } = false;          //Keeps track if assigned to fall or spring list
        public bool prerequSatisfied { get; set; }
        public bool completed { get; set; } = false;

        public static Course FromCsv(string csvLine)
        {
            string[] data = csvLine.Split(',');
            Course courseIn = new Course();
            courseIn.charac = data[0];
            courseIn.num = Convert.ToInt32(data[1]);
            courseIn.lab = data[2];
            courseIn.title = data[3];
            courseIn.ch = Convert.ToInt32(data[4]);
            courseIn.prerequisites = data[5];
            courseIn.type = data[6];
            courseIn.offered = data[7];

            return courseIn;
        }
    }
}
