using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management_System.Models
{
    public class Appointments
    {
        [Key]
        public int AppointmentId { get; set; }
        public int PatientID { get; set; }
        [ForeignKey("PatientID")]
        public Patients Patients { get; set; }
        public int DoctorID { get; set; }
        [ForeignKey("DoctorID")]
        public Doctors Doctors { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public string AppointmentStatus {  get; set; }
        public string ResonForVisit { get; set; }
        public Billing Billing { get; set; }
        public ICollection<MedicalRecords> MedicalRecords { get; set; }

    }
}
