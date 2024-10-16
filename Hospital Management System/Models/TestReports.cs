using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management_System.Models
{
    public class TestReports
    {
        [Key]
        public int ReportId { get; set; }
        public int RecordId { get; set; }
        [ForeignKey("RecordId")]
        public MedicalRecords MedicalRecords { get; set; }
        public string ReportType { get; set; }
        public string ReportDetails { get; set; }
        public DateTime TestDate { get; set; }
        public string TestResult { get; set; }
    }
}
