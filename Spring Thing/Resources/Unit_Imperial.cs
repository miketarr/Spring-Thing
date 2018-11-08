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
        
    }
}
