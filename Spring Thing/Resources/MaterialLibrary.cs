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
            //Materials = new List<Material>();
            Material Stainless302 = new Material
            {
                Units = "Metric",
                //materialUnits = new Unit_Metric(),
                MaterialName = "Stainless 302",
                MaterialDescription = "Stainless 302",
                Specification = "ASTM YADA YADA",
                //EMod = 27500000,
                EMod = 190E9,
                //GMod = 10600000,
                GMod = 73E9,
                PoissonsRatio = 0.30,
                //Density = 0.28,
                Density = 7.75E-6,      // kg/mm^3
                //MaxSize = 0.625,
                MaxSize = 15.87,
                //StrengthUltimate = 92000,
                StrengthUltimate = 6.373E8,
                //StrengthYield = 34000,
                StrengthYield = 2.344E8       
            };

            Material Stainless177 = new Material
            {
                // from http://www.springhouston.com/materials/stainless-steel/17-7-ph-spring.html
                Units = "Metric",
                MaterialName = "Stainless 17-7",
                MaterialDescription = "Stainless 17-7",
                Specification = "ASTM YADA YADA",
                //EMod = 29500000,
                EMod = 203000E6,  //Pa
                //GMod = 11000000,
                GMod = 75800E6,   //Pa
                PoissonsRatio = 0.30,
                //Density = 0.282,
                Density = 7.806E-6,
                //MaxSize = 0.625,
                MaxSize = 15.875,
                StrengthUltimate = 6.373E8,
                StrengthYield = 2.344E8

                //materialUnits = new Unit_Metric()
            };
            //Materials.Add(Stainless302);
            //Materials.Add(Stainless177);

            Materials = new List<Material>()
            {
                Stainless302,
                Stainless177
            };
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
