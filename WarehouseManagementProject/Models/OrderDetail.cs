using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WarehouseManagementProject.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailsID { get; set; }

        [ForeignKey("Order")]
        public int OrderID { get; set; }
        [ValidateNever]
        public Order Order { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }
        [ValidateNever]
        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }

    }
}
