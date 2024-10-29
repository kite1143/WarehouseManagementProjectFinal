using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WarehouseManagementProject.Models
{
    public class ReceivingDetail
    {
        [Key]
        public int ReceivingDetailsID { get; set; }

        public int ReceivingID { get; set; }
        [ForeignKey("ReceivingID")]
        [ValidateNever]
        public Receiving Receiving { get; set; }

        public int ProductID { get; set; }
        [ForeignKey("ProductID")]
        [ValidateNever]
        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
