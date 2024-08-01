using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace LearningC_
{
    class ReadAndCountDoctorsMin6DigitsSalaried
    {

        static int ReadAndCountDoctorsMin6DigitsSalary(int doctorNum)
        {
            int count = 0;
            for (int i = 0; i < doctorNum; i++)
            {
                Console.WriteLine("Enter salary");

                int salary = int.Parse(Console.ReadLine());

                if (salary >= 100000)
                {
                    count++;
                }
                salary = 0;
            }

            return count;

        }

        static void TestReadAndCountDoctorsMin6DigitsSalary()
        {
            Console.WriteLine("Enter number of doctors");
            int doctorNum = int.Parse(Console.ReadLine());
            int count = ReadAndCountDoctorsMin6DigitsSalary(doctorNum);
            Console.WriteLine($"Count : {count}"); 
        }

        static void Main(string[] args) //user: p
        {
            Console.WriteLine("------------------------TestReadAndCountDoctorsMin6DigitsSalary------------------------------");
            TestReadAndCountDoctorsMin6DigitsSalary();
            Console.WriteLine("------------------------End TestReadAndCountDoctorsMin6DigitsSalary------------------------------");
            Console.ReadKey();
        }
    }
}
