using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Laboratorinis
{
    class MyFileArray : DataArray
    {
        private int[] data;
        public MyFileArray(string filename, int n, int seed)
        {
            data = new int[n];
            length = n;
            Random rand = new Random(seed);
            for (int i = 0; i < length; i++)
            {
                data[i] = rand.Next(0, 999);
            }
            if (File.Exists(filename)) File.Delete(filename);
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(filename,
                FileMode.Create)))
                {
                    for (int j = 0; j < length; j++)
                        writer.Write(data[j]);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public FileStream fs { get; set; }
        public override double this[int index]
        {
            get
            {
                Byte[] data = new Byte[8];
                fs.Seek(8 * index, SeekOrigin.Begin);
                fs.Read(data, 0, 8);
                double result = BitConverter.ToDouble(data, 0);
                return result;
            }
        }
        public void Print()
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write(getValue(i) + "  ");
            }
            Console.WriteLine();
        }

        public int getValue(int index)
        {
            byte[] data = new byte[4];
            fs.Seek(4 * index, SeekOrigin.Begin);
            fs.Read(data, 0, 4);
            int result = BitConverter.ToInt32(data, 0);
            return result;
        }

        // Selection sort realizuotas isorineje atmintyje su masyvais
        public void SelectionSort()
        {
            for (int i = 0; i < data.Length - 1; i++)
            {
                int min_key = i;
                for (int j = i + 1; j < data.Length; j++)
                    if (getValue(j) < getValue(min_key))
                        min_key = j;
                if (min_key != i)
                {
                    int temp = getValue(min_key);
                    Set(min_key, getValue(i));
                    Set(i, temp);
                }
            }
        }

        // Quick sort realizuotas isorineje atmintyje su masyvais
        public void QuickSort()
        {
            QuickSort(0, data.Length - 1);
        }

        public void QuickSort(int start, int end)
        {
            if (start >= end)            
                return;         

            int left = start;
            int right = end;

            int num = getValue(left);

            while (left < right)
            {
                while (left < right && getValue(right) >= num)                
                    right--;                

                Set(left, getValue(right));

                while (left < right && getValue(left) < num)                
                    left++;                

                Set(right, getValue(left));
            }

            Set(left, num);
            QuickSort(start, left - 1);
            QuickSort(left + 1, end);
        }

        public void Set(int index, int a)
        {
            Byte[] data = new Byte[4];
            BitConverter.GetBytes(a).CopyTo(data, 0);
            fs.Seek(4 * index, SeekOrigin.Begin);
            fs.Write(data, 0, 4);
        }
    }
}
