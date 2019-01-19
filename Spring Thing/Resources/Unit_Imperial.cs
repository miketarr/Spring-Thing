using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring_Thing.Resources
{
    public class Unit_Imperial : IUnit
    {
        public string UnitName
        {
            get
            {
                return @"Imperial";
            }
        }

        public string Length
        {
            get
            {
                return @"in";
            }
        }

        public string Force
        {
            get
            {
                return @"lb";
            }
        }

        public string Weight
        {
            get
            {
                return @"lb";
            }
        }

        public string Density
        {
            get
            {
                return @"lb/in^3";
            }
        }

        public string Rate
        {
            get
            {
                return @"lb/in";
            }
        }

        public string Stress
        {
            get
            {
                return @"ksi";
            }
        }

        public string Frequency
        {
            get
            {
                return @"Hz";
            }
        }

        public double SuggestedLengthTolerance
        {
            get
            {
                return 0.100;
            }
        }

        public double SuggestedDiameterTolerance
        {
            get
            {
                return 0.030;
            }
        }

        public double SuggestedWireTolerance
        {
            get
            {
                return 0.001;
            }
        }
        
    }
}
