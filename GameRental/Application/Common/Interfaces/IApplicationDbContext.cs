namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        Task<Guid> SaveChangesAsync();
    }
}