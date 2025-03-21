
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SampleCleanArchProject.Application.DTOs
{
    public class CategoryDto
    {
        public int? Id { get; set; }

        [Required(ErrorMessage ="The name is required")]
        public string Name { get; set; }
    }
}