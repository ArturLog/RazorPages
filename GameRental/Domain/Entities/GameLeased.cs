using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class GameLeased
    {
        [Key] 
        public int Id { get; set; }

        [Required(ErrorMessage = "Leased date from is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Leased date from")]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd", ApplyFormatInEditMode = true)]
        public DateTime DateFrom { get; set; }

        [Required(ErrorMessage = "Leased date to is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Leased date to")]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd", ApplyFormatInEditMode = true)]
        public DateTime DateTo { get; set; }

        [Required(ErrorMessage = "Game price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Game price must be a positive number")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Leased active flag is required")]
        public bool Active { get; set; }

        [Required(ErrorMessage = "Game is required")]
        [Display(Name="Game")]
        public int GameId { get; set; }
        [ForeignKey("GameId")]
        public Game Game { get; set; }

        [Required(ErrorMessage = "Game offer is required")]
        [Display(Name = "Game offer")]
        public int GameOfferId { get; set; }
        [ForeignKey("GameOfferId")]
        public GameOffer GameOffer { get; set; }

        [Required(ErrorMessage = "Renter is required")]
        [Display(Name = "Renter")]
        public string RenterId { get; set; }
        [ForeignKey("RenterId")]
        public ApplicationUser Renter { get; set; }
    }
}
