using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoApp_SCRUM
{
    internal class GeneralFunctions
    {

        // Input Min and Max Number Range to Return Random Number within that Range
        public int returnRandInt(int min, int max)
        {
            if (min < 0 || max < 0 || min >= max) // Returns 0 if number input is below 0 or if the two numbers are equal to each other
            {
                return 0;
            }
            Random random = new Random();
            return random.Next(min, max + 1); // +1 includes the max number in the possible outcomes
        }

    }
}
