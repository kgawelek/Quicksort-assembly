using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Quicksort
{
     class Sorter
    {
        string fileName;
        string outputFileName;
        int [] numbersToSort;
        Stopwatch duration;

        public Sorter()
        {

        }

        public Sorter(string fileName, string outputFileName)
        {
            this.fileName = fileName;
            this.outputFileName = outputFileName;
            
        }

        public void setFileName(string fileName)
        {
            this.fileName = fileName;
        }

        public void setOutputFileName(string fileName)
        {
            this.outputFileName = fileName;
        }

        public string getFileName()
        {
            return fileName;
        }

        public string getOutputFileName()
        {
            return outputFileName;
        }

        public void readData()
        {

            string[] bits = File.ReadAllText(fileName).Split(' ');
            numbersToSort = new int[bits.Length];
            for(int i = 0; i < bits.Length; i++)
            {
                if (!(bits[i].Any(c => c < '0' || c > '9') || bits[i] == null || bits[i] == ""))
                    numbersToSort[i] = int.Parse(bits[i]);
            }
            
            
        }

        public Stopwatch getDuration()
        {
            return duration;
        }

        public async void saveData()
        {
            String line = "";
            for (int i = 0; i < numbersToSort.Length; i++)
            {
                line += numbersToSort[i] + " ";
            }
           await File.WriteAllTextAsync(outputFileName, line);
        }

        public void printArr()
        {
            for (int i = 0; i < numbersToSort.Length; i++)
            {
                Debug.WriteLine(numbersToSort[i]);
            }
        }

        public void sortAsm()
        {
            readData();

            duration = Stopwatch.StartNew();
            quicksortForAsm(numbersToSort, 0, numbersToSort.Length - 1);
            duration.Stop();
            
            saveData();

        }

        [DllImport(@"D:\studia\JA\Quicksort-assembly\x64\Release\AsmDLL.dll")]
        static extern int Sort(int [] arr, int low, int high);       

        public void quicksortForAsm(int [] arr, int low, int high)
        {
            if (low < high)
            {
                /* pi is partitioning index, arr[p] is now
                   at right place */
                int pi = Sort(arr, low, high);

                // Separately sort elements before
                // partition and after partition
                quicksortForAsm(arr, low, pi - 1);
                quicksortForAsm(arr, pi + 1, high);                   
                
            }
        }

        public void sortCpp()
        {
            readData();

            duration = Stopwatch.StartNew();
            quicksortForCpp(numbersToSort, 0, numbersToSort.Length - 1);
            duration.Stop();

            saveData();
        }

        public const string CppDLL = @"D:\studia\JA\Quicksort-assembly\x64\Release\CppSort.dll";
        [DllImport(CppDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int quicksort(int []arr, int low, int high);

        public void quicksortForCpp(int[] arr, int low, int high)
        {
            if (low < high)
            {
                /* pi is partitioning index, arr[p] is now
                   at right place */
                int pi = quicksort(arr, low, high);

                // Separately sort elements before
                // partition and after partition
                quicksortForCpp(arr, low, pi - 1);
                quicksortForCpp(arr, pi + 1, high);

            }
        }

        
    }
}
