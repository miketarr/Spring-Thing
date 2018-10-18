using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring_Thing.Resources
{
    /*  This library is generic material for basic use and testing purposes
     *  All material properties were taken from 
     *  Fundamentals of Machine Component Design Fourth Edition
     *  Robert C. Juvinall and Kurt M. Marshek
     *  Copyright 2006 John Wiley & Sons Inc.
     *  
     *  Facts aren't copyrightable. These are facts.
     */

    public static class MaterialLibrary
    {
        public static List<Material> Materials;

        static MaterialLibrary()
        {
            Materials = new List<Material>();
            Material Stainless302 = new Material
            {
                MaterialName = "Stainless 302",
                MaterialDescription = "Stainless 302 (Round)",
                Specification = "ASTM YADA YADA",
                EMod = 27500000,
                GMod = 10600000,
                PoissonsRatio = 0.30,
                Density = 0.28,
                MaxSize = 0.625,
                StrengthUltimate = 92000,
                StrengthYield = 34000,
                CrossSection = "Round",
                Units = "Imperial"
            };
            Materials.Add(Stainless302);
        }

        public static Material SelectMaterial(string mat)
        {
            Material material = null;

            if(Materials.Find(x => x.MaterialName == mat) != null)
            {
                return Materials.Find(x => x.MaterialName == mat);
            }

            return material;
        }
    }
}
