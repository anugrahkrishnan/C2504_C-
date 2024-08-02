using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nthfibafor
{
    internal class Program
    {

        static int GetFibonacciFor(int N)
        {
            if (N <= 0)
                return 0; // Handle invalid cases

            int a = 0, b = 1, c = 0;

            if (N == 1)
                return a;
            if (N == 2)
                return b;

            for (int i = 3; i <= N; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }

            return b;
        }

        //input :2, output:1
        //input:3, output:1
        //input:4,output:2

        static void TestFibonacciFor()
        {
            Console.Write("Enter the term number: ");
            int N = int.Parse(Console.ReadLine());

            int result = GetFibonacciFor(N);
            Console.WriteLine($"The {N}-th Fibonacci term is: {result}");
        }

        static void Main(string[] args)
        {
            TestFibonacciFor();
        }
    }
}
