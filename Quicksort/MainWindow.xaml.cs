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

namespace Quicksort
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Sorter sorter;
        public MainWindow()
        {
            InitializeComponent();
            sorter = new Sorter(@"D:\studia\JA\Quicksort-assembly\data.txt");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sorter.sortAsm();
            MessageBox.Show(sorter.getDuration().ToString());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            sorter.sortCpp();
            MessageBox.Show(sorter.getDuration().ToString());
        }
    }
}
