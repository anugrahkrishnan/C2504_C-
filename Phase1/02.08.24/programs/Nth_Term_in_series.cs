using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nth_term_in_series_21_22_24
{
    class Q04
    {
        //21_22_24_27_31_36_42_49
        static int GetNthTerm_21_22_24_27(int N)
        {
            int term = 21;
            int difference = 1;
            for (int I = 1; I <= N; I++)
            {
                if (I == N)
                {
                    break;
                }
                
                term = term + difference;
                difference = difference + 1;
            }
            return term;
        }

        //input:5 , output: 31
        //input:4 , output: 27
        //input:7 , output: 42
        static void TestGetNthTerm_21_22_24_27()
        {
            Console.Write("Enter number of terms:");
            int N = int.Parse(Console.ReadLine());
            int nthTerm = GetNthTerm_21_22_24_27(N);
            Console.WriteLine($"Nth term is {nthTerm}");
        }
        static void Main(string[] args) //user: p
        {
            Console.WriteLine("-----TestGetNthTerm_21_22_24_27-----");
            TestGetNthTerm_21_22_24_27();
            Console.WriteLine("-----End TestGetNthTerm_21_22_24_27-----");
            
            Console.ReadKey();
        }
    }
}
