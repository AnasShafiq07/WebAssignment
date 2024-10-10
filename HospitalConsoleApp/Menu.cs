using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Data.SqlClient;
using HospitalDAL;

namespace HospitalManagementConsoleApp
{
    public class Menu
    {
        public Menu() { }

        void AddPatient()
        {
            Patient p = new Patient();

            try
            {
                Console.Write("Enter Patient's name: ");
                p.Name = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(p.Name))
                {
                    Console.Write("Please enter a valid Patient's name: ");
                    p.Name = Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occurred");
            }

            try
            {
                Console.Write("Enter Email: ");
                p.Email = Console.ReadLine();
                while (!IsValidEmail(p.Email))
                {
                    Console.Write("Please enter a valid Email: ");
                    p.Email = Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occurred");
            }

            try
            {
                Console.Write("Enter Patient's disease: ");
                p.Disease = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(p.Disease))
                {
                    Console.Write("Please enter the Patient's disease: ");
                    p.Disease = Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occurred");
            }

            try
            {
                DataAccess dataAccess = new DataAccess();
                dataAccess.InsertPatient(p);
                Console.WriteLine("Patient added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occurred");
            }
        }
        void updatePatient()
        {
            Patient p = new Patient();
            DataAccess access = new DataAccess();
            bool isValidId = false;
            while (!isValidId)
            {
                try
                {
                    Console.Write("Enter Patient's Id: ");
                    p.PatientId = int.Parse(Console.ReadLine());

                    if (access.IsPatientIdPresent(p.PatientId))
                    {
                        isValidId = true;
                    }
                    else
                    {
                        Console.WriteLine("Enter a valid Patient's Id. ");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Enter a valid Patient's Id. ");
                }
            }

            try
            {
                Console.Write("Enter Patient's name: ");
                p.Name = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(p.Name))
                {
                    Console.Write("Please enter a valid Patient's name: ");
                    p.Name = Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occurred");
            }

            bool isValidEmail = false;
            while (!isValidEmail)
            {
                try
                {
                    Console.Write("Enter Email: ");
                    p.Email = Console.ReadLine();

                    if (IsValidEmail(p.Email))
                    {
                        isValidEmail = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid Email.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Occurred");
                }
            }

            try
            {
                Console.Write("Enter Patient's disease: ");
                p.Disease = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(p.Disease))
                {
                    Console.Write("Please enter the Patient's disease: ");
                    p.Disease = Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occurred");
            }

            try
            {
                DataAccess dataAccess = new DataAccess();
                dataAccess.UpdatePatientInDatabase(p);
                Console.WriteLine("Patient updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occurred");
            }
        }

        void DeletePatient()
        {
            int id = -1;
            bool isValidId = false;
            DataAccess access = new DataAccess();
            while (!isValidId)
            {
                try
                {
                    Console.Write("Enter Patient's Id: ");
                    id = int.Parse(Console.ReadLine());

                    if (access.IsPatientIdPresent(id))
                    {
                        isValidId = true;
                    }
                    else
                    {
                        Console.WriteLine("Enter a valid Patient's Id. ");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Enter a valid Patient's Id. ");
                }
            }

            try
            {
                DataAccess dataAccess = new DataAccess();
                dataAccess.DeleteAppointment(id, -1);
                dataAccess.DeletePatientFromDatabase(id);
                Console.WriteLine("Patient deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occurred");
            }
        }


        void SearchPatientsByName()
        {
            Console.Write("Enter the name of Patients: ");
            string name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.Write("Enter the valid name of Patients: ");
                name = Console.ReadLine();
            }
            DataAccess dataAccess = new DataAccess();
            List<Patient> patients = dataAccess.SearchPatientsInDatabase(name);
            if (patients.Count > 0)
            {
                foreach (Patient patient in patients)
                {
                    Console.WriteLine($"Id: {patient.PatientId}, Name: {patient.Name}, Email: {patient.Email}, Disease: {patient.Disease}");
                }
            }
            else
            {
                Console.WriteLine("No Patient present of this name!");
            }
        }
        void ViewAllPatients()
        {
            DataAccess dataAccess = new DataAccess();
            List<Patient> patients = dataAccess.GetAllPatientsFromDatabase();
            if (patients.Count > 0)
            {
                foreach (Patient patient in patients)
                {
                    Console.WriteLine($"Id: {patient.PatientId}, Name: {patient.Name}, Email: {patient.Email}, Disease: {patient.Disease}");
                }
            }
            else
                Console.WriteLine("No patient present");
        }
        void AddDoctor()
        {
            Doctor d = new Doctor();

            try
            {
                Console.Write("Enter Doctor's name: ");
                d.Name = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(d.Name))
                {
                    Console.Write("Please enter a valid Doctor's name: ");
                    d.Name = Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred.");
            }

            try
            {
                Console.Write("Enter Doctor's Specialization: ");
                d.Specialization = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(d.Specialization))
                {
                    Console.Write("Please enter a valid Doctor's Specialization: ");
                    d.Specialization = Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred.");
            }

            try
            {
                DataAccess dataAccess = new DataAccess();
                dataAccess.InsertDoctor(d);
                Console.WriteLine("Doctor added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred.");
            }
        }

        void UpdateDoctor()
        {
            Doctor d = new Doctor();
            bool isValidId = false;
            DataAccess access = new DataAccess();

            while (!isValidId)
            {
                try
                {
                    Console.Write("Enter Doctor's Id: ");
                    d.DoctorId = int.Parse(Console.ReadLine());

                    if (access.IsDoctorIdPresent(d.DoctorId))
                    {
                        isValidId = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid Id. ");
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Enter a valid Id. ");

                }
            }
            Console.Write("Enter Doctor's name: ");
            d.Name = Console.ReadLine();
            while (!string.IsNullOrWhiteSpace(d.Name))
            {
                Console.Write("Enter Valid Doctor's name: ");
                d.Name = Console.ReadLine();
            }

            Console.Write("Enter Doctor's specialization: ");
            d.Specialization = Console.ReadLine();
            while (!string.IsNullOrWhiteSpace(d.Name))
            {
                Console.Write("Enter Valid Doctor's specialization: ");
                d.Name = Console.ReadLine();
            }

            try
            {
                DataAccess dataAccess = new DataAccess();
                dataAccess.UpdateDoctorInDatabase(d);
                Console.WriteLine("Doctor updated successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred");
            }
        }

        void DeleteDoctor()
        {
            int id = -1;
            bool isValidId = false;
            DataAccess access = new DataAccess();
            while (!isValidId)
            {
                try
                {
                    Console.Write("Enter Doctor's Id: ");
                    id = int.Parse(Console.ReadLine());

                    if (access.IsDoctorIdPresent(id))
                    {
                        isValidId = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid Id.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Please enter a valid Id.");
                }
            }

            try
            {
                DataAccess dataAccess = new DataAccess();
                dataAccess.DeleteAppointment(-1, id);
                dataAccess.DeleteDoctorFromDatabase(id);
                Console.WriteLine("Doctor deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred.");
            }
        }

        void SearchDoctorBySpecialization()
        {
            Console.Write("Enter Specialization of the doctor to search: ");
            string spec = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(spec))
            {
                Console.Write("Enter valid Specialization of the doctor to search: ");
                spec = Console.ReadLine();
            }
            DataAccess dataAccess = new DataAccess();
            List<Doctor> doctors = dataAccess.SearchDoctorsInDatabase(spec);
            if (doctors.Count > 0)
            {
                foreach (Doctor doctor in doctors)
                {
                    Console.WriteLine($"DoctorId: {doctor.DoctorId}, Name: {doctor.Name}, Specialization: {doctor.Specialization}");
                }
            }
            else
            {
                Console.WriteLine("No doctor present of this specialization!");
            }
        }
        void ViewAllDoctors()
        {
            DataAccess dataAccess = new DataAccess();
            List<Doctor> doctors = dataAccess.GetAllDoctorsFromDatabase();
            foreach (Doctor doctor in doctors)
            {
                Console.WriteLine($"DoctorId: {doctor.DoctorId}, Name: {doctor.Name}, Specialization: {doctor.Specialization}");
            }
        }
        void BookAnAppointment()
        {
            Appointment a = new Appointment();
            bool isValidPatientId = false;
            DataAccess access = new DataAccess();
            while (!isValidPatientId)
            {
                try
                {
                    Console.Write("Enter Patient's Id: ");
                    a.PatientId = int.Parse(Console.ReadLine());

                    if (access.IsPatientIdPresent(a.PatientId))
                    {
                        isValidPatientId = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid Id.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" ");
                }
            }

            bool isValidDoctorId = false;
            while (!isValidDoctorId)
            {
                try
                {
                    Console.Write("Enter Doctor's Id: ");
                    a.DoctorId = int.Parse(Console.ReadLine());

                    if (access.IsDoctorIdPresent(a.DoctorId))
                    {
                        isValidDoctorId = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid Id. ");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" ");
                }
            }

            bool isValidDate = false;
            while (!isValidDate)
            {
                try
                {
                    Console.Write("Enter Appointment Date (YYYY/MM/DD): ");
                    a.AppointmentDate = DateTime.Parse(Console.ReadLine());

                    if (a.AppointmentDate < DateTime.Now)
                    {
                        Console.WriteLine("Please enter a date from the future.");
                    }
                    else if (access.AppointmentsAlready(a.DoctorId, a.AppointmentDate))
                    {
                        Console.WriteLine("Appointment already present. Please enter a different time.");
                    }
                    else
                    {
                        isValidDate = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" ");
                }
            }
            try
            {
                DataAccess dataAccess = new DataAccess();
                dataAccess.InsertAppointment(a);
                Console.WriteLine("Appointment booked successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred");
            }
        }

        void ViewAllAppointments()
        {
            DataAccess dataAccess = new DataAccess();
            List<Appointment> appointments = dataAccess.GetAllAppointmentsFromDatabase();
            if (appointments.Count > 0)
            {
                foreach (Appointment appointment in appointments)
                {
                    Console.WriteLine($"AppointmentId: {appointment.AppointmentId}, PatientID: {appointment.PatientId}, DoctorId: {appointment.DoctorId},Appointment Date : {appointment.AppointmentDate}");
                }
            }
            else
                Console.WriteLine("No Appointments");
        }

        void SearchAppointmentByPatientOrDoctor()
        {
            Appointment appointment = new Appointment();
            DataAccess access = new DataAccess();
            bool isValidPatientId = false;
            while (!isValidPatientId)
            {
                try
                {
                    Console.Write("Enter Patient's Id: ");
                    appointment.PatientId = int.Parse(Console.ReadLine());

                    if (access.IsPatientIdPresent(appointment.PatientId))
                    {
                        isValidPatientId = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid Id.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" ");
                }
            }
            bool isValidDoctorId = false;
            while (!isValidDoctorId)
            {
                try
                {
                    Console.Write("Enter Doctor's Id: ");
                    appointment.DoctorId = int.Parse(Console.ReadLine());

                    if (access.IsDoctorIdPresent(appointment.DoctorId))
                    {
                        isValidDoctorId = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid Id.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" ");
                }
            }

            try
            {
                DataAccess dataAccess = new DataAccess();
                List<Appointment> appointments = dataAccess.SearchAppointmentsInDatabase(appointment.DoctorId, appointment.PatientId);

                if (appointments.Count > 0)
                {
                    foreach (Appointment appointment1 in appointments)
                    {
                        Console.WriteLine($"AppointmentId: {appointment1.AppointmentId}, PatientID: {appointment1.PatientId}, DoctorId: {appointment1.DoctorId}, Appointment Date: {appointment1.AppointmentDate}");
                    }
                }
                else
                {
                    Console.WriteLine("No appointments found for this patient with this doctor.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred");
            }
        }


        bool IsValidEmail(string email)
        {
            bool status = false;
            if (email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
                status = true;
            return status;
        }

        void CancelAppointment()
        {
            int id = -1;
            bool isValidId = false;
            DataAccess access = new DataAccess();
            while (!isValidId)
            {
                try
                {
                    Console.Write("Enter Appointment Id: ");
                    id = int.Parse(Console.ReadLine());

                    if (access.IsAppointmentPresent(id))
                    {
                        isValidId = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid Id.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" ");
                }
            }

            try
            {
                DataAccess dataAccess = new DataAccess();
                dataAccess.DeleteAppointmentFromDatabase(id);
                Console.WriteLine("Appointment canceled successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred");
            }
        }


        void ViewHistory()
        {
            Console.WriteLine("Press 1 to View deleted doctors history.");
            Console.WriteLine("Press 2 to View deleted patients history.");
            Console.WriteLine("Press 3 to View deleted appointments history.");

            int input = -1;
            bool isValidInput = false;
            while (!isValidInput)
            {
                try
                {
                    input = int.Parse(Console.ReadLine());

                    if (input >= 1 && input <= 3)
                    {
                        isValidInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Press a correct option.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error occurred");
                }
            }

            try
            {
                if (input == 1)
                {
                    StreamReader sr = new StreamReader("DeletedDoctor.txt");
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        DoctorRecordWithMetadata dm = JsonSerializer.Deserialize<DoctorRecordWithMetadata>(line);
                        Console.WriteLine($"Id: {dm.Doctor.DoctorId}, Name: {dm.Doctor.Name}, Specialization: {dm.Doctor.Specialization}, Date: {dm.DeletionDate}, TimeStamp: {dm.RecordTimestamp}");
                    }
                }
                else if (input == 2)
                {
                    StreamReader sr = new StreamReader("DeletedPatients.txt");

                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        PatientRecordWithMetaData pm = JsonSerializer.Deserialize<PatientRecordWithMetaData>(line);
                        Console.WriteLine($"Id: {pm.Patient.PatientId}, Name: {pm.Patient.Name}, Email: {pm.Patient.Email}, Disease: {pm.Patient.Disease}, Date: {pm.DeletionDate}, TimeStamp: {pm.RecordTimestamp}");
                    }
                }
                else if (input == 3)
                {
                    StreamReader sr = new StreamReader("DeletedAppointments.txt");
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        AppointmentRecordWithMetaData am = JsonSerializer.Deserialize<AppointmentRecordWithMetaData>(line);
                        Console.WriteLine($"Id: {am.Appointment.AppointmentId}, PatientId: {am.Appointment.PatientId}, DoctorId: {am.Appointment.DoctorId}, Appointment Date: {am.Appointment.AppointmentDate}, Delete Date: {am.DeletionDate}, Delete TimeStamp: {am.RecordTimestamp}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("No Record available.!");
            }
        }

        void ExitApplication()
        {
            Console.WriteLine("--!!!Application exited.!!!--");
            return;
        }
        public void StartApplication()
        {
            int input = 0;
            while (input != 16)
            {
                Console.WriteLine("  -----Hospital Management System-----  ");
                Console.WriteLine("Press 1 to Add new Patient.");
                Console.WriteLine("Press 2 to Update Patient.");
                Console.WriteLine("Press 3 to Delete Patient.");
                Console.WriteLine("Press 4 to Search Patient by Name.");
                Console.WriteLine("Press 5 to View all Patients.");
                Console.WriteLine("Press 6 to Add new Doctor.");
                Console.WriteLine("Press 7 to Update Doctor.");
                Console.WriteLine("Press 8 to Delete Doctor.");
                Console.WriteLine("Press 9 to Search Doctor by Specializtion.");
                Console.WriteLine("Press 10 to View all Doctors.");
                Console.WriteLine("Press 11 to Book an Appointment.");
                Console.WriteLine("Press 12 to View all Appointment.");
                Console.WriteLine("Press 13 to Search Appointment by Doctor or patient.");
                Console.WriteLine("Press 14 to Cancel Appointment.");
                Console.WriteLine("Press 15 to View History of Deleted Records.");
                Console.WriteLine("Press 16 to Exit the Application.");
                Console.WriteLine("    -----------------   ");
                Console.WriteLine("           ---            ");
                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Please Choose correct option");
                }

                if (input == 1)
                    AddPatient();
                else if (input == 2)
                    updatePatient();
                else if (input == 3)
                    DeletePatient();
                else if (input == 4)
                    SearchPatientsByName();
                else if (input == 5)
                    ViewAllPatients();
                else if (input == 6)
                    AddDoctor();
                else if (input == 7)
                    UpdateDoctor();
                else if (input == 8)
                    DeleteDoctor();
                else if (input == 9)
                    SearchDoctorBySpecialization();
                else if (input == 10)
                    ViewAllDoctors();
                else if (input == 11)
                    BookAnAppointment();
                else if (input == 12)
                    ViewAllAppointments();
                else if (input == 13)
                    SearchAppointmentByPatientOrDoctor();
                else if (input == 14)
                    CancelAppointment();
                else if (input == 15)
                    ViewHistory();
                else if (input == 16)
                    ExitApplication();
                else
                    Console.WriteLine("Press Correct Option!!!");
            }
        }

    }
}
