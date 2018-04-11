using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Laboratorinis
{
    class MyDataList : DataList
    {
        class MyLinkedListNode
        {
            public MyLinkedListNode nextNode { get; set; }
            public int data { get; set; }
            public MyLinkedListNode(int data)
            {
                this.data = data;
            }
        }
        MyLinkedListNode headNode;
        MyLinkedListNode prevNode;
        MyLinkedListNode currentNode;
        public MyDataList() { }
        public MyDataList(int n)
        {
            length = n;
            Random rand = new Random();
            headNode = new MyLinkedListNode(rand.Next(0, 999));
            currentNode = headNode;
            for (int i = 1; i < length; i++)
            {
                prevNode = currentNode;
                currentNode.nextNode = new MyLinkedListNode(rand.Next(0, 999));
                currentNode = currentNode.nextNode;
            }
            currentNode.nextNode = null;
        }
        public override int Head()
        {
            currentNode = headNode;
            prevNode = null;
            return currentNode.data;
        }
        public override int Next()
        {
            prevNode = currentNode;
            currentNode = currentNode.nextNode;
            return currentNode.data;
        }

        public override int Get(int i)
        {
            MyLinkedListNode node = headNode;
            while (i != 0 && node != null)
            {
                node = node.nextNode;
                i--;
            }
            return node.data;
        }

        public override void Set(int value)
        {
            currentNode.data = value;
        }

        public override void Set(int value, int i)
        {
            MyLinkedListNode node = headNode;
            while (i != 0 && node != null)
            {
                node = node.nextNode;
                i--;
            }
            node.data = value;
        }

        // Selection sort, realizuotas su listais
        public void SelectionSort()
        {
            MyLinkedListNode entry = headNode;
            while (entry != null)
            {
                MyLinkedListNode min = entry;

                MyLinkedListNode curr = entry;               

                while (curr != null)
                {
                    if (min.data > curr.data)
                        min = curr;
                    curr = curr.nextNode;
                }

                if (min != entry)
                {
                    int number = entry.data;
                    entry.data = min.data;
                    min.data = number;
                }

                entry = entry.nextNode;
            }
        }

        // Quick sort realizuotas su listais
        public void QuickSort(DataList input, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int num = input.Get(start);
            int i = start, k = end;

            while (i < k)
            {
                while (i < k && input.Get(k) >= num)
                {
                    k--;
                }

                input.Set(input.Get(k), i);

                while (i < k && input.Get(i) < num)
                {
                    i++;
                }

                input.Set(input.Get(i), k);
            }

            input.Set(num, i);
            QuickSort(input, start, i - 1);
            QuickSort(input, i + 1, end);
        }
    }
}
