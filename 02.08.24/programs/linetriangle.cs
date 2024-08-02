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
            for (int I = 1; I <= N; I++)
            {
                for (int J = 1; J <= N - I; J++)
                {
                    Console.Write("  "); //2 spaces
                }
                for (int J = 1; J <= I; J++)
                {
                    Console.Write($"{J} ");//num and space
                }
                Console.WriteLine();//new line 
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
