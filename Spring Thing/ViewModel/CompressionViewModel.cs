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
            materialList = MaterialLibrary.Materials;
            CurrentMaterial = CurrentCompression.Material;
            materialCollection = new ObservableCollection<Material>(MaterialList);
            diameterList = DiameterTypes.Diameters;
            CurrentDiameterType = CurrentCompression.DiameterType;
            LoadButtonClick = new RelayCommand(new Action<object>(LoadTestSpring));
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
                Console.WriteLine("Changed material to " + CurrentCompression.Material.MaterialName);
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

        

        private Compression currentCompression;
        private List<Material> materialList;
        private List<Compression> compressionList;
        private ObservableCollection<Material> materialCollection;
        private Material currentMaterial;
        private List<string> diameterList;
        private string currentDiameterType;
        

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

        public void LoadTestSpring(object obj)
        {
            
        }

        public void Save(object obj)
        {
            XMLStuff saver = new XMLStuff();
            saver.SaveCompression(CurrentCompression);
        }

    }
}
