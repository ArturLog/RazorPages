using Application.Common.Interfaces;

namespace Application.Common.Initializers
{
    public class ApplicationDbContextInitializer(IApplicationDbContext context)
    {
        public async Task SeedSampleData()
        {
            await context.SaveChangesAsync();
        }
    }
}
