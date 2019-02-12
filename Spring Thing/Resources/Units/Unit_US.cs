using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring_Thing.Resources
{
    public class Unit_US : IUnit
    {
        public string UnitName
        {
            get
            {
                return @"US Customary";
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

        public double LengthConversion
        {
            get
            {
                return 25.4;
            }
        }

        public double ForceConversion
        {
            get
            {
                return 4.448;
            }
        }


        /// <summary>
        /// 1 lb = 0.45359 kg
        /// </summary>
        public double WeightConversion
        {
            get
            {
                return 0.45359237;
            }
        }

        /// <summary>
        /// 1 lb/in^3 = 27.68 kg/mm^3
        /// </summary>
        public double DensityConversion
        {
            get
            {
                return 2.768E-5;
            }
        }

        /// <summary>
        /// 1 lb/in = 0.1751 N/mm
        /// </summary>
        public double RateConversion
        {
            get
            {
                return 0.1751;
            }
        }

        /// <summary>
        /// 1 ksi = 6.895 MPa
        /// Useful for display purposes
        /// </summary>
        public double StressConversion
        {
            get
            {
                return 6.895;
            }
        }

        /// <summary>
        /// 1 psi = 6895 Pa = 0.006895 N/mm^2
        /// For materials
        /// </summary>
        public double MaterialStressConversion
        {
            get
            {
                return 6895;
            }
        }

        public double SpringEquationConversion
        {
            get
            {
                return 1.0;
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
