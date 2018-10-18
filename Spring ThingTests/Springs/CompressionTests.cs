using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring_Thing.Springs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spring_Thing.Resources;

namespace Spring_Thing.Springs.Tests
{
    [TestClass()]
    public class CompressionTests
    {
        [TestMethod()]
        public void CalculateTest()
        {
            Compression c = new Compression()
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
                Diameter = 2.5
            };

            //Test_Compression test = new Test_Compression();
            double wire = 0.367;
            string diatype = "OD";
            int gmod = 10600000;
            double springrate = 495.3789686;
            double od = 2.5;

            //c = c.MakeACompressionSpring();

            Assert.AreEqual(c.WireDia, wire);
            Assert.AreEqual(c.DiameterType, diatype);
            Assert.AreEqual(c.Material.GMod, gmod);
            Assert.AreEqual(c.MeanDiameter, (od - wire));

            Assert.AreEqual(c.SpringRate, springrate, 0.001);

        }

        [TestMethod()]
        public void ActiveCoilsTest()
        {
            double activecoils = 30.0;
            Compression compression = new Compression()
            {
                TotalCoils = 32.0,
                End1Type = "CEG",
                End2Type = "CEG"
            };

            Assert.AreEqual(activecoils, compression.ActiveCoils);

            compression.End1Type = "CENG";
            compression.End2Type = "OEG";
            activecoils = 31.5;

            Assert.AreEqual(activecoils, compression.ActiveCoils);

        }
    }
}