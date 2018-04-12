using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Laboratorinis
{
    class Program
    {
        static void Main(string[] args)
        {
            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;
            Test_Array_OP(seed);
            seed = (int)DateTime.Now.Ticks & 0x0000FFFF;
            Test_List_OP(seed);
            seed = (int)DateTime.Now.Ticks & 0x0000FFFF;
            Test_Array_Disk(seed);
            seed = (int)DateTime.Now.Ticks & 0x0000FFFF;
            Test_List_D(seed);
            //OP_Sort_Speed_Test();
            D_Sort_Speed_Test(seed);
            
        }


        public static void Test_Array_OP(int seed)
        {
            Console.WriteLine("\n Operatyvioji atmintis: \n");
            int n = 12;            
            Console.WriteLine("\n Selection sort ARRAY: \n");
            MyDataArray myArray = new MyDataArray(n);
            myArray.Print(n);
            myArray.SelectionSort();
            myArray.Print(n);          

            Console.WriteLine("\n Quick sort ARRAY: \n");
            MyDataArray myArray2 = new MyDataArray(n);
            myArray2.Print(n);
            myArray2.QuickSort();
            myArray2.Print(n);            

            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------");

        }

        public static void Test_List_OP(int seed)
        {
            int n = 12;
            Console.WriteLine("\n Selection sort LIST: \n");           
            MyDataList myList = new MyDataList(n);          
            myList.Print(n);
            myList.SelectionSort();
            myList.Print(n);                  

            Console.WriteLine("\n Quick sort LIST: \n");          
            MyDataList myList2 = new MyDataList(n);            
            myList2.Print(n);
            myList2.QuickSort(myList2, 0, myList2.Length - 1);
            myList2.Print(n);

            Console.WriteLine();
            Console.WriteLine("____________________________________________________________");
            Console.WriteLine("____________________________________________________________");
        }




        public static void Test_Array_Disk(int seed)
        {
            Console.WriteLine("\n Isorine atmintis: \n");
            int n = 12;            
            string fileName;
            fileName = @"mydataaray.dat";
            MyFileArray myFileArray = new MyFileArray(fileName, n, seed);
            using (myFileArray.fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
            {                
                Console.WriteLine("\n Selection sort ARRAY: \n");
                myFileArray.Print();
                Console.WriteLine();
                myFileArray.SelectionSort();
                myFileArray.Print();
            }
            Console.WriteLine("\n------------------------------------------------------------\n");
            string fileName2 = @"mydataaray.dat";
            MyFileArray myFileArray2 = new MyFileArray(fileName2, n, seed);
            using (myFileArray2.fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
            {
                Console.WriteLine("\n Quick sort ARRAY: \n");
                myFileArray2.Print();
                Console.WriteLine();
                myFileArray2.QuickSort();
                myFileArray2.Print();
            }
            Console.WriteLine("\n------------------------------------------------------------\n");

        }

        public static void Test_List_D(int seed)
        {
            int n = 12;
            string filename = @"mydatalist.dat";
            MyFileList myfilelist = new MyFileList(filename, n, seed);
            using (myfilelist.fs = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite))
            {
                Console.WriteLine("\n Selection sort LIST \n");
                myfilelist.Print(n);
                Selection_Sort_List(myfilelist);
                myfilelist.Print(n);
            }
            Console.WriteLine();
            Console.WriteLine("____________________________________________________________");
            Console.WriteLine("____________________________________________________________");

        }

        public static void OP_Sort_Speed_Test()
        {
            Console.WriteLine();
            Console.WriteLine(" Speed test OP: ");
            Console.WriteLine("\n Selection sort ARRAY: \n");
            int[] length = { 400, 800, 1600, 3200, 6400, 12800, 25600 };
            
            for (int i = 0; i < length.Length; i++)
            {
                MyDataArray n = new MyDataArray(length[i]);
                Stopwatch t = new Stopwatch();
                t.Start();
                n.SelectionSort();
                t.Stop();
                TimeSpan e = t.Elapsed;
                Console.WriteLine("Amount of data: {0,5} --->>> Time elapsed: {1}", length[i], e.ToString());
            }
            Console.WriteLine();
          

            Console.WriteLine("\n Selection sort LIST: \n");
            for (int i = 0; i < length.Length; i++)
            {
                MyDataList n = new MyDataList(length[i]);
                Stopwatch t = new Stopwatch();
                t.Start();
                n.SelectionSort();
                t.Stop();
                TimeSpan e = t.Elapsed;
                Console.WriteLine("Amount of data: {0,5} --->>> Time elapsed: {1}", length[i], e.ToString());
            }
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------");
            
            Console.WriteLine("\n Quick sort ARRAY: \n");
            for (int i = 0; i < length.Length; i++)
            {
                MyDataArray n = new MyDataArray(length[i]);
                Stopwatch t = new Stopwatch();
                t.Start();
                n.QuickSort();
                t.Stop();
                TimeSpan e = t.Elapsed;
                Console.WriteLine("Amount of data: {0,5} --->>> Time elapsed: {1}", length[i], e.ToString());
            }
            Console.WriteLine();
            

            Console.WriteLine("\n Quick sort LIST: \n");
            for (int i = 0; i < length.Length; i++)
            {
                MyDataList n = new MyDataList(length[i]);
                Stopwatch t = new Stopwatch();
                t.Start();
                n.QuickSort(n, 0, n.Length - 1);
                t.Stop();
                TimeSpan e = t.Elapsed;
                Console.WriteLine("Amount of data: {0,5} --->>> Time elapsed: {1}", length[i], e.ToString());
            }

            Console.WriteLine("____________________________________________________________");
            Console.WriteLine("____________________________________________________________");

        }

        public static void D_Sort_Speed_Test(int seed) 
        {            
          
            Console.WriteLine(" Speed Test D ");
            Console.WriteLine("\n Selection sort ARRAY: \n");
            int[] length = { 400, 800, 1600, 3200, 6400 };
            int[] length2 = { 400, 800, 1600, 3200, 6400, 12800 };
            int[] length3 = { 100, 200, 400};
            string fileName;
            fileName = @"mydataaray.dat";
            string fileName2 = @"mydataaray2.dat";
            string filename3 = @"mydatalist.dat";
            for (int i = 0; i < length3.Length; i++)
            {
                MyFileArray n = new MyFileArray(fileName, length3[i], seed);
                using (n.fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
                {
                    Stopwatch t = new Stopwatch();
                    t.Start();
                    n.SelectionSort();
                    t.Stop();
                    TimeSpan e = t.Elapsed;
                    Console.WriteLine("Amount of data {0,5} --->>> Time elapsed: {1}", length3[i], e.ToString());
                }
            }
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("\n Quick sort ARRAY \n");
            for (int i = 0; i < length2.Length; i++)
            {
                MyFileArray n = new MyFileArray(fileName2, length2[i], seed);
                using (n.fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
                {
                    Stopwatch t = new Stopwatch();
                    t.Start();
                    n.QuickSort();
                    t.Stop();
                    TimeSpan e = t.Elapsed;
                    Console.WriteLine("Amount of data {0,5} --->>> Time elapsed: {1}", length2[i], e.ToString());
                }
            }

            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("\n Selection sort LIST \n");
            for (int i = 0; i < length2.Length; i++)
            {
                MyFileList n = new MyFileList(filename3, length3[i], seed);
                using (n.fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
                {
                    Stopwatch t = new Stopwatch();
                    t.Start();
                    Selection_Sort_List(n);
                    t.Stop();
                    TimeSpan e = t.Elapsed;
                    Console.WriteLine("Amount of data {0,5} --->>> Time elapsed: {1}", length3[i], e.ToString());
                }
            }
        }

        public static void Selection_Sort_List(MyFileList list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                int min = i;
                int minVal = list.GetNode(i);
                for (int j = i + 1; j < list.Length; j++)
                {
                    int tempVal = list.GetNode(j);
                    if (tempVal < minVal)
                    {
                        min = j;
                        minVal = tempVal;
                    }
                }
                int iVal = list.GetNode(i);
                list.Set2(minVal);
                list.GetNode(min);
                list.Set2(iVal);
            }


        }
    }
}
