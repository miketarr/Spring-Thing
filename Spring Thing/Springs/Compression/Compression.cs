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
                return wireDia / UnitSystem.LengthConversion;
            }
            set
            {
                wireDia = value * UnitSystem.LengthConversion;
                OnPropertyChanged(string.Empty);
            }
        }

        public double WireDiaTolerance
        {
            get
            {
                return wireDiaTolerance / UnitSystem.LengthConversion;
            }
            set
            {
                wireDiaTolerance = value * UnitSystem.LengthConversion;
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
            get
            {
                return diameter / UnitSystem.LengthConversion;
            }
            set
            {
                diameter = value * UnitSystem.LengthConversion;
                OnPropertyChanged(string.Empty);
            }
        }


        public double DiameterTolerance
        {
            get
            {
                return diameterTolerance / UnitSystem.LengthConversion;
            }
            set
            {
                diameterTolerance = value * UnitSystem.LengthConversion;
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
                        break;
                    case "Two Load":
                        freeLength = (Length1 + (Load1 / SpringRate)) * UnitSystem.LengthConversion;
                        break;
                    case "Rate + Load":
                        freeLength = (Length2 + Travel) * UnitSystem.LengthConversion;
                        break;
                }

                return freeLength / UnitSystem.LengthConversion;
            }
            set
            {
                freeLength = value * UnitSystem.LengthConversion;
                OnPropertyChanged(string.Empty);
            }
        }

        public double FreeLengthTolerance
        {
            get
            {
                return freeLengthTolerance / UnitSystem.LengthConversion;
            }
            set
            {
                freeLengthTolerance = value * UnitSystem.LengthConversion;
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

                        totalCoils = total + DeadWire;
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
            get
            {
                return totalCoilsTolerance;
            }
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
                        break;

                    case "Two Load":
                        springRate = ((Load2 - Load1) / Math.Abs(Length1 - Length2)) * UnitSystem.RateConversion;
                        break;
                        
                    case "Dimensional":
                        if (CrossSection == "Round")
                        {
                            springRate = ((Material.GMod * UnitSystem.SpringEquationConversion * Math.Pow(WireDia, 4)) / (8.0 * ActiveCoils * Math.Pow(MeanDiameter, 3))) * UnitSystem.RateConversion;
                        }
                        else if (CrossSection == "Rectangular")
                        {
                            springRate = ((Material.EMod * WireWidth * Math.Pow(WireThickness, 3)) / (ActiveCoils * Math.Pow(Diameter, 3)) * K2) * UnitSystem.RateConversion;
                        }
                        break;
                }

                return springRate / UnitSystem.RateConversion;
            }

            set
            {
                springRate = value * UnitSystem.RateConversion;
                OnPropertyChanged(string.Empty);
            }
        }

        public double SpringRateTolerance
        {
            get
            {
                return springRateTolerance / UnitSystem.RateConversion;
            }
            set
            {
                if (value >= 0.0)
                {
                    springRateTolerance = value * UnitSystem.RateConversion;
                    OnPropertyChanged(string.Empty);
                }
            }
        }

        public double Load1
        {
            get
            {
                if(SpringDefinition == "Rate" || SpringDefinition == "Dimensional")
                {
                    load1 = (SpringRate * (Travel * SpringConstant.SuggestedLength1Proportion)) / UnitSystem.ForceConversion;
                }
                else if(SpringDefinition == "Rate + Load")
                {
                    return 0.0;
                }
                
                return load1 * UnitSystem.ForceConversion;
            }

            set
            {
                load1 = value / UnitSystem.ForceConversion;
                OnPropertyChanged(string.Empty);
            }
        }

        public double Load1Tolerance
        {
            get
            {
                if (SpringDefinition == "Rate" || SpringDefinition == "Dimensional")
                {
                    load1Tolerance = Load1 * SpringConstant.SuggestedLoadTolerance / UnitSystem.ForceConversion;
                }
                else if (SpringDefinition == "Rate + Load")
                {
                    load1Tolerance = 0.0;
                }

                return load1Tolerance * UnitSystem.ForceConversion;
            }

            set
            {
                if (value >= 0.0)
                {
                    load1Tolerance = value / UnitSystem.ForceConversion;
                    OnPropertyChanged(string.Empty);
                }
            }
        }

        public double Load2
        {
            get
            {
                if (SpringDefinition == "Rate" || SpringDefinition == "Dimensional")
                {
                    load2 = (SpringRate * (Travel * SpringConstant.SuggestedLength2Proportion)) / UnitSystem.ForceConversion;
                }
                
                return load2 * UnitSystem.ForceConversion;
            }
            set
            {
                load2 = value / UnitSystem.ForceConversion;
                OnPropertyChanged(string.Empty);
            }
        }

        public double Load2Tolerance
        {
            get
            {
                if (SpringDefinition == "Rate" || SpringDefinition == "Dimensional")
                {
                    load2Tolerance = Load2 * SpringConstant.SuggestedLoadTolerance / UnitSystem.ForceConversion;
                }

                return load2Tolerance * UnitSystem.ForceConversion;
            }

            set
            {
                if (value >= 0.0)
                {
                    load2Tolerance = value / UnitSystem.ForceConversion;
                    OnPropertyChanged(string.Empty);
                }

            }
        }

        public double Length1
        {
            get
            {
                if (SpringDefinition == "Rate" || SpringDefinition == "Dimensional")
                {
                    length1 = (FreeLength - (Travel * SpringConstant.SuggestedLength1Proportion)) / UnitSystem.LengthConversion;
                }
                else if (SpringDefinition == "Rate + Load")
                {
                    length1 = FreeLength / UnitSystem.LengthConversion;
                }

                return length1 * UnitSystem.LengthConversion;
                
            }

            set
            {
                length1 = value / UnitSystem.LengthConversion;
                OnPropertyChanged(string.Empty);
            }
        }

        public double Length1Tolerance
        {
            get
            {
                return length1Tolerance / UnitSystem.LengthConversion;
            }
            set
            {
                length1Tolerance = value * UnitSystem.LengthConversion;
                OnPropertyChanged(string.Empty);
            }
        }

        public double Length2
        {
            get
            {
                if (SpringDefinition == "Rate" || SpringDefinition == "Dimensional")
                {
                    length2 = (FreeLength - (Travel * SpringConstant.SuggestedLength2Proportion)) / UnitSystem.LengthConversion;
                }

                return length2 * UnitSystem.LengthConversion;
            }

            set
            {
                length2 = value / UnitSystem.LengthConversion;
                if(SpringDefinition == "Rate + Load")
                {
                    Load2 = (FreeLength - value) * SpringRate;
                }
                OnPropertyChanged(string.Empty);
            }
        }

        public double Length2Tolerance
        {
            get
            {
                return length2Tolerance * UnitSystem.LengthConversion;
            }
            set
            {
                length2Tolerance = value / UnitSystem.LengthConversion;
                OnPropertyChanged(string.Empty);
            }
        }

        public double Travel
        {
            get
            {
                switch (SpringDefinition)
                {

                    case "Dimensional":
                    default:                      
                        break;
                    case "Two Load":
                    case "Rate":
                        travel = (FreeLength - SolidHeight) / UnitSystem.LengthConversion;
                        break;
                    case "Rate + Load":

                        travel = (Load2 / SpringRate) / UnitSystem.LengthConversion;
                        break;
                }

                return travel * UnitSystem.LengthConversion;
            }
            set
            {
                travel = value / UnitSystem.LengthConversion;
                OnPropertyChanged(string.Empty);
            }
        }

        public double TravelTolerance
        {
            get
            {
                return travelTolerance * UnitSystem.LengthConversion;
            }
            set
            {
                travelTolerance = value / UnitSystem.LengthConversion;
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
        /// 
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

                    if (end1Type == "CENG" || end1Type == "OENG")
                    {
                        GrindAreaEnd1 = 0.0;
                    }

                    if(MatchingEnds == true)
                    {
                        End2Type = end1Type;
                    }

                    OnPropertyChanged(string.Empty);
                }
            }
        }

        public string End2Type
        {
            get
            {
                if(MatchingEnds == true)
                {
                    end2Type = End1Type;
                }
                return end2Type;
            }
            set
            {
                if (Enum.TryParse(value, out EndType endtype))
                {
                    end2Type = value;

                    if(end2Type == "CENG" || end2Type == "OENG")
                    {
                        GrindAreaEnd2 = 0.0;
                    }

                    OnPropertyChanged(string.Empty);
                }
            }
        }

        public double GrindAreaEnd1
        {
            get { return grindAreaEnd1; }
            set
            {
                if(value >= 0.0)
                {
                    if (value < 1.0)
                    {
                        grindAreaEnd1 = value;
                    }
                    else
                    {
                        grindAreaEnd1 = value / 100.0;
                    }

                    if(MatchingEnds == true)
                    {
                        GrindAreaEnd2 = value;
                    }

                    OnPropertyChanged(string.Empty);
                }
            }
        }

        public double GrindAreaEnd2
        {
            get
            {
                return grindAreaEnd2;
            }

            set
            {
                if(value >= 0.0)
                {
                    if(value < 1.0)
                    {
                        grindAreaEnd2 = value;
                    }
                    else
                    {
                        grindAreaEnd2 = value / 100.0;
                    }

                    OnPropertyChanged(string.Empty);
                }
            }
        }

        public bool MatchingEnds
        {
            get
            {
                return matchingEnds;
            }

            set
            {
                matchingEnds = value;

                if(matchingEnds == true)
                {
                    GrindAreaEnd2 = GrindAreaEnd1;
                    End2Type = End1Type;
                    TipGap2 = TipGap1;
                }

                OnPropertyChanged(string.Empty);
            }
        }

        public double MaxSolidHeight
        {
            get
            {
                return maxSolidHeight * UnitSystem.LengthConversion;
            }
            set
            {
                if(value >= 0.0)
                {
                    maxSolidHeight = value / UnitSystem.LengthConversion;
                    OnPropertyChanged(string.Empty);
                }
            }
        }

        public string CoilDirection
        {
            get { return coilDirection; }
            set
            {
                coilDirection = value;
                OnPropertyChanged(string.Empty);                
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
            get
            {
                return wireWidth * UnitSystem.LengthConversion;
            }

            set
            {
                if(value >= 0.0)
                {
                    wireWidth = value / UnitSystem.LengthConversion;
                    OnPropertyChanged(string.Empty);
                }
            }
        }

        public double WireThickness
        {
            get
            {
                return wireThickness * UnitSystem.LengthConversion;
            }
            set
            {
                if(value >= 0.0)
                {
                    wireThickness = value / UnitSystem.LengthConversion;
                    OnPropertyChanged(string.Empty);
                }
            }
        }

        public double WorksIn
        {
            get
            {
                return worksIn * UnitSystem.LengthConversion;
            }
            set
            {
                if(value >= 0.0)
                {
                    worksIn = value / UnitSystem.LengthConversion;
                    OnPropertyChanged(string.Empty);
                }
            }
        }

        public double WorksOver
        {
            get
            {
                return worksOver * UnitSystem.LengthConversion;
            }
            set
            {
                if(value >= 0.0)
                {
                    worksOver = value / UnitSystem.LengthConversion;
                    OnPropertyChanged(string.Empty);
                }
            }
        }

        public double DeadWire
        {
            get
            {
                return deadWire;
            }
            set
            {
                if(value >= 0.0)
                {
                    deadWire = value;
                    OnPropertyChanged(string.Empty);
                }
            }
        }

        public double TipGap1
        {
            get
            {
                return tipGap1 * UnitSystem.LengthConversion;
            }
            set
            {
                if(value >= 0.0)
                {
                    tipGap1 = value / UnitSystem.LengthConversion;

                    if(MatchingEnds == true)
                    {
                        TipGap2 = TipGap1;
                    }

                    OnPropertyChanged(string.Empty);
                }
            }
        }

        public double TipGap2
        {
            get
            {
                return tipGap2 * UnitSystem.LengthConversion;
            }
            set
            {
                if (value >= 0.0)
                {
                    tipGap2 = value / UnitSystem.LengthConversion;
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
                            return Diameter - WireDia;
                        case "ID":
                            return Diameter + WireDia;
                        case "MD":
                            return Diameter;
                        default:
                            return Diameter;
                    }
                }
                else if(CrossSection == "Rectangular")
                {
                    switch (diameterType)
                    {
                        case "OD":
                            return Diameter - WireWidth;
                        case "ID":
                            return Diameter + WireWidth;
                        case "MD":
                            return Diameter;
                        default:
                            return Diameter;
                    }
                }
                else
                {
                    return Diameter;        //Should not get here
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

                        activecoils -= DeadWire;

                        switch (End1Type)
                        {
                            case "CEG":
                            case "CENG":
                                activecoils -= SpringConstant.InactiveWire;
                                break;

                            case "OENG":
                                break;
                            case "OEG":
                                activecoils -= (SpringConstant.InactiveWire / 2.0);
                                break;
                        }

                        switch (End2Type)
                        {
                            case "CEG":
                            case "CENG":
                                activecoils -= SpringConstant.InactiveWire;
                                break;

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
                                activecoils = (Material.GMod * UnitSystem.SpringEquationConversion * Math.Pow(WireDia, 4)) / (8.0 * SpringRate * Math.Pow(MeanDiameter, 3));
                                break;

                            case "Rectangular":
                                activecoils = (Material.EMod * WireWidth * Math.Pow(WireThickness, 3)) / (SpringRate * Math.Pow(Diameter, 3)) * K2;
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

        public double NaturalFrequency
        {
            get
            {
                return 0.0;
            }
        }

        public double WireLength
        {
            get
            {
                return (Math.PI * MeanDiameter * TotalCoils);
            }
        }

        public double Weight_Manufacturing
        {
            get
            {
                double wt = (WireLength * (0.25 * Math.Pow(WireDia, 2) * Math.PI) * Material.Density) ;

                return wt;
            }
        }

        public double Weight
        {
            get
            {

                // This needs to be updated when spring ends are implemented
                return Weight_Manufacturing;
            }
        }

        public double SolidHeight
        {
            get
            {
                double thickness = WireDia;
                if(CrossSection == "Rectangular")
                {
                    thickness = WireThickness;
                }
   
                double solid = ((TotalCoils + 1) * thickness);

                switch (End1Type)
                {
                    case "CENG":
                    case "OENG":
                        break;
                    case "CEG":
                    case "OEG":
                        solid -= (0.5 * thickness);
                        break;
                }

                switch (End2Type)
                {
                    case "CENG":
                    case "OENG":
                        break;
                    case "CEG":
                    case "OEG":
                        solid -= 0.5 * thickness;
                        break;
                }

                return solid;
       
            }
        }

        public double Pitch
        {
            get
            {
                double deadmaterial = 0.0;

                switch (End1Type)
                {
                    case "CENG":
                        deadmaterial += 1.5;
                        break;
                    case "OEG":
                    case "OENG":
                        deadmaterial += 0.5;
                        break;
                    case "CEG":
                        deadmaterial += 1.0;
                        break;
                }

                switch (End2Type)
                {
                    case "CENG":
                        deadmaterial += 1.5;
                        break;
                    case "OEG":
                    case "OENG":
                        deadmaterial += 0.5;
                        break;
                    case "CEG":
                        deadmaterial += 1.0;
                        break;
                }

                return (FreeLength - (deadmaterial * WireDia)) / ActiveCoils;
            }
        }

        public double PitchAngle
        {
            get
            {
                return (Math.Atan(Pitch / (MeanDiameter * Math.PI))).ToDegrees();
            }
        }

        public double KW
        {
            get
            {
                return ((4 * Index - 1) / (4 * Index - 4)) + (0.615 / Index);
            }
        }

        public double StressLoad1
        {
            get
            {
                return CalculateStress(Load1);
            }
        }

        public double StressLoad2
        {
            get
            {
                return CalculateStress(Load2);
            }
        }

        public double StressSolid
        {
            get
            {
                return CalculateStress(SpringRate * (FreeLength - SolidHeight));
            }
        }

        public double K1
        {
            get
            {
                if (WireThickness <= 0.0 || WireWidth <= 0.0)
                {
                    return 0.0;
                }

                double bt = WireThickness / WireWidth;

                if (bt < 1.0)
                {
                    bt = 1 / bt;
                }


                // Based on curve fit from M.Wahl 1st Edition p.206
                double[] t = new double[] { 0.0013, -0.0246, 0.1414, 0.0288 };

                double k1 = (t[0] * Math.Pow(bt, 3)) + (t[1] * Math.Pow(bt, 2)) + (t[2] * bt) + t[3];

                return k1;
            }
            
        }

        public double K2
        {
            get
            {
                if(WireThickness <= 0.0 || WireWidth <= 0.0)
                {
                    return 0.0;
                }

                double bt = WireThickness / WireWidth;
                
                if(bt < 1.0)
                {
                    bt = 1 / bt;
                }


                // Based on curve fit from M.Wahl 1st Edition p.206
                double[] t = new double[] { 0.0004, -0.0082, 0.0567, 0.1615 };

                double k2 = (t[0] * Math.Pow(bt, 3)) + (t[1] * Math.Pow(bt, 2)) + (t[2] * bt) + t[3];

                return k2;
            }
        }

        #endregion

        #region Private Methods

        private double GrindAreaTotal
        {
            get
            {
                return GrindAreaEnd1 + GrindAreaEnd2;
            }
        }

        private double CalculateStress(double force)
        {
            if (CrossSection == "Rectangular")
            {
                return 0.0;
            }
            else
            {
                return (8 * MeanDiameter * KW * force) / (Math.PI * Math.Pow(WireDia, 3));
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
        private double grindAreaEnd1;
        private double grindAreaEnd2;
        private bool matchingEnds;
        private double maxSolidHeight;
        private string coilDirection;
        private double squareness;
        private string crossSection;
        private double deadWire;
        private double worksIn;
        private double worksOver;
        private double tipGap1;
        private double tipGap2;

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




        public Compression()
        {
            PartNumber = "New Compression";
            Revision = "NEW";
            DateCreated = DateTime.Today;
            LastUpdated = DateTime.Today;
            Description = string.Empty;
            CreatedBy = "Default";

            Units = "US Customary";

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

            MaxSolidHeight = 0.000;
            Squareness = 3.00;

            GrindAreaEnd1 = 0.75;
            GrindAreaEnd2 = 0.75;
            End1Type = "CEG";
            End2Type = "CEG";
            MatchingEnds = true;

            CoilDirection = "Right";
            CrossSection = "Round";

            DeadWire = 0.0;
            WorksIn = 0.0;
            WorksOver = 0.0;
            TipGap1 = 0.0;
            TipGap2 = 0.0;

        }
    }
}
