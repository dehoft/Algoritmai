using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Laboratorinis
{
    abstract class DataList
    {
        public int maxLength;
        protected int length;
        public int Length { get { return length; } }
        public abstract int Head();
        public abstract int Next();
        public abstract int Get(int i);
        public abstract void Set(int value);
        public abstract void Set(int value, int i);
        public void Print(int n)
        {
            Console.Write(" {0} ", Head());
            for (int i = 1; i < n; i++)
                Console.Write(" {0} ", Next());
            Console.WriteLine();
        }
    }
}
