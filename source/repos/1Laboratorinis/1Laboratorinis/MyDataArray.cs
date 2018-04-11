using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Laboratorinis
{
    class MyDataArray : DataArray
    {
        int[] data;
        public MyDataArray(int n)
        {
            data = new int[n];
            length = n;
            Random rand = new Random();
            for (int i = 0; i < length; i++)
            {
                data[i] = rand.Next(0, 999);
            }
        }

        public override double this[int index]
        {
            get { return data[index]; }
        }

        // Selection sort realizuotas su masyvais
        public void SelectionSort()
        {
            for (int i = 0; i < data.Length - 1; i++)
            {
                int min_key = i;
                for (int k = i + 1; k < data.Length; k++)
                {
                    if (data[k] < data[min_key])
                        min_key = k;
                }


                if (min_key != i)
                {
                    int temp = data[min_key];
                    data[min_key] = data[i];
                    data[i] = temp;
                }
            }
        }

        // Quick sort realizuotas su masyvais
        public void QuickSort()
        {
            QuickSort(0, data.Length - 1);
        }

        public void QuickSort(int start, int end)
        {
            if (start >= end)
            {
                return;
            }            

            int left = start;
            int right = end;


            int temp = data[left];

            while (left < right)
            {
                while (left < right && data[right] >= temp)                
                    right--;                

                data[left] = data[right];

                while (left < right && data[left] < temp)                
                    left++;                

                data[right] = data[left];
            }

            data[left] = temp;
            QuickSort(start, left - 1);
            QuickSort(left + 1, end);
        }
    }
}
