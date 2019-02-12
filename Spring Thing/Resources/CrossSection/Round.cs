using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring_Thing.Resources
{
    public class Round : ICrossSection
    {
        public string SectionName
        {
            get
            {
                return @"Round";
            }
        }

        public double StressLoad1
        {
            get
            {
                return 0.0;
            }
        }

        public double StressLoad2
        {
            get
            {
                return 0.0;
            }
        }

        public double StressSolid
        {
            get
            {
                return 0.0;
            }
        }

        public double SpringRate(double gmod, double wd_dim1, double wd_dim2, double activecoils, double meandiameter)
        {
            return (gmod * Math.Pow(wd_dim1, 4)) / (8 * activecoils * Math.Pow(meandiameter, 3));
        }

        private double Index(double meandiameter, double wiredia)
        {
            return meandiameter / wiredia;
        }
    }
}
