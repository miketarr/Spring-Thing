using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring_Thing.Resources
{
    public static class SpecTypes
    {
        public static List<string> Specs;

        static SpecTypes()
        {
            Specs = new List<string>();

            string SpecRate = @"Rate";
            string SpecLoad = @"Two Load";
            string SpecRateOneLoad = @"Rate + Load";
            string SpecDimensional = @"Dimensional";

            Specs.Add(SpecRate);
            Specs.Add(SpecLoad);
            Specs.Add(SpecRateOneLoad);
            Specs.Add(SpecDimensional);
        }
    }
}
