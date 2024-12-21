
namespace Application.ModelsDTO
{
    public class GameOfferDTO
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public int GameId { get; set; }
        public string OwnerId { get; set; }
    }
}
