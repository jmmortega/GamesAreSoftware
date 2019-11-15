using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAreSoftware.Utils
{
    public static class RandomExtensionMethods
    {
        public static int NextAndExclude(this Random rnd, int minValue, int maxValue, int[] excludeValues, int tries = 3)
        {
            var value = rnd.Next(minValue, maxValue);
            if(!excludeValues.Contains(value))
            {
                return value;
            }

            if(tries != 0)
            {
                return rnd.NextAndExclude(minValue, maxValue, excludeValues, tries - 1);
            }
            else
            {
                return minValue;
            }

        }

        
    }
}
