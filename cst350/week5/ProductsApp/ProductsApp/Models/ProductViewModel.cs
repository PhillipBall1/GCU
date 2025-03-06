using ProductsApp.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductsApp.ViewModels
{
    public class ProductViewModel
    {
        public string? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be positive")]
        public decimal Price { get; set; }
        [Display(Name = "Price")]
        public string? FormattedPrice { get; set; }

        [Required]
        public string? Description { get; set; }
        [Display(Name = "Upload Image")]

        public string? ImageURL { get; set; } 
        public IFormFile? ImageFile { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CreatedAt { get; set; }

        [Display(Name = "Created At")]
        public string? FormattedDate { get; set; }

        public decimal EstimatedTax { get; set; }

        [Display(Name = "Tax")]
        public string? FormattedEstimatedTax { get; set; }
    }
}
