using System.ComponentModel.DataAnnotations;

namespace WarehouseManagementProject.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required, MaxLength(100)]
        public string CustomerName { get; set; }

        [MaxLength(255)]
        public string ContactInfo { get; set; }

        [MaxLength(255)]
        public string Address { get; set; }

        [MaxLength(15)]
        public string PhoneNumber { get; set; }
    }
}
