using Application.ModelsDTO;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Repositories.Interfaces;

namespace Application.Services.Classes
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _repository;

        public GenreService(IGenreRepository genreRepository)
        {
            _repository = genreRepository;
        }

        public async Task<IEnumerable<GenreDTO?>> GetAllAsync()
        {
            var genre = await _repository.GetAllAsync();
            return genre.Select(g => new GenreDTO
            {
	            Id = g.Id,
				Name = g.Name,
            }).ToList();
        }

        public async Task<GenreDTO?> GetByIdAsync(int id)
        {
            var genre = await _repository.GetByIdAsync(id);
            return genre is not null ? new GenreDTO
            {
                Id = genre.Id,
                Name = genre.Name
            } : null;
        }

        public async Task AddAsync(GenreDTO genreDto)
        {
            var genre = new Genre
            {
                Name = genreDto.Name
            };
            await _repository.AddAsync(genre);
        }

        public async Task UpdateAsync(GenreDTO genreDto)
        {
            var genre = new Genre
            {
                Id = genreDto.Id,
                Name = genreDto.Name
            };
            await _repository.UpdateAsync(genre);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
