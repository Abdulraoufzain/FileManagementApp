using Management.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Management.Web.Models
{
    public class UserModel
    {
        [Required]
        public required string UserName { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}
