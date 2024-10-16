using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.Models
{
    public class Staffs
    {
        [Key]
        public int StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Department { get; set; }
        public string Phone { get; set; }
        public string Email{ get; set; }
        public DateTime JoiningDate { get; set; }
        public Departments Departments { get; set; }

    }
}
