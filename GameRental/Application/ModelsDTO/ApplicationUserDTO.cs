
using System.ComponentModel.DataAnnotations;

namespace Application.ModelsDTO
{
    public class ApplicationUserDTO
    {
        public string Id { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
