using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring_Thing.Resources
{
    public interface IUnit
    {
        string UnitName { get; }
        string Length { get; }
        string Force { get; }
        string Weight { get; }
        string Density { get; }
        string Rate { get; }
        string Stress { get; }
        string Frequency { get; }

        double LengthConversion { get; }
        double WeightConversion { get; }
        double ForceConversion { get; }
        double DensityConversion { get; }
        double RateConversion { get; }
        double StressConversion { get; }
        double MaterialStressConversion { get; }
        double SpringEquationConversion { get; }

        double SuggestedLengthTolerance { get; }
        double SuggestedDiameterTolerance { get; }
        double SuggestedWireTolerance { get; }
    }
}
