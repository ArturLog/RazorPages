
namespace Application.ModelsDTO
{
    public class GameDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateOnly? ReleaseDate { get; set; }
        public byte[]? Image { get; set; }
    }
}
