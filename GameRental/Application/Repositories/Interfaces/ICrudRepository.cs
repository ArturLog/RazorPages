
using Application.Common.Interfaces;
using Domain.Entities;

namespace Application.Repositories.Interfaces
{
    public interface ICrudRepository<T>
    {
        Task<T> Create(T entity);
        Task<T?> Read(int id);
        Task<List<T>> ReadAll();
        Task<bool> Update(T entity);
        Task<bool> Delete(int id);
        Task<bool> Delete(string id);

    }
}
