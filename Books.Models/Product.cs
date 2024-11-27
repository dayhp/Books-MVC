using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Title { get; set; }
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string ISBN { get; set; }

        [Required]
        [Range(1, 1000)]
        public double ListPrice { get; set; }

        [Required]
        [Range(1, 1000)]
        public double Price { get; set; }

        [Required]
        [Range(1, 1000)]
        public double Price50 { get; set; }

        [Required]
        [Range(1, 1000)]
        public double Price100 { get; set; }

        [Required]
        public string Author { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]

        public Category Category { get; set; }

        [ValidateNever]

        public List<ProductImage> ProductImage { get; set; }
    }
}
