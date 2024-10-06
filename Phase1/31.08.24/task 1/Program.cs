
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Remoting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Week4AssessmentApp
{
    public class ServerException : Exception
    {
        public ServerException(string message) : base(message) { }
    }
    public class Prescription
    {
        public int PrescriptionId { get; set; }
        public string PatientName { get; set; }
        public string MedicationName { get; set; }
        public double Dosage { get; set; }

        public Prescription(int prescriptionId, string patientName, string medicationName, double dosage)
        {
            PrescriptionId = prescriptionId;
            PatientName = patientName;
            MedicationName = medicationName;
            Dosage = dosage;
        }

        public Prescription()
        {
            PrescriptionId = 0;
            PatientName = "";
            MedicationName = "";
            Dosage = 0;
        }


        public override string ToString()
        {
            return $"Prescription ID: {PrescriptionId}, Patient Name: {PatientName}, Medication Name: {MedicationName}, Dosage: {Dosage} mg";
        }
    }

    public class PrescriptionService
    {
        /*public static void Read(Prescription[] prescription)
        {
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Enter the details for Prescription{i + 1}:");
                Console.Write("Prescription ID:");
                int prescriptionID = int.Parse(Console.ReadLine());
                Console.Write("Patient Name:");
                string patientName = Console.ReadLine();
                Console.Write("Medication Name:");
                string medicationName = Console.ReadLine();
                Console.Write("Dosage in milligrams:");
                double dosage = double.Parse(Console.ReadLine());

                prescription[i] = new Prescription(prescriptionID, patientName, medicationName, dosage);
            };
        }*/

        private const string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=weekassessment4;Integrated Security=True;";

        public static void Read(Prescription[] prescription)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT PrescriptionId, PatientName, MedicationName, Dosage FROM Prescription";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();


                    for (int i = 0; i < prescription.Length; i++)
                    {
                        if (!reader.Read())
                        {
                            throw new ServerException("[0101]Server Errror.");//throw error
                        }
                        prescription[i] = new Prescription
                        {
                            PrescriptionId = (int)reader["PrescriptionId"],
                            PatientName = reader["PatientName"].ToString(),
                            MedicationName = reader["MedicationName"].ToString(),
                            Dosage = (float)reader["Dosage"]
                        };
                    }
                }
            }
            catch (SqlException ex)
            {
                // Handle SQL exceptions
                //Console.WriteLine($"SQL Error: {ex.Message}");
                throw new ServerException($"[0102]Server Errror.{ex.Message}");//throw Error
            }
            catch (ServerException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                //Console.WriteLine($"Error: {ex.Message}");
                throw new ServerException($"[0103]Server Errror.{ex.Message}");//throw Error
            }
        }
        public static void Sort(Prescription[] prescription)
        {
            for (int i = 0; i < prescription.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < prescription.Length; j++)
                {
                    if (prescription[j].MedicationName.CompareTo(prescription[minIndex].MedicationName) < 0)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    Prescription temp = prescription[i];
                    prescription[i] = prescription[minIndex];
                    prescription[minIndex] = temp;
                }
            }
        }
        public static Prescription FindMax(Prescription[] prescription)
        {
            Prescription maxDosage = prescription[0];
            foreach (var e in prescription)
            {
                if (e.Dosage > maxDosage.Dosage)
                {
                    maxDosage = e;
                }
            }

            return maxDosage;
        }
        public static Prescription FindThirdMin(Prescription[] prescription)
        {
            double firstMinDos = double.MaxValue;
            double secondMinDos = double.MaxValue;
            double thirdMinDos = double.MaxValue;
            Prescription thirdLeastPrescription = null;
            foreach (var p in prescription)
            {
                double dosage = p.Dosage;
                if (dosage < firstMinDos)
                {
                    thirdMinDos = secondMinDos;
                    secondMinDos = firstMinDos;
                    firstMinDos = dosage;
                }
                else if (dosage < secondMinDos && dosage != firstMinDos)
                {
                    thirdMinDos = secondMinDos;
                    secondMinDos = dosage;
                }
                else if (dosage < thirdMinDos && dosage != secondMinDos && dosage != firstMinDos)
                {
                    thirdMinDos = dosage;
                }
            }

            foreach (var e in prescription)
            {
                if (e.Dosage == thirdMinDos)
                {
                    thirdLeastPrescription = e;
                    break;
                }
            }
            return thirdLeastPrescription;
        }

    }
    internal class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        static void Main(string[] args)
        {
            Prescription[] prescriptions = new Prescription[4];
            try
            {
                PrescriptionService.Read(prescriptions);

            }
            catch (ServerException ex)
            {
                log.Error($"{ex.Message}");//Console.WriteLine($"{ex.Message}");
            }
            Prescription max = PrescriptionService.FindMax(prescriptions);
            log.Info($"max={max}");  //Console.WriteLine($"max = {max}");
            Prescription thirdMin = PrescriptionService.FindThirdMin(prescriptions);
            log.Info($"thirdMin={thirdMin}"); //Console.WriteLine($"thirdmin = {thirdMin}");
            PrescriptionService.Sort(prescriptions);
            string output = "";
            foreach (var e in prescriptions)
            {
                output += $"{e} "; //Console.WriteLine($"{e}");
            }
            log.Info(output);//Console.WriteLine(output);
        }
    }
}
