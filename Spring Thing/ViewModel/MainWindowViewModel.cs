using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;
using Spring_Thing.View;


namespace Spring_Thing.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        public MainWindowViewModel()
        {
            TabObjects = new ObservableCollection<TabItem>();

            //TabItem myItem = new TabItem();
            //myItem.Header = "POOP";
            //myItem.Content = new CompressionView();
            //TabObjects.Add(myItem);

            NewCompression(null);

            SaveDesignCommand = new RelayCommand(new Action<object>(SaveDesign));
            NewCompressionCommand = new RelayCommand(new Action<object>(NewCompression));
        }

        public ICommand SaveDesignCommand
        {
            get;
            private set;
        }

        public ICommand NewCompressionCommand
        {
            get;
            private set;
        }

        private void SaveDesign(object obj)
        {
            //Saving Stuff here
            
            Console.WriteLine("Save Button Clicked But Nothing Saved");
        }

        private void NewCompression(object obj)
        {
            TabItem tabObject = new TabItem() { Header = "New Compression", Content = new CompressionView() };

            TabObjects.Add(tabObject);
        }

        public ObservableCollection<TabItem> TabObjects
        {
            get
            {
                return tabObjects;
            }
            set
            {
                tabObjects = value;
                OnPropertyChanged("TabItems");
            }
        }
        private ObservableCollection<TabItem> tabObjects;

    }
}
