using Application.ModelsDTO;

namespace Application.Services.Interfaces
{
    public interface IApplicationUserService
    {
        Task<ApplicationUserDTO?> GetByIdAsync(int id);
        Task<IEnumerable<ApplicationUserDTO?>> GetAllAsync();
        Task AddAsync(ApplicationUserDTO applicationUserDto);
        Task UpdateAsync(ApplicationUserDTO applicationUserDto);
        Task DeleteAsync(int id);
    }
}
