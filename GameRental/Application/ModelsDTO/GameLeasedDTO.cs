
namespace Application.ModelsDTO
{
    public class GameLeasedDTO
    {
        public int Id { get; set; }
        public DateOnly DateFrom { get; set; }
        public DateOnly DateTo { get; set; }
        public double Price { get; set; }
        public bool Active { get; set; }
        public int GameId { get; set; }
        public int GameOfferId { get; set; }
        public string RenterId { get; set; }
    }
}
