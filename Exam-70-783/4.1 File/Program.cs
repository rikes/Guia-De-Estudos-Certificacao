using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._1_File
{
    class Program
    {
        static void Main(string[] args)
        {
            FileRead fileRead = new FileRead();
            FileWrite fileWrite = new FileWrite();

            fileRead.Read(@"C:\Temp2\read.txt");
            fileWrite.Write(@"C:\Temp2\write.txt", "New text oh boy!!! \n Tribufu3");

            Console.ReadLine();


        }
    }
}
