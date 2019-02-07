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

            string DesignWireDia = @"Wire Diameter";
            string DesignRate = @"Spring Rate";
            string DesignStress = @"Stress";

            Designs = new List<string>()
            {
                DesignWireDia,
                DesignRate,
                DesignStress
            };
        }
    }
}
