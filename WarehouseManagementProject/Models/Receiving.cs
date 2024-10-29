using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

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
        public Supplier Supplier { get; set; }

        public int WarehouseID { get; set; }
        [ForeignKey("WarehouseID")]
        [ValidateNever]
        public Warehouse Warehouse { get; set; }
    }
}
