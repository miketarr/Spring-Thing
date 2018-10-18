using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Spring_Thing.Resources;

namespace Spring_Thing.Springs
{
    public partial class Part : INotifyPropertyChanged
    {
        public string PartNumber { get; set; }
        public string Revision { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdated { get; set; }
        public string CreatedBy { get; set; }
        public string Description { get; set; }
        public Material Material { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            Calculate();
        }

        public virtual void Calculate()
        {

        }

        public enum Hand { Right, Left, Optional }
        public enum DiaType { OD, ID, MD }
        public enum DesignType { WireDia, SpringRate, Stress }
        public enum SpecType { Rate, TwoLoad, RateOneLoad, Dimensional}


    }
}
