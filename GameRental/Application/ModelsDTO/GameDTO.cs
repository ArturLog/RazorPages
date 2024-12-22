
using System.ComponentModel.DataAnnotations;

namespace Application.ModelsDTO
{
    public class GameDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Game title is required.")]
        [MaxLength(100, ErrorMessage = "Game title cannot exceed 100 characters.")]
        public string Title { get; set; }

        [MaxLength(300, ErrorMessage = "Game description cannot exceed 300 characters")]
        public string? Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Release date")]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd", ApplyFormatInEditMode = true)]
        public DateOnly? ReleaseDate { get; set; }

        [Display(Name = "Image")]
        public byte[]? Image { get; set; }
        public List<GenreDTO> Genres { get; set; } = [];
    }
}
