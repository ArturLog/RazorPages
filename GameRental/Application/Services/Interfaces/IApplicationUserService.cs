using Application.ModelsDTO;

namespace Application.Services.Interfaces
{
    public interface IApplicationUserService
    {
        Task<ApplicationUserDTO?> GetByIdAsync(string id);
        Task<IEnumerable<ApplicationUserDTO?>> GetAllAsync();
        Task AddAsync(ApplicationUserDTO applicationUserDto);
        Task UpdateAsync(ApplicationUserDTO applicationUserDto);
        Task DeleteAsync(string id);
    }
}
