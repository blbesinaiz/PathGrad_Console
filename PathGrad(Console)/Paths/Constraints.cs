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

            //Constrains:

            //Check for prequisite


            //Check for co-requisite


            //Check to see if class passed and not failing

            return status;

        }

        public static bool met_prequisite(Course c)
        {
            bool status = false;

            if(c.prerequisites != "")
            {
                //Find course prequisite

                //See have been assigned

                //If prereq assigned == true

            }

            return status;
        }
    }
}
