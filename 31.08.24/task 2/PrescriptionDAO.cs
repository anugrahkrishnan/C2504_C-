using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    internal class PrescriptionDAO
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=task2;Integrated Security=True;";
        /*
            how do you create the connection object?
            how do you create the command object?
            how do you write the parameterizied sql statement or query?
            how will you pass the value to the query?
            how will you establish the connection to database?
            how will you run the query?
        */
        public void Create(Prescription prescriptions)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Prescription (PatientName, MedicationName, Dosage) VALUES (@PatientName, @MedicationName, @Dosage)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@PatientName", prescriptions.PatientName);
                    cmd.Parameters.AddWithValue("@MedicationName", prescriptions.MedicationName);
                    cmd.Parameters.AddWithValue("@Dosage", prescriptions.Dosage);

                    conn.Open();
                    cmd.ExecuteNonQuery();
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

        // Read a Trainer by ID
        /*
   how do you create the connection object?
   how do you create the command object?
   how do you write the parameterizied sql statement or query?
   how will you pass the value to the query?
   how will you establish the connection to database?
   how will you run the query?
   what is reader object?
   how will you read a row or row-by-row many rows using reader object?
        what is job of the reader.Read() function?
        how do you use the reader object after Read() function?
   */
        public Prescription Read(int id)
        {
            try
            {
                Prescription prescription = null;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT PrescriptionId, PatientName, MedicationName, Dosage FROM Prescription WHERE PrescriptionId = @PrescriptionId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@PrescriptionId", id);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        prescription = new Prescription((int)reader["PrescriptionId"], reader["PatientName"].ToString(), reader["MedicationName"].ToString(), (float)reader["Dosage"]);
                    }
                }
                return prescription;
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

        // Update a Trainer
        public void Update(Prescription prescription)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Prescription SET PatientName = @PatientName, MedicationName = @MedicationName, Dosage = @Dosage WHERE PrescriptionId = @PrescriptionId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@PrescriptionId", prescription.PrescriptionId);
                    cmd.Parameters.AddWithValue("@PatientName", prescription.PatientName);
                    cmd.Parameters.AddWithValue("@MedicationName", prescription.MedicationName);
                    cmd.Parameters.AddWithValue("@Dosage", prescription.Dosage);

                    conn.Open();
                    cmd.ExecuteNonQuery();
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

        // Delete a Trainer by ID
        public void Delete(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Prescription WHERE PrescriptionId = @PrescriptionId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@PrescriptionId", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
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

        // List all Trainers
        public List<Prescription> ListAll()
        {
            try
            {
                List<Prescription> prescriptions = new List<Prescription>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT PrescriptionId, PatientName, MedicationName, Dosage FROM Prescription";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Prescription prescription = new Prescription((int)reader["PrescriptionId"], reader["PatientName"].ToString(), reader["MedicationName"].ToString(), (float)reader["Dosage"]);
                        prescriptions.Add(prescription);
                    }
                }
                return prescriptions;
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

        public Prescription FindMax()
        {
            try
            {
                Prescription prescription = null;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT PrescriptionId, PatientName, MedicationName, Dosage FROM Prescription WHERE Dosage = (SELECT MAX(Dosage) FROM Prescription)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        prescription = new Prescription((int)reader["PrescriptionId"], reader["PatientName"].ToString(), reader["MedicationName"].ToString(), (float)reader["Dosage"]);
                    }
                }
                return prescription;
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

        public Prescription FindThirdMin()
        {
            try
            {
                Prescription prescription = null;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT PrescriptionId, PatientName, MedicationName, Dosage FROM Prescription ORDER BY Dosage ASC OFFSET 2 ROWS FETCH NEXT 1 ROW ONLY";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        prescription = new Prescription((int)reader["PrescriptionId"], reader["PatientName"].ToString(), reader["MedicationName"].ToString(), (float)reader["Dosage"]);
                    }
                }
                return prescription;
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

        public List<Prescription> SortByDosage()
        {
            try
            {
                List<Prescription> prescriptions = new List<Prescription>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT PrescriptionId, PatientName, MedicationName, Dosage FROM Prescription ORDER BY Dosage";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Prescription prescription = new Prescription((int)reader["PrescriptionId"], reader["PatientName"].ToString(), reader["MedicationName"].ToString(), (float)reader["Dosage"]);
                        prescriptions.Add(prescription);
                    }
                }
                return prescriptions;
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
    }
}
