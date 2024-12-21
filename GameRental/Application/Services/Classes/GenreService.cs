using Application.ModelsDTO;
using Application.Services.Interfaces;

namespace Application.Services.Classes
{
    public class GenreService : IGenreService
    {
        public Task<GenreDTO?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GenreDTO?>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(GenreDTO genreDto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(GenreDTO genreDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
