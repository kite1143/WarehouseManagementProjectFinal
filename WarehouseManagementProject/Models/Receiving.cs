using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagementProject.Models
{
    public class Receiving
    {

        [Key]
        public int ReceivingID { get; set; }

        [Required]
        public DateTime ReceivingDate { get; set; }

        public int SupplierID { get; set; }
        [ForeignKey("SupplierID")]
        [ValidateNever]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Supplier Supplier { get; set; }

        public int WarehouseID { get; set; }
        [ForeignKey("WarehouseID")]
        [ValidateNever]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Warehouse Warehouse { get; set; }
    }
}
