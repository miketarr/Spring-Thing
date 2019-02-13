using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Spring_Thing.ViewModel
{
    public class DesignDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if(element != null && item != null && item is BaseViewModel)
            {
                BaseViewModel bvm = item as BaseViewModel;

                if(bvm.PartType == "Compression")
                {
                   return element.FindResource("CompressionView") as DataTemplate;
                }
                else
                {
                    return null;
                }
            }

            return null;
        }
    }
}
