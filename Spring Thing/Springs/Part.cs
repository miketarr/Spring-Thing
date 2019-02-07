using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Spring_Thing.Resources;
using System.Xml.Serialization;

namespace Spring_Thing.Springs
{
    public partial class Part : INotifyPropertyChanged
    {
        public string PartNumber
        {
            get { return partNumber; }
            set
            {
                partNumber = value;
                OnPropertyChanged(string.Empty);
            }
        }
        public string Revision
        {
            get { return revision; }
            set
            {
                revision = value;
                OnPropertyChanged(string.Empty);
            }
        }
        public DateTime DateCreated
        {
            get { return dateCreated; }
            set
            {
                dateCreated = value;
                OnPropertyChanged(string.Empty);
            }
        }
        public DateTime LastUpdated
        {
            get { return lastUpdated; }
            set
            {
                lastUpdated = value;
                OnPropertyChanged(string.Empty);
            }
        }
        public string CreatedBy
        {
            get { return createdBy; }
            set
            {
                createdBy = value;
                OnPropertyChanged(string.Empty);
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged(string.Empty);
            }
        }
        public Material Material
        {
            get
            {
                return material;
            }
            set
            {
                material = value;
                OnPropertyChanged(string.Empty);
            }
        }
        public virtual string SpringType { get; set; }
        public virtual string CrossSection { get; set; }

        [XmlIgnore()]
        public IUnit UnitSystem
        {
            get
            {
                return unitSystem;
            }

            private set
            {
                unitSystem = value;
                OnPropertyChanged(string.Empty);
            }
        }

        public string Units
        {
            get
            {
                return units;
            }
            set
            {
                units = value;
                OnPropertyChanged(string.Empty);
                if(value == "Metric")
                {
                    UnitSystem = new Unit_Metric();
                    if(Material != null)
                    {
                        Material.Units = "Metric";
                    }
                    
                }
                else if(value == "US Customary")
                {
                    UnitSystem = new Unit_US();
                    if(Material != null)
                    {
                        Material.Units = "US Customary";
                    }
                    
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));          
        }

        private Material material;
        private string partNumber;
        private string revision;
        private string createdBy;
        private DateTime dateCreated;
        private DateTime lastUpdated;
        private string description;
        private string units;
        private IUnit unitSystem;

    }
}
