using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linetriangle
{
    internal class Program
    {
        static void PrintNumTriangleMirroredRightAngle(int N)
        {
            int I = 1;
            do
            {
                if (N < I)
                {
                    Console.WriteLine("Enter valid no.of rows");
                    break;
                }
                else
                {
                    int J = 1;
                    do
                    {
                        if (N-I < J)
                        {
                            break;
                        }
                        else
                        {
                            Console.Write("  "); 
                            J++;
                        }
                        
                    }
                    while (J <= N - I);
                    int K = 1;
                    do
                    {
                        if (I < K)
                        {
                            break;
                        }
                        else
                        {
                            Console.Write($"{K} ");
                            K++;
                        }
                        
                    }
                    while (K <= I);
                    Console.WriteLine();
                    I++;
                }
                
            }
            while (I <= N);
        }
        //input=3,output=3 lines triangle 
        //input=6,output=6 lines triangle 
        //input=7,output=7 lines triangle 
        static void TestPrintNumTriangleMirroredRightAngle()
        {
            Console.Write("Enter number of lines:");
            int N = int.Parse(Console.ReadLine());
            PrintNumTriangleMirroredRightAngle(N);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("-----TestPrintNumTriangleMirroredRightAngle-----");
            TestPrintNumTriangleMirroredRightAngle();
            Console.WriteLine("-----End TestPrintNumTriangleMirroredRightAngle-----");
            Console.WriteLine("Press any key to contine...");
            Console.ReadKey();
        }
    }
}
