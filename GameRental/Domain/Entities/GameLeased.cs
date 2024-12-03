using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class GameLeased
    {
        [Key] 
        public int Id { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DateFrom { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DateTo { get; set; }
        public int? GameId { get; set; }
        [ForeignKey("GameId")]
        public Game? Game { get; set; }
        public string? RenterId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser? Renter { get; set; }
    }
}
