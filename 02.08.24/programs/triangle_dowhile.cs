using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tridowhile
{
    internal class Program
    {
        static void GetPrintNumberFor(int N)
        {
            int row = 1;
            do
            {
                int spaces = N - row;
                int num = 1;
                int col = 1;
                do
                {
                    if (col <= spaces)
                        Console.Write(" ");
                    else
                        Console.Write(col);
                    col++;
                } while (col <= N);

                Console.WriteLine();
                row++;
            } while (row <= N);
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
