using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fibanacciwhile
{
    internal class Program
    {
        static void PrintFibonacciFor(int N)
        {
            int a = 0, b = 1, c;

            Console.Write("Fibonacci series: ");
            int i = 0;
            while (i < N)
            {
                Console.Write(a + " ");
                c = a + b;
                a = b;
                b = c;
                i++;
            }
            Console.WriteLine();
        }


        //input:4 ,output: 0 1 1 2
        //input: 5, output: 0 1 1 2 3
        //input :6, output : 0 1 1 2 3 5

        static void TestPrintFibonacciFor()
        {
            Console.Write("Enter the number of terms: ");
            int N = int.Parse(Console.ReadLine());
            PrintFibonacciFor(N);
        }

        static void Main(string[] args)
        {
            TestPrintFibonacciFor();
        }
    }
}
