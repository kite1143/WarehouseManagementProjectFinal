using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagementProject.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailsID { get; set; }

        public int OrderID { get; set; }
        [ForeignKey("OrderID")]
        [ValidateNever]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Order Order { get; set; }

        public int ProductID { get; set; }
        [ForeignKey("ProductID")]
        [ValidateNever]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }

    }
}
