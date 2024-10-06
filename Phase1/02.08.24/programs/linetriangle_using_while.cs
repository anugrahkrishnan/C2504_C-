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
            while ( I <= N) 
            {
                int J = 1;
                while (J <= N - I) 
                {
                    Console.Write("  "); //2 spaces
                    J++;
                }
                int K = 1;
                while (K <= I) 
                {
                    Console.Write($"{K} ");//num and space
                    K++;
                }
                Console.WriteLine();//new line 
                I++;
            }
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
