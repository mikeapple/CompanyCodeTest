using Company.Api.Services;
using Company.Database;
using Company.Database.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Company.Tests
{
    internal class TestContext
    {
        public CompanyContext DbContext { get; set; }
        public IVehicleService VehicleService { get; set; }

        public TestContext()
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<CompanyContext>(o => o.UseInMemoryDatabase(Guid.NewGuid().ToString()))
                .AddSingleton<AddSeedData>()
                .AddScoped<IVehicleService, VehicleService>()
                .BuildServiceProvider(false);

            using var scope = serviceProvider.CreateScope();

            VehicleService = serviceProvider.GetRequiredService<IVehicleService>();
            DbContext = serviceProvider.GetRequiredService<CompanyContext>();

            var seedData = serviceProvider.GetRequiredService<AddSeedData>();
            seedData.LoadData();
        }
    }
}
