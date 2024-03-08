using System.ComponentModel.DataAnnotations;

namespace Management.Web.Models
{
    public class Upload
    {
        [Required]
        public required string Description { get; set; }
        [Required]
        [MaxLength(50)]
        public required string CreatedBy { get; set; }

        public required IFormFile fileupload { get; set; }
    }
}
