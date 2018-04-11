using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Laboratorinis
{
    abstract class DataArray
    {
        protected int length;
        public int Length { get { return length; } }
        public abstract double this[int index] { get; }
        public void Print(int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(" {0} ", this[i]);
            Console.WriteLine();
        }

    }
}
