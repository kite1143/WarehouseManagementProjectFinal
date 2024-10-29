using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WarehouseManagementProject.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public double TotalAmount { get; set; }

        [MaxLength(50)]
        public string Status { get; set; }
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        [ValidateNever]
        public Customer Customer { get; set; }
    }
}
