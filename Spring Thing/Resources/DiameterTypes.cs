using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring_Thing.Resources
{
    public static class DiameterTypes
    {
        public static List<string> Diameters;

        static DiameterTypes()
        {
            Diameters = new List<string>();

            string DiameterOD = @"OD";
            string DiameterID = @"ID";
            string DiameterMD = @"MD";

            Diameters.Add(DiameterOD);
            Diameters.Add(DiameterID);
            Diameters.Add(DiameterMD);

        }
    }
}
