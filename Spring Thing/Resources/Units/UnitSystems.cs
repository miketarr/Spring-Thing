using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring_Thing.Resources
{
    public static class UnitSystems
    {
        public static List<string> Systems;

        static UnitSystems()
        {
            string Metric = @"Metric";
            string US = @"US Customary";

            Systems = new List<string>()
            {
                US,
                Metric
            };
        }
    }
}
