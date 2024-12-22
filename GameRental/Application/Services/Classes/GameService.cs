﻿using Application.ModelsDTO;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Repositories.Interfaces;

namespace Application.Services.Classes
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _repository;
        public GameService(IGameRepository gameRepository)
        {
            _repository = gameRepository;
        }

        public async Task<IEnumerable<GameDTO?>> GetAllAsync()
        {
            var game = await _repository.GetAllAsync();
            return game.Select(g => new GameDTO
            {
                Title = g.Title,
                Image = g.Image,
                Description = g.Description,
                ReleaseDate = g.ReleaseDate.HasValue ? DateOnly.FromDateTime(g.ReleaseDate.Value) : (DateOnly?)null
            }).ToList();
        }

        public async Task<GameDTO?> GetByIdAsync(int id)
        {
            var game = await _repository.GetByIdAsync(id);
            return game is not null ? new GameDTO
            {
                Id = game.Id,
                Image = game.Image,
                Title = game.Title,
                Description = game.Description,
                ReleaseDate = game.ReleaseDate.HasValue ? DateOnly.FromDateTime(game.ReleaseDate.Value) : (DateOnly?)null
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
            await _repository.AddAsync(game);
        }

        public async Task UpdateAsync(GameDTO gameDto)
        {
            var game = new Game
            {
                Id = gameDto.Id,
                Title = gameDto.Title,
                Image = gameDto.Image,
                Description = gameDto.Description,
                ReleaseDate = gameDto.ReleaseDate.HasValue ? gameDto.ReleaseDate.Value.ToDateTime(TimeOnly.MinValue) : (DateTime?)null
            };
            await _repository.UpdateAsync(game);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
