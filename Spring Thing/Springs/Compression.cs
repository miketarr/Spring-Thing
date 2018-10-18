using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spring_Thing.Resources;

namespace Spring_Thing.Springs
{
    [Serializable]
    public partial class Compression : Part
    {

        #region UserDefineable Values
        public double WireDia
        {
            get
            {
                return wireDia;
            }
            set
            {
                wireDia = value;
                OnPropertyChanged("WireDia");
            }
        }

        public double WireDiaTolerance
        {
            get
            {
                return wireDiaTolerance;
            }
            set
            {
                wireDiaTolerance = value;
                OnPropertyChanged("WireDiaTolerance");
            }
        }

        public string DiameterType
        {
            get
            {
                return diameterType;
            }

            set
            {
                if (Enum.TryParse(value, out DiaType diatype))
                {
                    diameterType = value;
                    OnPropertyChanged("DiaType");
                }
            }
        }

        public double Diameter
        {
            get { return diameter; }
            set
            {
                diameter = value;
                OnPropertyChanged("Diameter");
            }
        }


        public double DiameterTolerance
        {
            get
            {
                return diameterTolerance;
            }
            set
            {
                diameterTolerance = value;
                OnPropertyChanged("DiameterTolerance");
            }
        }

        public double FreeLength
        {
            get
            {
                switch (SpringDefinition)
                {
                    case "Rate":
                    case "Dimensional":
                    default:
                        return freeLength;
                    case "TwoLoad":
                        return (Length1 + (Load1 / SpringRate));
                    case "RateOneLoad":
                        return (Length2 + Travel);
                }                          
            }
            set
            {
                freeLength = value;
                OnPropertyChanged("FreeLength");
            }
        }

        public double FreeLengthTolerance
        {
            get
            {
                return freeLengthTolerance;
            }
            set
            {
                freeLengthTolerance = value;
                OnPropertyChanged("FreeLengthTolerance");
            }
        }

        public double TotalCoils
        {
            get { return totalCoils; }
            set
            {
                totalCoils = value;
                OnPropertyChanged("TotalCoils");
            }
        }

        public double TotalCoilsTolerance
        {
            get { return totalCoilsTolerance; }
            set
            {
                totalCoilsTolerance = value;
                OnPropertyChanged("TotalCoilsTolerance");
            }
        }

        public double SpringRate
        {
            get
            {
                //return springRate;
                switch (SpringDefinition)
                {
                    case "Rate":
                    default:
                        return springRate;
                    case "TwoLoad":
                        return (Load2 - Load1) / Math.Abs(Length1 - Length2);
                    case "Dimensional":
                        if(Material.CrossSection == "Round")
                        {
                            return ((Material.GMod * Math.Pow(WireDia, 4)) / (8.0 * ActiveCoils * Math.Pow(MeanDiameter, 3)));
                        }
                        else if (Material.CrossSection == "Rectangular")
                        {
                            SpringRate = (Material.EMod * WireWidth * Math.Pow(WireThickness, 3)) / (ActiveCoils * Math.Pow(Diameter, 3)) * K2(Diameter, WireThickness, WireWidth);
                        }
                        
                        return 0.0;
                }
            }
            set
            {
                springRate = value;
                OnPropertyChanged("SpringRate");
            }
        }

        public double SpringRateTolerance
        {
            get
            {
                return springRateTolerance;
            }
            set
            {
                springRateTolerance = value;
                OnPropertyChanged("SpringRateTolerance");
            }
        }

        public double Load1
        {
            get { return load1; }
            set
            {
                load1 = value;
                OnPropertyChanged("Load1");
            }
        }

        public double Load1Tolerance
        {
            get { return load1Tolerance; }
            set
            {
                load1Tolerance = value;
                OnPropertyChanged("Load1Tolerance");
            }
        }

        public double Load2
        {
            get { return load2; }
            set
            {
                load2 = value;
                OnPropertyChanged("Load2");
            }
        }

        public double Load2Tolerance
        {
            get { return load2Tolerance; }
            set
            {
                load2Tolerance = value;
                OnPropertyChanged("Load2Tolerance");
            }
        }

        public double Length1
        {
            get { return length1; }
            set
            {
                length1 = value;
                OnPropertyChanged("Length1");
            }
        }

        public double Length1Tolerance
        {
            get { return length1Tolerance; }
            set
            {
                length1Tolerance = value;
                OnPropertyChanged("Length1Tolerance");
            }
        }

        public double Length2
        {
            get { return length2; }
            set
            {
                length2 = value;
                OnPropertyChanged("Length2");
            }
        }

        public double Length2Tolerance
        {
            get { return length2Tolerance; }
            set
            {
                length2Tolerance = value;
                OnPropertyChanged("Length2Tolerance");
            }
        }

        public double Travel
        {
            get
            {
                switch (SpringDefinition)
                {
                    case "Rate":
                    case "Dimensional":
                    default:
                        return travel;
                    case "TwoLoad":
                        return (FreeLength - Length2);
                    case "OneLoadOneRate":
                        return (Load2 / SpringRate);
                }
            }
            set
            {
                travel = value;
                OnPropertyChanged("Travel");
            }
        }

        /// <summary>
        /// The primary variable driving the design - Wire size, rate, or stress
        /// </summary>
        public string DesignConstraint
        {
            get { return designConstraint; }
            set
            {
                if(Enum.TryParse(value, out DesignType designtype))
                {
                    designConstraint = value;
                    OnPropertyChanged("DesignConstraint");
                }
            }
        }
        /// <summary>
        /// Spring performance specification - load-based, rate based, or some weird combination
        /// </summary>
        public string SpringDefinition
        {
            get { return springDefinition; }
            set
            {
                if(Enum.TryParse(value, out SpecType spectype))
                {
                    springDefinition = value;
                    OnPropertyChanged("SpecType");
                }
            }
        }

