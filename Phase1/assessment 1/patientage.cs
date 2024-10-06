using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace patientage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ageSum = 0;
            int count = 0;
            int teenSum = 0;
            int oddSum = 0;
            int primeSum = 0;
            int i = 1;
            int age = 0;
            int min = 0;
            int maxAdult = 0;
            int secondMaxAdult = 0;

            do
            {
                Console.WriteLine("Enter patient's age:");
                age = int.Parse(Console.ReadLine());

                if (age < 0)
                {
                    break;
                }

                else if (age == 0)
                {
                    Console.WriteLine("Enter valid age");
                    continue;
                }

                else
                {
                    ageSum += age;
                    count++;

                    if (i == 1)
                    {
                        min = age;
                    }

                    if (age >= 13 && age < 18)
                    {
                        teenSum += age;
                    }

                    if (age % 2 != 0)
                    {
                        oddSum += age;
                    }

                    if (age < min)
                    {
                        min = age;
                    }

                    if (age >= 18)
                    {
                        if (age > maxAdult)
                        {
                            secondMaxAdult = maxAdult;
                            maxAdult = age;
                        }
                    }
                    
                    for (global::System.Int32 j = 2; j <= (age / 2); j++)
                    {
                        if (age % j != 0 )
                        {
                            primeSum += age;
                            break;
                        }
                    }
                }

                i++;

            } while (age >= 0);

            int average = ageSum / count;
            bool prime = false;

            Console.WriteLine($"Average: {average}");
            Console.WriteLine($"Teenage sum: {teenSum}");
            Console.WriteLine($"Odd age sum: {oddSum}");
            Console.WriteLine($"Minimum age: {min}");
            Console.WriteLine($"Second maximum adult age: {secondMaxAdult}");

            if (min == 1)
            {
                Console.WriteLine("Minimum age neither prime nor composite");
            }

            else
            {
                for (int j = 2; j <= (min / 2); j++)
                {
                    if (min % j != 0)
                    {
                        prime = true;
                        break;
                    }
                }

                if (prime)
                {
                    Console.WriteLine("Minimum age is prime");
                }

                else
                {
                    Console.WriteLine("Minimum age is not prime");
                }
            }
        }
    }
}
             //-------------------------------------------------OUTPUT-------------------------------------------------------
/* 
 
Enter patient's age:
19
Enter patient's age:
3
Enter patient's age:
20
Enter patient's age:
10
Enter patient's age:
13
Enter patient's age:
-2
Average: 13
Teenage sum: 13
Odd age sum: 35
Minimum age: 3
Second maximum adult age: 19
Minimum age is prime
Press any key to continue . . .  */
