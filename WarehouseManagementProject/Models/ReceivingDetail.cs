using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagementProject.Models
{
    public class ReceivingDetail
    {
        [Key]
        public int ReceivingDetailsID { get; set; }

        public int ReceivingID { get; set; }
        [ForeignKey("ReceivingID")]
        [ValidateNever]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Receiving Receiving { get; set; }

        public int ProductID { get; set; }
        [ForeignKey("ProductID")]
        [ValidateNever]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
