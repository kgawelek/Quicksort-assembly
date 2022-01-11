#define Quicksort _declspec(dllexport)

extern "C" {

    Quicksort void swap(int* a, int* b)
    {
        int t = *a;
        *a = *b;
        *b = t;
    }

	Quicksort int quicksort(int arr[], int low, int high)
	{
        int pivot = arr[high];    // pivot
        int i = (low - 1);  // Index of smaller element

        for (int j = low; j <= high - 1; j++)
        {
            // If current element is smaller than or
            // equal to pivot
            if (arr[j] <= pivot)
            {
                i++;    // increment index of smaller element
                swap(&arr[i], &arr[j]);
            }
        }
        swap(&arr[i + 1], &arr[high]);
        return (i + 1);
	}

    
}



