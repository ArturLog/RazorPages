﻿using Domain.Entities;

namespace Domain.Repositories.Interfaces
{
    public interface IGenreRepository
    {
        Task<Genre?> GetByIdAsync(int id);
        Task<IEnumerable<Genre?>> GetAllAsync();
        Task AddAsync(Genre genre);
        Task UpdateAsync(Genre genre);
        Task DeleteAsync(int id);
    }
}
