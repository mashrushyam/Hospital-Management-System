using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.Models
{
    public class Doctors
    {
        [Key]
        public int DoctorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public string Phone {  get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string AvailableDays {  get; set; }
        public string AvailableTime {  get; set; }
        public decimal ConsultationFee {  get; set; }
        public DateTime JoiningDate { get; set; }
    }
}
