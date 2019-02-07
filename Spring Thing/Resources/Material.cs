using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Spring_Thing.Resources
{
    public partial class Material
    {
        /* 
         * Materials default to Metric units
         * mm, Pa, kg/mm^3
         */
            
        public string MaterialName { get; set; }
        public string MaterialDescription { get; set; }
        public string Specification { get; set; }
        public double GMod
        {
            get
            {
                return gmod / materialUnits.MaterialStressConversion;
            }
            set
            {
                gmod = value * materialUnits.MaterialStressConversion;              
            }
        }

        public double EMod
        {
            get
            {
                return emod * materialUnits.MaterialStressConversion;
            }
            set
            {
                emod = value / materialUnits.MaterialStressConversion;
            }
        }

        public double PoissonsRatio { get; set; }

        public double Density
        {
            get
            {
                return density / materialUnits.DensityConversion;
            }
            set
            {
                density = value * materialUnits.DensityConversion;
            }
        }
        public double MaxSize
        {
            get
            {
                return maxSize / materialUnits.LengthConversion;
            }
            set
            {
                maxSize = value * materialUnits.LengthConversion;
            }
        }
        public double StrengthUltimate
        {
            get
            {
                return strengthUltimate / materialUnits.MaterialStressConversion;
            }
            set
            {
                strengthUltimate = value * materialUnits.MaterialStressConversion;
            }
        }

        public double StrengthYield
        {
            get
            {
                return strengthYield / materialUnits.MaterialStressConversion;
            }
            set
            {
                strengthYield = value * materialUnits.MaterialStressConversion;
            }
        }

        public string Units
        {
            get
            {
                return units;
            }
            set
            {
                units = value;
                if(value == "Metric")
                {
                    materialUnits = new Unit_Metric();
                }
                else
                {
                    materialUnits = new Unit_US();
                }
            }
        }

        [XmlIgnore()]
        private IUnit materialUnits { get; set; }

        private double gmod;
        private double emod;
        private double density;
        private double maxSize;
        private double strengthUltimate;
        private double strengthYield;
        private string units;
    }
}
