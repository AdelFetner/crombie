using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Test.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Name { get; set; }

        [Required]
        [Range(1, 100000)]
        public double Price { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [NotMapped]
        public string Summary { get; set; }
    }
}
