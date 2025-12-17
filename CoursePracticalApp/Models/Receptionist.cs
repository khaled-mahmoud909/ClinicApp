namespace CoursePracticalApp.Models
{
    public class Receptionist
    {

        public int Id { get; set; }

        public string ShiftType { get; set; } = string.Empty;


        public string AppUserId { get; set; } = null!;


        public AppUser AppUser { get; set; } = null!;

        public List<Patient> Patients { get; set; } = new List<Patient>();


    }
}
