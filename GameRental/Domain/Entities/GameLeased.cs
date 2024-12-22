﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class GameLeased
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        public DateTime DateFrom { get; set; }

        [Required]
        public DateTime DateTo { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [Required]
        public bool Active { get; set; }

        [Required]
        public int GameId { get; set; }
        [ForeignKey("GameId")]
        public Game Game { get; set; }

        [Required]
        public int GameOfferId { get; set; }
        [ForeignKey("GameOfferId")]
        public GameOffer GameOffer { get; set; }

        [Required]
        public string RenterId { get; set; }
        [ForeignKey("RenterId")]
        public ApplicationUser Renter { get; set; }
    }
}
