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

        public enum Hand
        {
            [Description("Right")]
            Right,
            [Description("Left")]
            Left,
            [Description("Optional")]
            Optional
        }

        //public enum DiaType
        //{
        //    [Description("Outside Diameter")]
        //    OD,
        //    [Description("Inside Diameter")]
        //    ID,
        //    [Description("Mean Diameter")]
        //    MD
        //}

        public enum DesignType
        {
            [Description("Wire Diameter")]
            WireDia,
            [Description("Spring Rate")]
            SpringRate,
            [Description("Stress")]
            Stress
        }

        //public enum SpecType
        //{
        //    [Description("Spring Rate")]
        //    Rate,
        //    [Description("Two Loads")]
        //    TwoLoad,
        //    [Description("Rate + Load")]
        //    RateOneLoad,
        //    [Description("Dimensional")]
        //    Dimensional
        //}

        public enum Unit
        {
            [Description("Imperial")]
            Imperial,
            [Description("Metric")]
            Metric
        }

        private Material material;
        private string partNumber;
        private string revision;
        private string createdBy;
        private DateTime dateCreated;
        private DateTime lastUpdated;
        private string description;
    }
}
