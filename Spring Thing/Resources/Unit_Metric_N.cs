﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring_Thing.Resources
{
    public class Unit_Metric_N : IUnit
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