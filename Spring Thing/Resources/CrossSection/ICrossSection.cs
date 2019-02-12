using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring_Thing.Resources
{
    public interface ICrossSection
    {
        string SectionName { get; }

        double StressLoad1 { get; }
        double StressLoad2 { get; }
        double StressSolid { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gmod">Torsion Modulus</param>
        /// <param name="wd_dim1">Primary wire dimension</param>
        /// <param name="wd_dim2">Secondary wire dimension</param>
        /// <param name="activecoils">Active Coils</param>
        /// <param name="meandiameter">Mean Diameter</param>
        /// <returns></returns>
        double SpringRate(double gmod, double wd_dim1, double wd_dim2, double activecoils, double meandiameter);
    }
}
