using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

namespace mWeek4AssessmentApp
{
    public class ServerException : Exception
    {
        public ServerException(string message) : base(message) { }
    }
    public class MedicationExpiry
    {
        public int BatchID { get; set; }
        public string Medication { get; set; }
        public DateTime ExpiryDate { get; set; }
        public override string ToString()
        {
            return $"[{BatchID},{Medication},{ExpiryDate}]";
        }
    }
    public class MedicationExpiryService
    {
        /*public static void Read(MedicationExpiry[] medicationExpiries)
        {
            for (int i = 0; i < medicationExpiries.Length; i++)
            {
                Console.WriteLine($"Enter details for medication {i + 1}:");
                Console.Write("BatchID: ");
                int batchID = int.Parse(Console.ReadLine());
                Console.Write("Medication: ");
                string medication = Console.ReadLine();
                Console.Write("ExpiryDate (yyyy-mm-dd): ");
                DateTime expiryDate = DateTime.Parse(Console.ReadLine());

                medicationExpiries[i] = new MedicationExpiry
                                        {
                                            BatchID = batchID,
                                            Medication = medication,
                                            ExpiryDate = expiryDate
                                        };
            }
        }*/
         private static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=mWeek4AssessmentDb;Integrated Security=True;";

        public static void Read(MedicationExpiry[] medicationExpiries)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT BatchID, Medication, ExpiryDate FROM MedicationExpiry";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();


                    for (int i = 0; i < medicationExpiries.Length; i++)
                    {
                        if (!reader.Read())
                        {
                            throw new ServerException("[0101]Server Errror.");//throw error
                        }
                        medicationExpiries[i] = new MedicationExpiry
                        {
                            BatchID = (int)reader["BatchID"],
                            Medication = reader["Medication"].ToString(),
                            ExpiryDate = (DateTime)reader["ExpiryDate"]
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
        public static void Sort(MedicationExpiry[] medicationExpiries)
        {
            for (int i = 0; i < medicationExpiries.Length - 1; i++)
            {
                for (int j = 0; j < medicationExpiries.Length - i - 1; j++)
                {
                    if (medicationExpiries[j].ExpiryDate > medicationExpiries[j + 1].ExpiryDate)
                    {
                        var temp = medicationExpiries[j];
                        medicationExpiries[j] = medicationExpiries[j + 1];
                        medicationExpiries[j + 1] = temp;
                    }
                }
            }
        }
        public static MedicationExpiry FindMin(MedicationExpiry[] medicationExpiries)
        {
            DateTime min = DateTime.MaxValue;
            MedicationExpiry minMedicationExpiry = null;
            foreach (var med in medicationExpiries)
            {
                if (med.ExpiryDate < min)
                {
                    minMedicationExpiry = med;
                    min = med.ExpiryDate;
                }
            }
            return minMedicationExpiry;
        }
        public static MedicationExpiry FindSecondMax(MedicationExpiry[] medicationExpiries)
        {
            DateTime max = DateTime.MinValue;
            DateTime secondMax = DateTime.MinValue;

            MedicationExpiry maxMedicationExpiry = null;
            MedicationExpiry secondMaxMedicationExpiry = null;

            foreach (var med in medicationExpiries)
            {
                if (med.ExpiryDate > max)
                {
                    if (max != DateTime.MinValue)
                    {
                        secondMaxMedicationExpiry = maxMedicationExpiry;
                        secondMax = secondMaxMedicationExpiry.ExpiryDate;
                    }
                    maxMedicationExpiry = med;
                    max = med.ExpiryDate;
                }
                else if (med.ExpiryDate > secondMax && med.ExpiryDate != max)
                {
                    secondMaxMedicationExpiry = med;
                    secondMax = secondMaxMedicationExpiry.ExpiryDate;
                }
            }
            return secondMaxMedicationExpiry;
        }
    }
    public class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            log.Debug(DateTime.MinValue);
            MedicationExpiry[] medicationExpiries = new MedicationExpiry[3];
            try
            {
                MedicationExpiryService.Read(medicationExpiries);
            }
            catch (ServerException ex)
            {
               log.Error($"{ex.Message}"); //Console.WriteLine($"{ex.Message}");
            }
            MedicationExpiry min = MedicationExpiryService.FindMin(medicationExpiries);
            log.Info($"min={min}"); //Console.WriteLine($"min={min}");
            MedicationExpiry secondMax = MedicationExpiryService.FindSecondMax(medicationExpiries);
            log.Info($"secondMax={secondMax}"); //Console.WriteLine($"secondMax={secondMax}");
            MedicationExpiryService.Sort(medicationExpiries);
            string output = "";
            foreach (var e in medicationExpiries)
            {
                output += $"{e} ";
            }
            log.Info(output); //Console.WriteLine(output);
        }
    }
}