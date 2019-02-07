using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring_Thing.Resources
{
    public class Unit_Metric : IUnit
    {
        public string UnitName
        {
            get
            {
                return @"Metric(N)";
            }
        }

        public string Length
        {
            get
            {
                return @"mm";
            }
        }

        public string Force
        {
            get
            {
                return @"N";
            }
        }

        public string Weight
        {
            get
            {
                return @"kg";
            }
        }

        public string Density
        {
            get
            {
                return @"Mg/m^3";
            }
        }

        public string Rate
        {
            get
            {
                return @"N/mm";
            }
        }

        public string Stress
        {
            get
            {
                return @"MPa";
            }
        }

        public string Frequency
        {
            get
            {
                return @"Hz";
            }
        }

        public double LengthConversion
        {
            get
            {
                return 1.0;
            }
        }

        public double ForceConversion
        {
            get
            {
                return 1.0;
            }
        }

        public double WeightConversion
        {
            get
            {
                return 1.0;
            }
        }

        public double DensityConversion
        {
            get
            {
                return 1.0;
            }
        }

        public double RateConversion
        {
            get
            {
                return 1.0;
            }
        }

        public double StressConversion
        {
            get
            {
                return 1.0;
            }
        }

        public double MaterialStressConversion
        {
            get
            {
                return 1.0;
            }
        }

        public double SpringEquationConversion
        {
            get
            {
                return 1E-6;
            }
        }

        public double SuggestedLengthTolerance
        {
            get
            {
                return 2.50;
            }
        }

        public double SuggestedDiameterTolerance
        {
            get
            {
                return 0.75;
            }
        }

        public double SuggestedWireTolerance
        {
            get
            {
                return 0.03;
            }
        }
    }
}
