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
            sorter = new Sorter();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {   if (sorter.getFileName() == null || sorter.getOutputFileName() == null)
            {
                MessageBox.Show("Wybierz plik wejsciowy i wyjsciowy!");
                return;
            }
                
            sorter.sortAsm();

            if (sorter.getDuration().ElapsedMilliseconds == 0)
                asmTime.Content = (sorter.getDuration().Elapsed.TotalMilliseconds * 1000000).ToString() + " ns";
            else
                asmTime.Content = sorter.getDuration().ElapsedMilliseconds.ToString() + " ms";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (sorter.getFileName() == null || sorter.getOutputFileName() == null)
            {
                MessageBox.Show("Wybierz plik wejsciowy i wyjsciowy!");
                return;
            }
            sorter.sortCpp();

            if (sorter.getDuration().ElapsedMilliseconds == 0)
                cppTime.Content = (sorter.getDuration().Elapsed.TotalMilliseconds * 1000000).ToString() + " ns";
            else
                cppTime.Content = sorter.getDuration().ElapsedMilliseconds.ToString() + " ms";
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Documenty"; // Default file name
            dialog.DefaultExt = ".txt"; // Default file extension
            dialog.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                sorter.setFileName(dialog.FileName);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Documenty"; // Default file name
            dialog.DefaultExt = ".txt"; // Default file extension
            dialog.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                sorter.setOutputFileName(dialog.FileName);
            }
        }
    }
}
