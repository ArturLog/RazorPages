using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Application.ModelsDTO
{
    public class GameOfferDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Game price are required")]
        [Range(0, double.MaxValue, ErrorMessage = "Game price must be a positive number")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Game amount is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Game amount must be a positive number")]
        public int Amount { get; set; }
        [Required(ErrorMessage = "Game is required")]
        [Display(Name = "Game")]
        public int GameId { get; set; }
        [ForeignKey("GameId")]
        [ValidateNever]
        public GameDTO Game { get; set; }
        [Required(ErrorMessage = "Owner is required")]
        [Display(Name = "Owner")]
        public string OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        [ValidateNever]
        public ApplicationUserDTO Owner { get; set; }
    }
}
