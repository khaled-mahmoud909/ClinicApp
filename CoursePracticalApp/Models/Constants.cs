using CoursePracticalApp.Models;

namespace CoursePracticalApp.Models
{
    public class Constants
    {
        public static List<Doctor> Doctors = new List<Doctor>
        {
            new Doctor
            {
                Id = 1,
                FirstName = "Emily",
                LastName = "Carter",
                HireDate = new DateTime(2020, 5, 15),
            },

            new Doctor
            {
                Id = 2,
                FirstName = "Michael",
                LastName = "Johnson",
                HireDate = new DateTime(2018, 10, 2),
            },

            new Doctor
            {
                Id = 3,
                FirstName = "Sarah",
                LastName = "Chen",
                HireDate = new DateTime(2022, 1, 30),
            }
        };

        public static List<Patient> Patients = new List<Patient>
        {
            new Patient
            {
                Id = 101,
                FullName = "Alice Johnson-Doe",
                NationalId = "1987654321", // Starts with 1 or 2, followed by 9 digits
                Email = "alice.johnson@example.com",
                PhoneNumber = "5551234567", // Exactly 10 digits
                DateOfBirth = new DateOnly(1995, 10, 25),
                Appointments = new List<Appointment>()
            },
            new Patient
            {
                Id = 102,
                FullName = "Robert L. Smith",
                NationalId = "2012345678", // Starts with 1 or 2, followed by 9 digits
                Email = "robert.smith@health.org",
                PhoneNumber = "5559876543", // Exactly 10 digits
                DateOfBirth = new DateOnly(1980, 3, 15),
                Appointments = new List<Appointment>()
            },
            new Patient
            {
                Id = 103,
                FullName = "Maria Garcia Rodriguez",
                NationalId = "1700101010", // Starts with 1 or 2, followed by 9 digits
                Email = "maria.garcia@clinic.net",
                PhoneNumber = "5550001111", // Exactly 10 digits
                DateOfBirth = new DateOnly(2005, 7, 1),
                Appointments = new List<Appointment>()
            }
        };
    }
}
