using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Quicksort
{
     class Sorter
    {
        string fileName;
        int [] numbersToSort;
        double duration;

        public Sorter()
        {

        }

        public Sorter(string fileName)
        {
            this.fileName = fileName;
            
        }

        public void readData()
        {
            
            string text = File.ReadAllText(fileName);
            string[] bits = text.Split(' ');
            numbersToSort = new int[bits.Length];
            for(int i = 0; i < bits.Length; i++)
            {
                numbersToSort[i] = int.Parse(bits[i]);
            }
            
            
        }

        public async void saveData()
        {
            String line = "";
            for (int i = 0; i < numbersToSort.Length; i++)
            {
                line += numbersToSort[i] + " ";
            }
           await File.WriteAllTextAsync(@"C:\Users\konga\source\repos\Quicksort\output.txt", line);
        }

        public void printArr()
        {
            for (int i = 0; i < numbersToSort.Length; i++)
            {
                Debug.WriteLine(numbersToSort[i]);
            }
        }

        public unsafe void sortAsm()
        {
            readData();
            //printArr();

            int start, stop;
            start = Environment.TickCount & Int32.MaxValue;

            quicksortForAsm(numbersToSort, 0, numbersToSort.Length - 1);

            stop = Environment.TickCount & Int32.MaxValue;
            duration = stop - start;

            //printArr();
            Debug.WriteLine(duration);
            saveData();

        }

        [DllImport(@"C:\Users\konga\source\repos\Quicksort\x64\Debug\AsmDLL.dll")]
        static extern unsafe int Sort(int * arr, int low, int high);
        

        public unsafe void quicksortForAsm(int [] arr, int low, int high)
        {
            if (low < high)
            {
                /* pi is partitioning index, arr[p] is now
                   at right place */
                fixed (int* ptr = &numbersToSort[0])
                {
                    int pi = Sort(ptr, low, high);
                    // Separately sort elements before
                    // partition and after partition
                    quicksortForAsm(arr, low, pi - 1);
                    quicksortForAsm(arr, pi + 1, high);
                }
                    

                
            }
        }

        public const string CppDLL = @"C:\Users\konga\source\repos\Quicksort\x64\Debug\CppSort.dll";
        [DllImport(CppDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void quicksort(int []arr, int low, int high);
        public void sortCpp()
        {
            readData();
            //printArr();

            int start, stop;
            start = Environment.TickCount & Int32.MaxValue;

            quicksort(numbersToSort, 0, numbersToSort.Length - 1);

            stop = Environment.TickCount & Int32.MaxValue;
            duration = stop - start;

            //printArr();
            Debug.WriteLine(duration);
            saveData();
        }
    }
}
