using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management_System.Models
{
    public class MedicalRecords
    {
        [Key]
        public int RecordId { get; set; }
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patients Patient { get; set; }
        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctors Doctors { get; set; }
        public string Diagnosis { get; set; }
        public string Prescription { get; set; }
        public string TreatmentDetails { get; set; }
        public string TestResult { get; set; }
        public DateTime RecordDate { get; set; }
        public ICollection<TestReports> TestReports { get; set; }

    }
}
