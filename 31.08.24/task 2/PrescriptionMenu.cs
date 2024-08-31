using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    internal class PrescriptionMenu
    {
        public static void Menu()
        {
            PrescriptionUI ui = new PrescriptionUI();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nPrescription Management System");
                Console.WriteLine("1. Create Prescription");
                Console.WriteLine("2. Read Prescription");
                Console.WriteLine("3. Update Prescription");
                Console.WriteLine("4. Delete Prescription");
                Console.WriteLine("5. List All Prescription");
                Console.WriteLine("6. Max Dosage");
                Console.WriteLine("7. ThirdMin Dosage");
                Console.WriteLine("8. Sort Prescription based on Dosage");
                Console.WriteLine("9. Exit");

                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ui.CreatePrescription();
                        break;
                    case "2":
                        ui.ReadPrescription();
                        break;
                    case "3":
                        ui.UpdatePrescription();
                        break;
                    case "4":
                        ui.DeletePrescription();
                        break;
                    case "5":
                        ui.ListAllPrescription();
                        break;
                    case "6":
                        ui.FindMaxDosage();
                        break;
                    case "7":
                        ui.FindThirdMinDosage();
                        break;
                    case "8":
                        ui.SortByDosage();
                        break;
                    case "9":
                        running = false;
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
