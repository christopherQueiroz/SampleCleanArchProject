

using System.ComponentModel.DataAnnotations;

namespace SampleCleanArchProject.Application.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="The name is required")]
        public string Name { get; set; }
    }
}