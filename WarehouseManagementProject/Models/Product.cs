using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagementProject.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required, MaxLength(100)]
        public string ProductName { get; set; }
        public int? CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        [ValidateNever]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Category Category { get; set; }
        [Required]
        public double UnitPrice { get; set; }

        [MaxLength(255)]
        public string? Description { get; set; }
    }
}
