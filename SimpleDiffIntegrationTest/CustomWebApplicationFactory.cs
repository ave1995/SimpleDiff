using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleDiff.Data;
using System.Linq;

namespace SimpleDiffIntegrationTest
{
    public class CustomWebApplicationFactory<TProgram> 
        : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<DiffContext>));

                services.Remove(descriptor!);

                services.AddDbContext<DiffContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                });
            });

            builder.UseEnvironment("Development");
        }
    }
}
