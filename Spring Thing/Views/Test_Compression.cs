using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spring_Thing.Springs;
using Spring_Thing.Resources;

namespace Spring_Thing.Views
{
    public class Test_Compression
    {
        public Compression MakeACompressionSpring()
        {
            Compression compression = new Compression
            {
                PartNumber = "TEST PART",
                Revision = "A",
                DateCreated = DateTime.Today,
                LastUpdated = DateTime.Today,
                CreatedBy = "Smapti Drtbrt",
                WireDia = 0.367,
                DiameterType = "OD",
                Material = MaterialLibrary.SelectMaterial("Stainless 302"),
                End1Type = "CEG",
                End2Type = "CEG",
                TotalCoils = 7.0,
                Diameter = 2.5,
                Squareness = 3.0,
                CoilDirection = "Right"     
            };

            return compression;
        }
    }
}
