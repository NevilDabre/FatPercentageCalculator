/* Group 6
   Assignment - 4
   Abhimanyu Vats
   Aicun Lu
   Neville Dabre
   Angileena Jacob */

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

namespace FatPercentageCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        CalorieCalcVM ccvm;

        public MainWindow()
        {
            InitializeComponent();
            ccvm = new CalorieCalcVM();
            DataContext = ccvm;
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            ccvm.calculate();
        }

        private void cbCheck_Checked(object sender, RoutedEventArgs e)
        {
            if (cbCheck.IsChecked == true)
            {
                lbLowFat.Visibility = Visibility.Visible;
            }
            else {
                lbLowFat.Visibility = Visibility.Hidden;
            }
        }
    }
}
