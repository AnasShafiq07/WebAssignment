using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HospitalDAL
{
    public class DataAccess
    {
        public void InsertDoctor(Doctor doctor)
        {
            string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                string query = "INSERT INTO Doctor (Name, Specialization) VALUES (@Name, @Specialization)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", doctor.Name);
                cmd.Parameters.AddWithValue("@Specialization", doctor.Specialization);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Some error occured!");
            }
            finally
            {
                conn.Close();
            }
        }

        // read all doctors record
        public List<Doctor> GetAllDoctorsFromDatabase()
        {
            List<Doctor> doctors = new List<Doctor>();
            string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                string query = "select * from Doctor";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Doctor doctor = new Doctor { DoctorId = reader.GetInt32(0), Name = reader.GetString(1), Specialization = reader.GetString(2) };
                    doctors.Add(doctor);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Some error occured!");
            }
            finally
            {
                conn.Close();
            }
            return doctors;
        }

        public void UpdateDoctorInDatabase(Doctor doctor)
        {
            string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                string query = "UPDATE Doctor SET Name = @Name, Specialization = @Specialization WHERE Id = @DoctorId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", doctor.Name);
                cmd.Parameters.AddWithValue("@Specialization", doctor.Specialization);
                cmd.Parameters.AddWithValue("@DoctorId", doctor.DoctorId);
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Some error occured!");
            }
            finally
            {
                conn.Close();
            }
        }
        
        public void DeleteDoctorFromDatabase(int doctorId)
        {
            string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                History history  = new History();
                history.SaveRecordToFileOfDoctor(doctorId);
                conn.Open();
                string query = "DELETE FROM Doctor WHERE Id = @DoctorId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DoctorId", doctorId);
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Some error occured!");
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Doctor> SearchDoctorsInDatabase(string specialization)
        {
            List<Doctor> doctors = new List<Doctor>();
            string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                string query = "SELECT * FROM Doctor WHERE Specialization = @Specialization";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Specialization", specialization);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Doctor doctor = new Doctor { DoctorId = reader.GetInt32(0), Name = reader.GetString(1), Specialization = reader.GetString(2) };
                    doctors.Add(doctor);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Some error occured!");
            }
            finally
            {
                conn.Close();
            }
            return doctors;
        }

        // Doctor Functions Ended

        // Patient Record

        public void InsertPatient(Patient patient)
        {
            string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                string query = "INSERT INTO Patient (Name, Email, Disease) VALUES (@Name, @Email, @Disease)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", patient.Name);
                cmd.Parameters.AddWithValue("@Email", patient.Email);
                cmd.Parameters.AddWithValue("@Disease", patient.Disease);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Some error occured!");
            }
            finally
            {
                conn.Close();
            }
        }

        // read Record of patient
        public List<Patient> GetAllPatientsFromDatabase()
        {
            List<Patient> patients = new List<Patient>();
            string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                string query = "select * from Patient";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Patient patient = new Patient { PatientId = reader.GetInt32(0), Name = reader.GetString(1), Email = reader.GetString(2), Disease = reader.GetString(3) };
                    patients.Add(patient);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Some error occured!");
            }
            finally
            {
                conn.Close();
            }
            return patients;
        }

        public void UpdatePatientInDatabase(Patient patient)
        {
            string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                string query = "UPDATE Patient SET Name = @Name, Email = @Email, Disease = @Disease WHERE PatientId = @PatientId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", patient.Name);
                cmd.Parameters.AddWithValue("@Email", patient.Email);
                cmd.Parameters.AddWithValue("@Disease", patient.Disease);
                cmd.Parameters.AddWithValue("@PatientId", patient.PatientId);
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Some error occured!");
            }
            finally
            {
                conn.Close();
            }
        }

        
        public void DeletePatientFromDatabase(int patientId)
        {
            string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                History history = new History();
                history.SaveRecordToFileOfPatient(patientId);
                conn.Open();
                string query = "DELETE FROM Patient WHERE Id = @PatientId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PatientId", patientId);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Some error occured!");
            }
            finally
            {
                conn.Close();
            }
        }
        public List<Patient> SearchPatientsInDatabase(string name)
        {
            List<Patient> patients = new List<Patient>();
            string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                string query = "SELECT * FROM Patient WHERE Name = @Name";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Patient patient = new Patient { PatientId = reader.GetInt32(0), Name = reader.GetString(1), Email = reader.GetString(2), Disease = reader.GetString(3) };
                    patients.Add(patient);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Some error occured!");
            }
            finally
            {
                conn.Close();
            }
            return patients;
        }


        // Appointment functions

        public void InsertAppointment(Appointment appointment)
        {
            string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;";

            SqlConnection conn = new SqlConnection(connStr);

            try
            {
                conn.Open();
                string query = "INSERT INTO Appointment (PatientId, DoctorId, AppointmentDate) VALUES (@PatientId, @DoctorId, @AppointmentDate)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PatientId", appointment.PatientId);
                cmd.Parameters.AddWithValue("@DoctorId", appointment.DoctorId);
                cmd.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Some error occurred: " + ex.Message);
            }
        }

        // read all appointment records

        public List<Appointment> GetAllAppointmentsFromDatabase()
        {
            List<Appointment> appointments = new List<Appointment>();
            string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                string query = "select * from Appointment";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Appointment appointment = new Appointment { AppointmentId = reader.GetInt32(0), PatientId = reader.GetInt32(1), DoctorId = reader.GetInt32(2), AppointmentDate = reader.GetDateTime(3) };
                    appointments.Add(appointment);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Some error occured!");
            }
            finally
            {
                conn.Close();
            }
            return appointments;
        }
        public void UpdateAppointmentInDatabase(Appointment appointment)
        {
            string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                string query = "UPDATE Appointment SET PatientId = @PatientId, DoctorId = @DoctorId, AppointmentDate = @AppointmentDate WHERE AppointmentId = @AppointmentId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PatientId", appointment.PatientId);
                cmd.Parameters.AddWithValue("@DoctorId", appointment.DoctorId);
                cmd.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                cmd.Parameters.AddWithValue("@AppointmentId", appointment.AppointmentId);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Some error occured!");
            }
            finally
            {
                conn.Close();
            }
        }
        
      
        public void DeleteAppointment(int patientId, int doctorId)
        {
            string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                History history = new History();
                history.SaveRecordOfDeletePatientOrDoctor(patientId, doctorId);
                conn.Open();
                string query = "DELETE FROM Appointment WHERE PatientId = @PatientId OR DoctorId = @DoctorId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PatientId", patientId);
                cmd.Parameters.AddWithValue("@DoctorId", doctorId);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Some error occured!");
            }
            finally
            {
                conn.Close();
            }
        }
        public void DeleteAppointmentFromDatabase(int appointmentId)
        {
            string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                History history = new History();
                history.SaveRecordToFileOfAppointments(appointmentId);
                conn.Open();
                string query = "DELETE FROM Appointment WHERE Id = @AppointmentId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@AppointmentId", appointmentId);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Some error occured!");
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Appointment> SearchAppointmentsInDatabase(int doctorId, int patientId)
        {
            List<Appointment> appointments = new List<Appointment>();
            string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                string query = "SELECT * FROM Appointment WHERE DoctorId = @DoctorId AND PatientId = @PatientId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DoctorId", doctorId);
                cmd.Parameters.AddWithValue("@PatientId", patientId);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Appointment appointment = new Appointment { AppointmentId = reader.GetInt32(0), PatientId = reader.GetInt32(1), DoctorId = reader.GetInt32(2), AppointmentDate = reader.GetDateTime(3) };
                    appointments.Add(appointment);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Some error occured!");
            }
            finally
            {
                conn.Close();
            }
            return appointments;
        }



        // validation functions

        public bool IsPatientIdPresent(int id)
        {
            bool status = false;
            string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                string query = $"select * from Patient";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetInt32(0) == id)
                        status = true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Some error occured!");
            }
            finally
            {
                conn.Close();
            }
            return status;
        }

        public bool IsDoctorIdPresent(int id)
        {
            bool status = false;
            string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                string query = $"select * from Doctor";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetInt32(0) == id)
                        status = true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Some error occured!");
            }
            finally
            {
                conn.Close();
            }
            return status;
        }

        public bool AppointmentsAlready(int DoctorId, DateTime dt)
        {
            bool status = false;
            string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                string query = "SELECT * FROM Appointment WHERE DoctorId = @DoctorId AND AppointmentDate = @AppointmentDate";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DoctorId", DoctorId);
                cmd.Parameters.AddWithValue("@AppointmentDate", dt.ToString("yyyy-MM-dd"));
                SqlDataReader reader = cmd.ExecuteReader();
                status = reader.HasRows;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Some error occured!");
            }
            finally
            {
                conn.Close();
            }

            return status;
        }

        public bool IsAppointmentPresent(int id)
        {
            bool status = false;
            string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                string query = "SELECT * FROM Appointment WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                status = reader.HasRows;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Some error occured!");
            }
            finally
            {
                conn.Close();
            }
            return status;
        }
    }
}
