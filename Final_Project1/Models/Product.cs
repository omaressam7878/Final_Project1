using Final_Project1.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Final_Project1.Models

{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be positive")]
        public decimal Price { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public int Quantity { get; set; }

        [StringLength(200)]
        public string ImagePath { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }

}