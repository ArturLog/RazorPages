using Application.ModelsDTO;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Repositories.Interfaces;

namespace Application.Services.Classes
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IApplicationUserRepository _repository;

        public ApplicationUserService(IApplicationUserRepository applicationUserRepository)
        {
            _repository = applicationUserRepository;
        }

        public async Task<IEnumerable<ApplicationUserDTO?>> GetAllAsync()
        {
            var applicationUser = await _repository.GetAllAsync();
            return applicationUser.Select(a => new ApplicationUserDTO
            {
				Id = a.Id,
				Email = a.Email
            }).ToList();
        }

        public async Task<ApplicationUserDTO?> GetByIdAsync(string id)
        {
            var applicationUser = await _repository.GetByIdAsync(id);
            return applicationUser is not null ? new ApplicationUserDTO
            {
                Id = applicationUser.Id,
                Email = applicationUser.Email
            } : null;
        }

        public async Task AddAsync(ApplicationUserDTO applicationUserDto)
        {
            var applicationUser = new ApplicationUser
            {
                Email = applicationUserDto.Email
            };
            await _repository.AddAsync(applicationUser);
        }

        public async Task UpdateAsync(ApplicationUserDTO applicationUserDto)
        {
            var applicationUser = new ApplicationUser
            {
                Id = applicationUserDto.Id,
                Email = applicationUserDto.Email
            };
            await _repository.UpdateAsync(applicationUser);
        }

        public async Task DeleteAsync(string id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
