﻿using Application.ModelsDTO;

namespace Application.Services.Interfaces
{
    internal interface IGenreService
    {
        Task<GenreDTO?> GetByIdAsync(int id);
        Task<IEnumerable<GenreDTO?>> GetAllAsync();
        Task AddAsync(GenreDTO genreDto);
        Task UpdateAsync(GenreDTO genreDto);
        Task DeleteAsync(int id);
    }
}