using eCinema.Services.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace eCInema.Test
{
    public static class InMemoryDatabaseFactory
    {
        public static CinemaContext CreateInMemoryDatabase()
        {
            var databaseName = Guid.NewGuid().ToString();

            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var options = new DbContextOptionsBuilder<CinemaContext>()
                .UseInMemoryDatabase(databaseName)
                .UseInternalServiceProvider(serviceProvider)
                .Options;
            var databaseContextMock = new CinemaContext(options);

            return databaseContextMock;
        }
    }
}
