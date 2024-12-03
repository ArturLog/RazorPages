using Application.Common.Interfaces;
using Bogus;

namespace Application.Common.Initializers
{
    public class ApplicationDbContextInitializer(IApplicationDbContext context)
    {
        public async Task SeedSampleData()
        {
            var faker = new Faker();
            var random = new Random();
            var persons = new List<Person>();

            await context.SaveChangesAsync();
        }
    }
}
