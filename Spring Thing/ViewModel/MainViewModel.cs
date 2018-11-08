using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring_Thing.ViewModel
{
    public class MainViewModel
    {
        public DockManagerViewModel DockManagerViewModel { get; private set; }
        public MenuViewModel MenuViewModel { get; private set; }

        public MainViewModel()
        {
            var documents = new List<DockWindowViewModel>();

            for (int i = 0; i < 3; i++)
            {
                documents.Add(new CompressionDockWindowViewModel() { Title = "Spring " + i.ToString() });
            }

            this.DockManagerViewModel = new DockManagerViewModel(documents);
            this.MenuViewModel = new MenuViewModel(documents);
        }
    }
}
