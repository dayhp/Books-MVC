using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(2)]
        public string Name { get; set; }

        [Range(1, 10)]
        public int DisplayOrder { get; set; }
    }
}
