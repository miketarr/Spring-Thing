using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Spring_Thing.View
{
    /// <summary>
    /// Interaction logic for CompressionDockWindowView.xaml
    /// </summary>
    public partial class CompressionDockWindowView : UserControl
    {
        private List<TextBox> RateTextBoxes;
        private List<TextBox> LoadTextBoxes;
        private List<TextBox> DimensionalTextBoxes;
        private List<TextBox> RatePlusLoadTextBoxes;

        public CompressionDockWindowView()
        {
            InitializeComponent();

            AssignEventsToTextBoxes();

            InitializeTextBoxes();
        }

        private void InitializeTextBoxes()
        {
            RateTextBoxes = new List<TextBox>();
            RateTextBoxes.Add(TextLoad1);
            RateTextBoxes.Add(TextLoad2);
            RateTextBoxes.Add(TextLoad1Tolerance);
            RateTextBoxes.Add(TextLoad2Tolerance);
            RateTextBoxes.Add(TextLength1);
            RateTextBoxes.Add(TextLength2);
            RateTextBoxes.Add(TextTotalCoils);
            RateTextBoxes.Add(TextTotalCoilsTolerance);

            LoadTextBoxes = new List<TextBox>();
            LoadTextBoxes.Add(TextSpringRate);
            LoadTextBoxes.Add(TextSpringRateTolerance);
            LoadTextBoxes.Add(TextTravel);
            LoadTextBoxes.Add(TextTravelTolerance);
            LoadTextBoxes.Add(TextTotalCoils);
            LoadTextBoxes.Add(TextTotalCoilsTolerance);
            LoadTextBoxes.Add(TextFreeLength);
            LoadTextBoxes.Add(TextFreeLengthTolerance);

            DimensionalTextBoxes = new List<TextBox>();
            DimensionalTextBoxes.Add(TextLoad1);
            DimensionalTextBoxes.Add(TextLoad2);
            DimensionalTextBoxes.Add(TextLoad1Tolerance);
            DimensionalTextBoxes.Add(TextLoad2Tolerance);
            DimensionalTextBoxes.Add(TextLength1);
            DimensionalTextBoxes.Add(TextLength2);
            DimensionalTextBoxes.Add(TextSpringRate);
            DimensionalTextBoxes.Add(TextSpringRateTolerance);
            DimensionalTextBoxes.Add(TextTravel);
            DimensionalTextBoxes.Add(TextTravelTolerance);

            RatePlusLoadTextBoxes = new List<TextBox>();
            RatePlusLoadTextBoxes.Add(TextLoad1);
            RatePlusLoadTextBoxes.Add(TextLoad1Tolerance);
            RatePlusLoadTextBoxes.Add(TextTotalCoilsTolerance);
            RatePlusLoadTextBoxes.Add(TextTotalCoils);
            RatePlusLoadTextBoxes.Add(TextTravel);
            RatePlusLoadTextBoxes.Add(TextTravelTolerance);


        }

        private void ToggleTextBoxes(List<TextBox> list, bool isenabled)
        {
            if(list == null) { return; }

            foreach(TextBox t in list)
            {
                t.IsReadOnly = !isenabled;
            }
        }

        private void AssignEventsToTextBoxes()
        {
            foreach (TextBox t in GridMain.Children.OfType<TextBox>())
            {
                t.GotFocus += new RoutedEventHandler(SelectAllText);
                t.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(IgnoreMouseButton);
            }

            foreach (Grid g in GridMain.Children.OfType<Grid>())
            {
                foreach (TextBox t in g.Children.OfType<TextBox>())
                {
                    t.GotFocus += new RoutedEventHandler(SelectAllText);
                    t.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(IgnoreMouseButton);
                }
            }
        }

        private void SelectAllText(object sender, RoutedEventArgs e)
        {
            TextBox tb = (sender as TextBox);

            if(tb != null)
            {
                tb.SelectAll();
            }
        }

        private void IgnoreMouseButton(object sender, MouseButtonEventArgs e)
        {
            TextBox tb = (sender as TextBox);

            if(tb != null)
            {
                if (!tb.IsKeyboardFocusWithin)
                {
                    e.Handled = true;
                    tb.Focus();
                }
            }
        }

        private void CheckBoxMatchingEnds_Checked(object sender, RoutedEventArgs e)
        {
            if(CheckBoxMatchingEnds.IsChecked == true)
            {
                ComboEnd2.IsEnabled = false;
                TextGrindAreaEnd2.IsEnabled = false;
            }
        }

        private void CheckBoxMatchingEnds_Unchecked(object sender, RoutedEventArgs e)
        {
            if (CheckBoxMatchingEnds.IsChecked == false)
            {
                ComboEnd2.IsEnabled = true;
                TextGrindAreaEnd2.IsEnabled = true;
            }
        }

        private void ComboSpringDefinition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selection = ComboSpringDefinition.SelectedValue.ToString();

            if(selection == "Rate")
            {
                ToggleTextBoxes(RateTextBoxes, true);
            }
            else
            {
                ToggleTextBoxes(RateTextBoxes, false);
            }


            if(selection == "Two Load")
            {
                ToggleTextBoxes(LoadTextBoxes, true);
            }
            else
            {
                ToggleTextBoxes(LoadTextBoxes, false);
            }

            if(selection == "Dimensional")
            {
                ToggleTextBoxes(DimensionalTextBoxes, true);
            }
            else
            {
                ToggleTextBoxes(DimensionalTextBoxes, false);
            }


                  
        }
    }
}
