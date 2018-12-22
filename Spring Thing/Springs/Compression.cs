using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spring_Thing.Resources;

namespace Spring_Thing.Springs
{
    [Serializable]
    public partial class Compression : Part
    {
        public override string SpringType
        {
            get
            {
                return "Compression";
            }
        }

        public enum CrossSections { Round = 0, Rectangle = 1 }

        public override string CrossSection
        {
            get
            {
                return crossSection;
            }
            set
            {
                if (Enum.TryParse(value, out CrossSections crossSectionEvaluation))
                {
                    crossSection = value;
                    OnPropertyChanged(string.Empty);
                }
            }
        }

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
                OnPropertyChanged(string.Empty);
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
                OnPropertyChanged(string.Empty);
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
                    diameterType = value;
                    OnPropertyChanged(string.Empty);              
            }
        }

        public double Diameter
        {
            get { return diameter; }
            set
            {
                diameter = value;
                OnPropertyChanged(string.Empty);
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
                OnPropertyChanged(string.Empty);
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
                OnPropertyChanged(string.Empty);
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
                OnPropertyChanged(string.Empty);
            }
        }

        public double TotalCoils
        {
            get
            {
                switch (SpringDefinition)
                {
                    default:
                    case "Rate":
                    case "Two Load":
                    case "Rate + Load":
                        double total = ActiveCoils;

                        switch (End1Type)
                        {
                            case "CEG":
                                total += SpringConstant.InactiveWire;
                                break;
                            case "CENG":
                            case "OENG":
                                break;
                            case "OEG":
                                total += (SpringConstant.InactiveWire / 2.0);
                                break;
                        }

                        switch (End2Type)
                        {
                            case "CEG":
                                total += SpringConstant.InactiveWire;
                                break;
                            case "CENG":
                            case "OENG":
                                break;
                            case "OEG":
                                total += (SpringConstant.InactiveWire / 2.0);
                                break;
                        }

                        totalCoils = total;
                        break;

                    case "Dimensional":
                        break;
                }

                return totalCoils;
            }

            set
            {
                totalCoils = value;
                OnPropertyChanged(string.Empty);
            }
        }

        public double TotalCoilsTolerance
        {
            get { return totalCoilsTolerance; }
            set
            {
                totalCoilsTolerance = value;
                OnPropertyChanged(string.Empty);
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
                    case "Rate + Load":
                    default:
                        return springRate;
                    case "Two Load":
                        return (Load2 - Load1) / Math.Abs(Length1 - Length2);
                    case "Dimensional":
                        if(CrossSection == "Round")
                        {
                            springRate = ((Material.GMod * Math.Pow(WireDia, 4)) / (8.0 * ActiveCoils * Math.Pow(MeanDiameter, 3)));
                        }
                        else if (CrossSection == "Rectangular")
                        {
                            springRate = (Material.EMod * WireWidth * Math.Pow(WireThickness, 3)) / (ActiveCoils * Math.Pow(Diameter, 3)) * K2(Diameter, WireThickness, WireWidth);
                        }
                        
                        return springRate;
                }
            }
            set
            {
                springRate = value;
                OnPropertyChanged(string.Empty);
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
                OnPropertyChanged(string.Empty);
            }
        }

        public double Load1
        {
            get { return load1; }
            set
            {
                load1 = value;
                OnPropertyChanged(string.Empty);
            }
        }

        public double Load1Tolerance
        {
            get { return load1Tolerance; }
            set
            {
                load1Tolerance = value;
                OnPropertyChanged(string.Empty);
            }
        }

        public double Load2
        {
            get { return load2; }
            set
            {
                load2 = value;
                OnPropertyChanged(string.Empty);
            }
        }

        public double Load2Tolerance
        {
            get { return load2Tolerance; }
            set
            {
                load2Tolerance = value;
                OnPropertyChanged(string.Empty);
            }
        }

        public double Length1
        {
            get { return length1; }
            set
            {
                length1 = value;
                OnPropertyChanged(string.Empty);
            }
        }

        public double Length1Tolerance
        {
            get { return length1Tolerance; }
            set
            {
                length1Tolerance = value;
                OnPropertyChanged(string.Empty);
            }
        }

        public double Length2
        {
            get { return length2; }
            set
            {
                length2 = value;
                OnPropertyChanged(string.Empty);
            }
        }

        public double Length2Tolerance
        {
            get { return length2Tolerance; }
            set
            {
                length2Tolerance = value;
                OnPropertyChanged(string.Empty);
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
                    case "Two Load":
                        return (FreeLength - Length2);
                    case "Rate + Load":
                        return (Load2 / SpringRate);
                }
            }
            set
            {
                travel = value;
                OnPropertyChanged(string.Empty);
            }
        }

        public double TravelTolerance
        {
            get
            {
                return travelTolerance;
            }
            set
            {
                travelTolerance = value;
                OnPropertyChanged(string.Empty);
            }
        }

        /// <summary>
        /// The primary variable driving the design - Wire size, rate, or stress
        /// </summary>
        public string DesignConstraint
        {
            get
            {
                return designConstraint;
            }
            set
            {
                    designConstraint = value;
                    OnPropertyChanged(string.Empty);
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
                    springDefinition = value;
                    OnPropertyChanged(string.Empty);      
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
                    OnPropertyChanged(string.Empty);
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
                    OnPropertyChanged(string.Empty);
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
                    OnPropertyChanged(string.Empty);
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
                    OnPropertyChanged(string.Empty);
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
                    OnPropertyChanged(string.Empty);
                }
            }
        }

        public double Squareness
        {
            get { return squareness; }
            set
            {
                if(value > 0.0)
                {
                    squareness = value;
                    OnPropertyChanged(string.Empty);
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
                    OnPropertyChanged(string.Empty);
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
                    OnPropertyChanged(string.Empty);
                }
            }
        }

        #endregion

        #region CalculatedValues

        public double MeanDiameter
        {
            get
            {
                if (CrossSection == "Round")
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
                else if(CrossSection == "Rectangular")
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
                switch (SpringDefinition)
                {
                    //public enum SpecType { Rate, TwoLoad, RateOneLoad, Dimensional }
                    default:
                    case "Dimensional":

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
                        break;
                    case "Rate":
                    case "Two Load":
                    case "Rate + Load":
                        switch (CrossSection)
                        {
                            default:
                            case "Round":
                                activecoils = (Material.GMod * Math.Pow(WireDia, 4)) / (8.0 * SpringRate * Math.Pow(MeanDiameter, 3));
                                break;

                            case "Rectangular":
                                activecoils = (Material.EMod * WireWidth * Math.Pow(WireThickness, 3)) / (SpringRate * Math.Pow(Diameter, 3)) * K2(Diameter, WireThickness, WireWidth);
                                break;
                        }

                        break;
                }

                //return (TotalCoils - (SpringConstant.InactiveWire * 2.0)); 
                return activecoils;
            }

            set
            {
                activeCoils = value;
                OnPropertyChanged(string.Empty);
            }
        }

        public double Index
        {
            get
            {
                if (CrossSection == "Round")
                {
                    return (MeanDiameter / WireDia);
                }
                else if (CrossSection == "Rectangular")
                {
                    return (MeanDiameter / WireThickness);
                }
                else
                {
                    return (MeanDiameter / WireDia);
                }
            }
        }

        public double SolidHeight
        {
            get
            {
                switch (CrossSection)
                {
                    default:
                    case "Round":
                        return (TotalCoils * WireDia) - (GrindArea * WireDia * 2.0);
                    case "Rectangular":
                        return (TotalCoils * WireThickness) - (GrindArea * WireThickness * 2.0);
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
        private double travelTolerance;
        private string designConstraint;
        private string springDefinition;
        private string end1Type;
        private string end2Type;
        private double grindArea;
        private double maxSolidHeight;
        private string coilDirection;
        private double squareness;
        private string crossSection;
        #endregion

        public enum EndType {
            [Description("Closed-End Ground")]
            CEG,
            [Description("Closed-End Not Ground")]
            CENG,
            [Description("Open-End Ground")]
            OEG,
            [Description("Open-End Not Ground")]
            OENG }

        public double K2(double dia, double thickness, double width)
        {
            if(CrossSection == "Round") { return 0.0; }

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

        public Compression()
        {
            PartNumber = "New Compression";
            Revision = "NEW";
            DateCreated = DateTime.Today;
            LastUpdated = DateTime.Today;
            Description = string.Empty;
            CreatedBy = "User";

            Units = "Imperial";
            UnitSystem = new Unit_Imperial();

            Material = MaterialLibrary.SelectMaterial("Stainless 302");

            DesignConstraint = "Wire Diameter";
            SpringDefinition = "Rate";

            WireDia = 0.367;
            WireWidth = 0.0;
            WireThickness = 0.0;
            WireDiaTolerance = 0.001;

            Diameter = 2.500;
            DiameterType = "OD";
            DiameterTolerance = 0.030;

            TotalCoilsTolerance = 0.05;

            FreeLength = 6.000;
            FreeLengthTolerance = 0.050;
            Travel = 3.500;
            TravelTolerance = 0.100;

            SpringRate = 495.000;
            SpringRateTolerance = 25.000;

            End1Type = "CEG";
            End2Type = "CEG";

            MaxSolidHeight = 0.000;
            Squareness = 3.00;
            GrindArea = 0.75;
            CoilDirection = "Right";
            CrossSection = "Round";

        }
    }
}
