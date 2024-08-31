using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    internal class PrescriptionUI
    {
        private PrescriptionDAO prescriptionDAO = new PrescriptionDAO();

        public void CreatePrescription()
        {
            Console.Write("Enter Patient Name: ");
            string PatientName = Console.ReadLine();
            Console.Write("Enter Medication Name: ");
            string MedicationName = Console.ReadLine();
            Console.Write("Enter Dosage: ");
            float Dosage = float.Parse(Console.ReadLine());

            Prescription prescription = new Prescription(0, PatientName, MedicationName, Dosage);

            prescriptionDAO.Create(prescription);
            Console.WriteLine("Prescription created successfully.");
        }

        public void ReadPrescription()
        {
            Console.Write("Enter Prescription ID: ");
            int id = int.Parse(Console.ReadLine());

            Prescription prescription = prescriptionDAO.Read(id);
            if (prescription != null)
            {
                Console.WriteLine($"ID: {prescription.PrescriptionId}");
                Console.WriteLine($"Patient Name: {prescription.PatientName}");
                Console.WriteLine($"Medication Name: {prescription.MedicationName}");
                Console.WriteLine($"Dosage: {prescription.Dosage} mg");
            }
            else
            {
                Console.WriteLine("Prescription not found.");
            }
        }

        public void UpdatePrescription()
        {
            Console.Write("Enter Prescription ID: ");
            int id = int.Parse(Console.ReadLine());

            Prescription prescription = prescriptionDAO.Read(id);
            if (prescription != null)
            {
                Console.Write("Enter new Patient Name: ");
                prescription.PatientName = Console.ReadLine();
                Console.Write("Enter new Medication Name: ");
                prescription.MedicationName = Console.ReadLine();
                Console.Write("Enter new Dosage: ");
                prescription.Dosage = float.Parse(Console.ReadLine());

                prescriptionDAO.Update(prescription);
                Console.WriteLine("Prescription updated successfully.");
            }
            else
            {
                Console.WriteLine("Prescription not found.");
            }
        }

        public void DeletePrescription()
        {
            Console.Write("Enter Prescription ID: ");
            int id = int.Parse(Console.ReadLine());

            prescriptionDAO.Delete(id);
            Console.WriteLine("Prescription deleted successfully.");
        }

        public void ListAllPrescription()
        {
            List<Prescription> prescription = prescriptionDAO.ListAll();
            foreach (Prescription item in prescription)
            {
                Console.WriteLine($"ID: {item.PrescriptionId}, Patient Name: {item.PatientName}, Medication Name: {item.MedicationName}, Dosage: {item.Dosage}");
            }
        }

        public void FindMaxDosage()
        {
            Prescription prescription = prescriptionDAO.FindMax();
            Console.WriteLine(prescription);
        }

        public void FindThirdMinDosage()
        {
            Prescription prescription = prescriptionDAO.FindThirdMin();
            Console.WriteLine(prescription);
        }

        public void SortByDosage()
        {
            List<Prescription> prescription = prescriptionDAO.SortByDosage();
            foreach (Prescription item in prescription)
            {
                Console.WriteLine($"ID: {item.PrescriptionId}, Patient Name: {item.PatientName}, Medication Name: {item.MedicationName}, Dosage: {item.Dosage}");
            }
            
        }
    }
}
