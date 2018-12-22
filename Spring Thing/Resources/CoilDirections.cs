using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring_Thing.Resources
{
    public static class CoilDirections
    {
        public static List<string> Directions;

        static CoilDirections()
        {
            string DirectionRight = @"Right";
            string DirectionLeft = @"Left";
            string DirectionOptional = @"Optional";

            Directions = new List<string>();

            Directions.Add(DirectionRight);
            Directions.Add(DirectionLeft);
            Directions.Add(DirectionOptional);
        }
    }
}
