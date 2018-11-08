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
         * Materials default to Imperial units
         * inches, psi, pounds, etc.
         */
            
        public string MaterialName { get; set; }
        public string MaterialDescription { get; set; }
        public string Specification { get; set; }
        public int GMod { get; set; }
        public int EMod { get; set; }
        public double PoissonsRatio { get; set; }
        public double Density { get; set; }
        public double MaxSize { get; set; }
        public double StrengthUltimate { get; set; }
        public double StrengthYield { get; set; }
        public string Units { get; set; }

        [XmlIgnore()]
        public IUnit MaterialUnits { get; set; }
    }
}
