using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management_System.Models
{
    public class Departments
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int StaffId { get; set; }
        [ForeignKey("StaffId")]
        public Staffs Staffs { get; set; }
        public string Description { get; set; }

        public ICollection<Doctors> Doctors { get; set; }
    }
}
