using System;
using System.Collections.Generic;
using System.Windows.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Spring_Thing.Resources;

namespace Spring_Thing.ViewModel
{
    public class MaterialViewModel : BaseViewModel
    {
        public MaterialViewModel()
        {
            materialList = new List<Material>();
            materialList = MaterialLibrary.Materials;
            materialCollection = new CollectionView(materialList);

        }

        public CollectionView MaterialCollection
        {
            get
            {
                return materialCollection;
            }
        }

        public Material SingleMaterial
        {
            get
            {
                return singleMaterial;
            }
            set
            {
                singleMaterial = value;
            }
        }

        private List<Material> materialList;

        private Material singleMaterial;

        private CollectionView materialCollection;

    }
}
