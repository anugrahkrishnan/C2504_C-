using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tria_for
{
    internal class Program
    {
        static void GetPrintNumberFor(int N)
        {
            for (int row = 1; row <= N; row++)
            {
                int spaces = N - row;
                int num = 1;
                for (int col = 1; col <= N; col++)
                {
                    if (col <= spaces)
                        Console.Write(" ");
                    else
                        Console.Write(col);
                }
                Console.WriteLine();
            }
        }

        //input:4, 4lines
        //input:5, 5 lines
        //input :6,6 lines

        static void TestGetPrintNumberFor()
        {
            Console.Write("Enter number of lines: ");
            int N = int.Parse(Console.ReadLine());
            GetPrintNumberFor(N); // Fixed syntax error here
        }

        static void Main(string[] args)
        {
            TestGetPrintNumberFor();
        }
    }
}
