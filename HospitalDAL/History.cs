using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HospitalDAL
{
    internal class History
    {

        public History() { }

        public void SaveRecordToFileOfPatient(int patientId)
        {
            string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connStr);
            StreamWriter sw = new StreamWriter("DeletedPatients.txt", append: true);
            try
            {
                conn.Open();
                string query = "SELECT * FROM Patient WHERE Id = @patientId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@patientId", patientId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Patient patient = new Patient { PatientId = reader.GetInt32(0), Name = reader.GetString(1), Email = reader.GetString(2), Disease = reader.GetString(3) };
                    PatientRecordWithMetaData record = new PatientRecordWithMetaData { Patient = patient, DeletionDate = DateTime.Today, RecordTimestamp = DateTime.Now };
                    string jsonform = JsonSerializer.Serialize(record);
                    sw.WriteLine(jsonform);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Some error occured!");
            }
            finally
            {
                sw.Close();
                conn.Close();
            }
        }


        public void SaveRecordToFileOfDoctor(int doctorId)
        {
            string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connStr);
            StreamWriter sw = new StreamWriter("DeletedDoctor.txt", append: true);
            try
            {
                conn.Open();
                string query = "SELECT * FROM Doctor WHERE Id = @doctorId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@doctorId", doctorId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Doctor doctor = new Doctor { DoctorId = reader.GetInt32(0), Name = reader.GetString(1), Specialization = reader.GetString(2) };
                    DoctorRecordWithMetadata record = new DoctorRecordWithMetadata
                    {
                        Doctor = doctor,
                        DeletionDate = DateTime.Today,
                        RecordTimestamp = DateTime.Now
                    };
                    string jsonform = JsonSerializer.Serialize(record);
                    sw.WriteLine(jsonform);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Some error occured!");
            }
            finally
            {
                sw.Close();
                conn.Close();
            }
        }

        public void SaveRecordToFileOfAppointments(int aapId)
        {
            string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connStr);
            StreamWriter sw = new StreamWriter("DeletedAppointments.txt", append: true);
            try
            {
                conn.Open();
                string query = "SELECT * FROM Appointment WHERE Id = @apId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@apId", aapId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Appointment appointment = new Appointment { AppointmentId = reader.GetInt32(0), PatientId = reader.GetInt32(1), DoctorId = reader.GetInt32(2), AppointmentDate = reader.GetDateTime(3) };
                    AppointmentRecordWithMetaData record = new AppointmentRecordWithMetaData
                    {
                        Appointment = appointment,
                        DeletionDate = DateTime.Today,
                        RecordTimestamp = DateTime.Now
                    };
                    string jsonform = JsonSerializer.Serialize(record);
                    sw.WriteLine(jsonform);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Some error occured!");
            }
            finally
            {
                sw.Close();
                conn.Close();
            }
        }

        public void SaveRecordOfDeletePatientOrDoctor(int patientId, int doctorId)
        {
            string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connStr);
            StreamWriter sw = new StreamWriter("DeletedAppointments.txt", append: true);
            try
            {
                conn.Open();
                string query = "SELECT * FROM Appointment WHERE PatientId = @patientId OR DoctorId = @doctorId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@patientId", patientId);
                cmd.Parameters.AddWithValue("@doctorId", doctorId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Appointment appointment = new Appointment { AppointmentId = reader.GetInt32(0), PatientId = reader.GetInt32(1), DoctorId = reader.GetInt32(2), AppointmentDate = reader.GetDateTime(3) };
                    AppointmentRecordWithMetaData record = new AppointmentRecordWithMetaData
                    {
                        Appointment = appointment,
                        DeletionDate = DateTime.Today,
                        RecordTimestamp = DateTime.Now
                    };
                    string jsonform = JsonSerializer.Serialize(record);
                    sw.WriteLine(jsonform);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Some error occured!");
            }
            finally
            {
                sw.Close();
                conn.Close();
            }
        }
    }
}
