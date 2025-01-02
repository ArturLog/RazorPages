using Application.ModelsDTO;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Application.Services.Classes
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IGenreRepository _genreRepository;
        public GameService(IGameRepository gameRepository, IGenreRepository genreRepository)
        {
            _gameRepository = gameRepository;
            _genreRepository = genreRepository;
        }

        public async Task<IEnumerable<GameDTO?>> GetAllAsync()
        {
            var game = await _gameRepository.GetAllAsync();
            return game.Select(g => new GameDTO
            {
				Id = g.Id,
				Title = g.Title,
                Image = g.Image,
                Description = g.Description,
                ReleaseDate = g.ReleaseDate.HasValue ? DateOnly.FromDateTime(g.ReleaseDate.Value) : (DateOnly?)null,
                Genres = g.Genres?.Select(genre => new GenreDTO
                {
                    Id = genre.Id,
                    Name = genre.Name
                }).ToList() ?? new List<GenreDTO>()
            }).ToList();
        }

        public async Task<GameDTO?> GetByIdAsync(int id)
        {
            var game = await _gameRepository.GetByIdAsync(id);
            return game is not null ? new GameDTO
            {
                Id = game.Id,
                Image = game.Image,
                Title = game.Title,
                Description = game.Description,
                ReleaseDate = game.ReleaseDate.HasValue ? DateOnly.FromDateTime(game.ReleaseDate.Value) : (DateOnly?)null,
                Genres = game.Genres?.Select(genre => new GenreDTO
                {
                    Id = genre.Id,
                    Name = genre.Name
                }).ToList() ?? new List<GenreDTO>()
            } : null;
        }

        public async Task AddAsync(GameDTO gameDto)
        {
            var game = new Game
            {
                Title = gameDto.Title,
                Image = gameDto.Image,
                Description = gameDto.Description,
                ReleaseDate = gameDto.ReleaseDate.HasValue ? gameDto.ReleaseDate.Value.ToDateTime(TimeOnly.MinValue) : (DateTime?)null
            };
            if (gameDto.Genres.Any())
            {
                var existingGenres = await _genreRepository.GetAllAsync();
                game.Genres = existingGenres.Where(genre => gameDto.Genres.Any(genreDto => genreDto.Id == genre.Id)).ToList();
            }

            await _gameRepository.AddAsync(game);
        }

        public async Task UpdateAsync(GameDTO gameDto)
        {
            var game = new Game
            {
                Id = gameDto.Id,
                Title = gameDto.Title,
                Image = gameDto.Image,
                Description = gameDto.Description,
                ReleaseDate = gameDto.ReleaseDate.HasValue ? gameDto.ReleaseDate.Value.ToDateTime(TimeOnly.MinValue) : (DateTime?)null,
                Genres = []
            };
            if (gameDto.Genres.Any())
            {
                var existingGame = await _gameRepository.GetByIdAsync(gameDto.Id);
                var existingGenres = await _genreRepository.GetAllAsync();
                existingGame.Genres.Clear();
                game.Genres = existingGenres.Where(genre => gameDto.Genres.Any(genreDto => genreDto.Id == genre.Id)).ToList();
            }
            else
            {
                game.Genres.Clear();
            }
            await _gameRepository.UpdateAsync(game);
        }

        public async Task DeleteAsync(int id)
        {
            await _gameRepository.DeleteAsync(id);
        }
    }
}
