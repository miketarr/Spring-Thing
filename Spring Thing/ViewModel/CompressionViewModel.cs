using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Spring_Thing.Resources;
using Spring_Thing.Springs;

namespace Spring_Thing.ViewModel
{
    public class CompressionViewModel : BaseViewModel
    {
        public CompressionViewModel()
        {
            currentCompression = new Compression();

            unitSystemList = UnitSystems.Systems;
            materialList = MaterialLibrary.Materials;
            diameterList = DiameterTypes.Diameters;
            specTypeList = SpecTypes.Specs;
            designTypeList = DesignTypes.Designs;
            directionList = CoilDirections.Directions;
            endList = EndTypes.Ends;

            CurrentUnitSystem = CurrentCompression.Units;
            CurrentMaterial = CurrentCompression.Material;
            CurrentDiameterType = CurrentCompression.DiameterType;
            CurrentSpecType = CurrentCompression.SpringDefinition;
            CurrentDesignType = CurrentCompression.DesignConstraint;
            CurrentDirection = CurrentCompression.CoilDirection;
            CurrentEnd1 = CurrentCompression.End1Type;
            CurrentEnd2 = CurrentCompression.End2Type;

            materialCollection = new ObservableCollection<Material>(MaterialList);

            LoadButtonClick = new RelayCommand(new Action<object>(LoadCompression));
            SaveButtonClick = new RelayCommand(new Action<object>(Save));
        }

        public List<Compression> CompressionList
        {
            get { return compressionList; }

            set
            {
                SetProperty(ref compressionList, value);
            }
        }

        public Compression CurrentCompression
        {
            get { return currentCompression; }
            set
            {
                SetProperty(ref currentCompression, value);
            }
        }

        public List<Material> MaterialList
        {
            get
            {
                return materialList;
            }
        }

        public ObservableCollection<Material> MaterialCollection
        {
            get
            {
                return materialCollection;
            }
        }

        public Material CurrentMaterial
        {
            get
            {
                return currentMaterial;
            }
            set
            {
                currentMaterial = value;
                CurrentCompression.Material = value;
                //Console.WriteLine("Changed material to " + CurrentCompression.Material.MaterialName);
            }
        }

        public List<string> DiameterList
        {
            get
            {
                return diameterList;
            }
        }

        public string CurrentDiameterType
        {
            get
            {
                return currentDiameterType;
            }
            set
            {
                currentDiameterType = value;
                CurrentCompression.DiameterType = value;
            }
        }

        public List<string> SpecTypeList
        {
            get
            {
                return specTypeList;
            }
        }

        public string CurrentSpecType
        {
            get
            {
                return currentSpecType;
            }

            set
            {
                currentSpecType = value;
                CurrentCompression.SpringDefinition = value;
            }
        }

        public List<string> DesignTypeList
        {
            get
            {
                return designTypeList;
            }
        }

        public string CurrentDesignType
        {
            get
            {
                return currentDesignType;
            }

            set
            {
                currentDesignType = value;
                CurrentCompression.DesignConstraint = value;
            }
        }

        public List<string> UnitSystemList
        {
            get
            {
                return unitSystemList;
            }
        }
        public string CurrentUnitSystem
        {
            get
            {
                return currentUnitSystem;
            }
            set
            {
                currentUnitSystem = value;
                CurrentCompression.Units = value;

            }
        }
        public List<string> DirectionList
        {
            get
            {
                return directionList;
            }
        }
        

        public List<string> EndList
        {
            get
            {
                return endList;
            }
        }

        public string CurrentDirection
        {
            get
            {
                return currentDirection;
            }

            set
            {
                currentDirection = value;
                CurrentCompression.CoilDirection = value;
            }
        }

        public string CurrentEnd1
        {
            get
            {
                return currentEnd1;
            }

            set
            {
                currentEnd1 = value;
                CurrentCompression.End1Type = value;
            }
        }

        public string CurrentEnd2
        {
            get
            {
                return currentEnd2;
            }
            set
            {
                currentEnd2 = value;
                CurrentCompression.End2Type = value;
            }
        }

        public string PartNumber
        {
            get
            {
                return CurrentCompression.PartNumber;
            }
        }

        private Compression currentCompression;
        private readonly List<Material> materialList;
        private List<Compression> compressionList;
        private readonly ObservableCollection<Material> materialCollection;
        private Material currentMaterial;
        private readonly List<string> diameterList;
        private string currentDiameterType;
        private readonly List<string> specTypeList;
        private string currentSpecType;
        private readonly List<string> designTypeList;
        private string currentDesignType;
        private readonly List<string> directionList;
        private string currentDirection;
        private readonly List<string> endList;
        private string currentEnd1;
        private string currentEnd2;
        private string currentUnitSystem;
        private readonly List<string> unitSystemList;

        private ICommand loadButtonClick;
        private ICommand saveButtonClick;

        public ICommand LoadButtonClick
        {
            get { return loadButtonClick; }
            set { loadButtonClick = value; }
        }

        public ICommand SaveButtonClick
        {
            get
            {
                return saveButtonClick;
            }
            set
            {
                saveButtonClick = value;
            }
        }

        public void LoadCompression(object obj)
        {
            XMLStuff opener = new XMLStuff();
            CurrentCompression = opener.ReadCompression();
        }

        public void Save(object obj)
        {
            XMLStuff saver = new XMLStuff();
            saver.SaveCompression(CurrentCompression);
        }

    }
}
