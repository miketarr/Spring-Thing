using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring_Thing.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring_Thing.Resources.Tests
{
    [TestClass()]
    public class MaterialLibraryTests
    {
        [TestMethod()]
        public void SelectMaterialTest()
        {
            string materialname = "Stainless 302";
            int emod = 27500000;

            Material material = MaterialLibrary.SelectMaterial(materialname);

            Assert.AreEqual(material.MaterialName, materialname);
            Assert.AreEqual(material.EMod, emod);
        }
    }
}