using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Laboratorinis
{
    class MyFileList : DataList
    {
        class MyLinkedListNode
        {
            public MyLinkedListNode nextNode { get; set; }
            public int data { get; set; }
            public int maxLength = 0;
            public MyLinkedListNode(int data)
            {
                this.data = data;
            }
        }
        int prevNode;
        int currentNode;
        int nextNode;
        //Moodle pvz
        public MyFileList(string filename, int n, int seed)
        {
            length = n;
            Random rand = new Random();
            if (File.Exists(filename)) File.Delete(filename);
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(filename,
               FileMode.Create)))
                {
                    writer.Write(4);
                    for (int j = 0; j < length; j++)
                    {
                        writer.Write(rand.Next(0, 999));
                        writer.Write((j + 1) * 8 + 4);

                        if (rand.ToString().Length > maxLength)
                            maxLength = rand.ToString().Length;
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public FileStream fs { get; set; }

        public override int Next()
        {
            Byte[] data = new Byte[8];
            fs.Seek(nextNode, SeekOrigin.Begin);
            fs.Read(data, 0, 8);
            prevNode = currentNode;
            currentNode = nextNode;
            int result = BitConverter.ToInt32(data, 0);
            nextNode = BitConverter.ToInt32(data, 4);
            return result;
        }
        public override int Head()
        {
            Byte[] data = new Byte[8];
            fs.Seek(0, SeekOrigin.Begin);
            fs.Read(data, 0, 4);
            currentNode = BitConverter.ToInt32(data, 0);
            prevNode = -1;
            fs.Seek(currentNode, SeekOrigin.Begin);
            fs.Read(data, 0, 8);
            int result = BitConverter.ToInt32(data, 0);
            nextNode = BitConverter.ToInt32(data, 4);
            return result;
        }

        public int GetNode(int index)
        {
            int result = Head();
            if (index == 0)
                return result;

            for (int i = 1; i <= index; i++)
                result = Next();

            return result;
        }

        public void Set2(int value)
        {
            Byte[] data;
            fs.Seek(currentNode, SeekOrigin.Begin);
            data = BitConverter.GetBytes(value);
            fs.Write(data, 0, 4);
        }



        public Microsoft.Win32.SafeHandles.SafeFileHandle FileName { get; set; }

        public override void Set(int value)
        {
            throw new NotImplementedException();
        }

        public override void Set(int value, int i)
        {
            throw new NotImplementedException();
        }

        public override int Get(int i)
        {
            throw new NotImplementedException();
        }
    }
}