        public string End1Type
        {
            get
            {
                return end1Type;
            }
            set
            {
                if(Enum.TryParse(value, out EndType endtype))
                {
                    end1Type = value;
                    OnPropertyChanged("End1Type");
                }
            }
        }

        public string End2Type
        {
            get
            {
                return end2Type;
            }
            set
            {
                if (Enum.TryParse(value, out EndType endtype))
                {
                    end2Type = value;
                    OnPropertyChanged("End2Type");
                }
            }
        }

        public double GrindArea
        {
            get { return grindArea; }
            set
            {
                if(value >= 0.0)
                {
                    grindArea = value;
                    OnPropertyChanged("GrindArea");
                }
            }
        }

        public double MaxSolidHeight
        {
            get { return maxSolidHeight; }
            set
            {
                if(value >= 0.0)
                {
                    maxSolidHeight = value;
                    OnPropertyChanged("MaxSolidHeight");
                }
            }
        }

        public string CoilDirection
        {
            get { return coilDirection; }
            set
            {
                if(Enum.TryParse(value, out Hand hand))
                {
                    coilDirection = value;
                    OnPropertyChanged("CoilDirection");
                }
            }
        }

        public double WireWidth
        {
            get { return wireWidth; }
            set
            {
                if(value >= 0.0)
                {
                    wireWidth = value;
                    OnPropertyChanged("WireWidth");
                }
            }
        }

        public double WireThickness
        {
            get { return wireThickness; }
            set
            {
                if(value >= 0.0)
                {
                    wireThickness = value;
                    OnPropertyChanged("WireThickness");
                }
            }
        }

        #endregion

        #region CalculatedValues

        public double MeanDiameter
        {
            get
            {
                if (Material.CrossSection == "Round")
                {
                    switch (diameterType)
                    {
                        case "OD":
                            return diameter - wireDia;
                        case "ID":
                            return diameter + wireDia;
                        case "MD":
                            return diameter;
                        default:
                            return diameter;
                    }
                }
                else if(Material.CrossSection == "Rectangular")
                {
                    switch (diameterType)
                    {
                        case "OD":
                            return diameter - wireWidth;
                        case "ID":
                            return diameter + wireWidth;
                        case "MD":
                            return diameter;
                        default:
                            return diameter;
                    }
                }
                else
                {
                    return diameter;        //Should not get here
                }
            }
        }

        public double ActiveCoils
        {
            get
            {
                double activecoils = totalCoils;

                switch (End1Type)
                {
                    case "CEG":
                        activecoils -= SpringConstant.InactiveWire;
                        break;
                    case "CENG":
                    case "OENG":
                        break;
                    case "OEG":
                        activecoils -= (SpringConstant.InactiveWire / 2.0);
                        break;
                }

                switch (End2Type)
                {
                    case "CEG":
                        activecoils -= SpringConstant.InactiveWire;
                        break;
                    case "CENG":
                    case "OENG":
                        break;
                    case "OEG":
                        activecoils -= (SpringConstant.InactiveWire / 2.0);
                        break;
                }

                //return (TotalCoils - (SpringConstant.InactiveWire * 2.0)); 
                return activecoils;
            }

            set
            {
                activeCoils = value;
                OnPropertyChanged("ActiveCoils");
            }
        }

        public double Index
        {
            get
            {
                if (Material.CrossSection == "Round")
                {
                    return (MeanDiameter / WireDia);
                }
                else if (Material.CrossSection == "Rectangular")
                {
                    return (MeanDiameter / WireThickness);
                }
                else
                {
                    return (MeanDiameter / WireDia);
                }
            }
        }

        #endregion

        #region Private Variables
        private double wireDia;
        private double wireWidth;
        private double wireThickness;
        private double wireDiaTolerance;
        private string diameterType;
        private double diameter;
        private double diameterTolerance;
        private double freeLength;
        private double freeLengthTolerance;
        private double totalCoils;
        private double totalCoilsTolerance;
        private double activeCoils;
        private double springRate;
        private double springRateTolerance;
        private double load1;
        private double load1Tolerance;
        private double load2;
        private double load2Tolerance;
        private double length1;
        private double length1Tolerance;
        private double length2;
        private double length2Tolerance;
        private double travel;
        private string designConstraint;
        private string springDefinition;
        private string end1Type;
        private string end2Type;
        private double grindArea;
        private double maxSolidHeight;
        private string coilDirection;
        private double squareness;
        #endregion

        public enum EndType { CEG, CENG, OEG, OENG }

        public double K2(double dia, double thickness, double width)
        {
            if(Material.CrossSection == "Round") { return 0.0; }

            double k2;
            double[] a;
            double b1;
            double b2;
            double b3;
            double bot;
            double c;

            if (thickness >= width)
            {
                bot = thickness / width;
                a = new double[] { -1.481, -2.18, 3.069, -1.807, 0.433, -0.662, -0.362, 1.37, -1.841 };
                c = dia / thickness;
            }
            else
            {
                bot = width / thickness;
                a = new double[] { -1.676, -1.941, 2.974, -1.586, 0.429, -0.72, -0.83, 2.45, -1.942 };
                c = dia / width;
            }

            b1 = (c + a[0]) / (a[1] * c + a[2]);
            b2 = (c + a[3]) / (a[4] * c + a[5]);
            b3 = (c + a[6]) / (a[7] * c + a[8]);
            k2 = (bot + b1) / (b2 * bot + b3);

            return k2;
        }

        public override void Calculate()
        {
            try
            {

            }
            catch
            {

            }
            
        } 
    }
}
