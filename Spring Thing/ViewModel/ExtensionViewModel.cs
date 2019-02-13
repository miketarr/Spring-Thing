using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spring_Thing.Springs;

namespace Spring_Thing.ViewModel
{
    public class ExtensionViewModel : BaseViewModel
    {
        public ExtensionViewModel()
        {

        }

        public Extension CurrentExtension
        {
            get { return currentExtension; }
            set
            {
                SetProperty(ref currentExtension, value);
            }
        }

        private Extension currentExtension;
    }
}
