using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring_Thing.Resources
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Converts double radians value into degrees
        /// </summary>
        /// <param name="radians"></param>
        /// <returns>degrees</returns>
        public static double ToDegrees(this double radians)
        {
            return radians * 180.0 / Math.PI;
        }

        /// <summary>
        /// Converts double degrees value into radians
        /// </summary>
        /// <param name="degrees"></param>
        /// <returns></returns>
        public static double ToRadians(this double degrees)
        {
            return degrees * Math.PI / 180.0;
        }
    }
}
