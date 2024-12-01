using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities;

namespace Domain
{
    public class Game
    {
        [Key] public int Id { get; set; }
        [MaxLength(100)] public string Name { get; set; }
        public int? GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genre? Genre { get; set; }
    }
}
