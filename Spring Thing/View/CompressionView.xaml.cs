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
    /// Interaction logic for CompressionView.xaml
    /// </summary>
    public partial class CompressionView : UserControl
    {
        private List<TextBox> RateTextBoxes;
        private List<TextBox> LoadTextBoxes;
        private List<TextBox> DimensionalTextBoxes;
        private List<TextBox> RatePlusLoadTextBoxes;
        private List<TextBox> AllTextBoxes;
        private List<Control> MatchingEndsList;

        public CompressionView()
        {
            InitializeComponent();

            AssignEventsToTextBoxes();

            InitializeTextBoxes();
        }

        private void InitializeTextBoxes()
        {
            RateTextBoxes = new List<TextBox>
            {
                TextLoad1,
                TextLoad2,
                TextLoad1Tolerance,
                TextLoad2Tolerance,
                TextLength1,
                TextLength2,
                TextTotalCoils,
                TextTotalCoilsTolerance,
                TextTravel
            };

            LoadTextBoxes = new List<TextBox>
            {
                TextSpringRate,
                TextSpringRateTolerance,
                TextTravel,
                TextTravelTolerance,
                TextTotalCoils,
                TextTotalCoilsTolerance,
                TextFreeLength,
                TextFreeLengthTolerance
            };

            DimensionalTextBoxes = new List<TextBox>
            {
                TextLoad1,
                TextLoad2,
                TextLoad1Tolerance,
                TextLoad2Tolerance,
                TextLength1,
                TextLength2,
                TextSpringRate,
                TextSpringRateTolerance,
                TextTravel
            };

            RatePlusLoadTextBoxes = new List<TextBox>
            {
                TextLoad1,
                TextLoad1Tolerance,
                TextTotalCoilsTolerance,
                TextTotalCoils,
                TextTravel,
                TextTravelTolerance
            };

            AllTextBoxes = new List<TextBox>
            {
                TextSpringRate,
                TextSpringRateTolerance,
                TextTravel,
                TextTravelTolerance,
                TextTotalCoils,
                TextTotalCoilsTolerance,
                TextFreeLength,
                TextFreeLengthTolerance,
                TextLoad1,
                TextLoad2,
                TextLoad1Tolerance,
                TextLoad2Tolerance,
                TextLength1,
                TextLength2,
                TextTravel,
                TextTravelTolerance
            };

            ToggleReadOnlyStatus();

            MatchingEndsList = new List<Control>
            {
                TextTipGap2,
                TextGrindAreaEnd2,
                ComboEnd2
            };

            ToggleMatchingEndStatus(true);
        }

        private void MakeTextBoxesReadOnly(List<TextBox> list, bool isreadonly)
        {
            if(list == null) { return; }

            foreach(TextBox t in list)
            {
                if (t != null)
                {
                    t.IsReadOnly = isreadonly;
                }
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
            ToggleMatchingEndStatus(true);
        }

        private void CheckBoxMatchingEnds_Unchecked(object sender, RoutedEventArgs e)
        {
            ToggleMatchingEndStatus(false);
        }

        private void ComboSpringDefinition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ToggleReadOnlyStatus(); 
        }

        private void ToggleReadOnlyStatus()
        {
            string selection = ComboSpringDefinition.SelectedValue.ToString();

            MakeTextBoxesReadOnly(AllTextBoxes, false);

            if (selection == "Rate")
            {
                MakeTextBoxesReadOnly(RateTextBoxes, true);
            }

            if (selection == "Two Load")
            {
                MakeTextBoxesReadOnly(LoadTextBoxes, true);
            }

            if (selection == "Dimensional")
            {
                MakeTextBoxesReadOnly(DimensionalTextBoxes, true);
            }
        }

        private void ToggleMatchingEndStatus(bool matching)
        {
            if (CheckBoxMatchingEnds.IsChecked == matching && MatchingEndsList != null)
            {
                foreach (Control c in MatchingEndsList)
                {
                    if (c != null)
                    {
                        c.IsEnabled = !matching;

                    }
                }
            }
        }
    }
}
