using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] arr1 = new char[10, 10];
            int SIZE_X = 9;
            int SIZE_Y = 9;
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                arr1[i, j] = '*';
            }
        }
            for (int z = 0; z < 8; z++)
            {
                

                for (int i = z; i < SIZE_Y - z; i++)
                {

                    arr1[i, z] = '|';

                }
                for (int i = z; i < SIZE_X - z; i++)
                {
                    arr1[z, i] = '-';
                }

                for (int i = SIZE_Y-z; i > z; i--)
                {

                    arr1[i, SIZE_X - z] = '|';

                }
                


                for (int i = SIZE_X-z; i > z; i--)
                {
                    arr1[SIZE_Y - z, i] = '-';
                }
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(arr1[i, j]);
                }Console.WriteLine();
            }
            
        }
    }
}
