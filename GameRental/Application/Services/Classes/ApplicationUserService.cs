using Application.ModelsDTO;
using Application.Services.Interfaces;

namespace Application.Services.Classes
{
    public class ApplicationUserService : IApplicationUserService
    {
        public Task<ApplicationUserDTO?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApplicationUserDTO?>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(ApplicationUserDTO applicationUserDto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ApplicationUserDTO applicationUserDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
