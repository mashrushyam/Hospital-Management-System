using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management_System.Models
{
    public class Billing
    {
        [Key]
        public int BillingId { get; set; }
        public int AppointmentId { get; set; }
        [ForeignKey("AppointmentId")]
        public Appointments Appointments { get; set; }
        public DateTime BillingDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string PayementMethod { get; set; }
        public string PaymentStatus { get; set; }
        public string BillingDetails { get; set; }
    }
}
