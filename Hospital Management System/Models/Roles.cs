using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.Models
{
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public Users Users { get; set; }
    }
}
