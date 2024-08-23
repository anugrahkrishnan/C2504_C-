using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using landarea;

namespace landarea
{ 
    public class RectangleLand
    {
        public string Place { get; set; }
        public int Length { get; set; }
        public int Breadth { get; set; }
            
        public RectangleLand(string place, int length, int breadth)
        {
            Place = place;
            Length = length;
            Breadth = breadth;
        }
        public int Area()
        {
            return this.Length * this.Breadth;
        }
        public static RectangleLand SelectionSort(RectangleLand[] arr)
        {
            int length = arr.Length;

            for (int i = 0; i < length - 1; i++)
            {
                int MinIndex = i;
                int j;
                for (j = i + 1; j < length; j++)
                {
                    if (arr[j].Area() < arr[MinIndex].Area())
                    {
                        MinIndex = j;
                    }
                }

                if (MinIndex != i)
                {
                    RectangleLand temp = arr[i];
                    arr[i] = arr[minIndex];
                    arr[minIndex] = temp;
                }
            }

            return arr[length - 1];
        }
  
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of lands:");
            int n = int.Parse(Console.ReadLine());
            RectangleLand[] land = new RectangleLand[n];
            Console.WriteLine("Enter land details:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter Place");
                string place = Console.ReadLine();
                Console.WriteLine("Enter Length");
                int length = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Breadth");
                int breadth = int.Parse(Console.ReadLine());

                land[i] = new RectangleLand(place, length, breadth);
            }

            RectangleLand LargestAreaLand = RectangleLand.SelectionSort(land);
            Console.WriteLine($"\nThe largest rectangle is: Length = {LargestAreaLand.Length}, Width = {LargestAreaLand.Breadth}, Area = {LargestAreaLand.Area()}");

        }
    }
}
