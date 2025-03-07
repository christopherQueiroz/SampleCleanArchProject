using SampleCleanArchProject.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SampleCleanArchProject.Application.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required")]
        [DisplayName("Name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "The description is required")]
        [DisplayName("Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The price is required")]
        [Column(TypeName ="decimal(18,2)")]
        [DisplayFormat(DataFormatString ="{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage ="Stock is required")]
        [Range(1,9999)]
        [DisplayName("Stock")]
        public int Stock { get; set; }

        [DisplayName("Product Image")]
        public string Image { get; set; }

        public int CategoryId { get; set; }
    }
}