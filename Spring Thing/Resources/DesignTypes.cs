using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring_Thing.Resources
{
    public static class DesignTypes
    {
        public static List<string> Designs;

        static DesignTypes()
        {
            Designs = new List<string>();

            string DesignWireDia = @"Wire Diameter";
            string DesignRate = @"Spring Rate";
            string DesignStress = @"Stress";

            Designs.Add(DesignWireDia);
            Designs.Add(DesignRate);
            Designs.Add(DesignStress);
        }
    }
}
