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

        public string Units { get; set; }
        [XmlIgnore()]
        public IUnit UnitSystem { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            
        }

        //public virtual void Calculate()
        //{

        //}

        public enum Hand { Right, Left, Optional }
        public enum DiaType { OD, ID, MD }
        public enum DesignType { WireDia, SpringRate, Stress }
        public enum SpecType { Rate, TwoLoad, RateOneLoad, Dimensional }
        public enum Unit { Imperial, Metric_N, Metric_kg }

        private Material material;
        private string partNumber;
        private string revision;
        private string createdBy;
        private DateTime dateCreated;
        private DateTime lastUpdated;
        private string description;
    }
}
