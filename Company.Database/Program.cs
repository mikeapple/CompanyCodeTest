using FluentMigrator.Runner;
using Company.Database.Migrations;
using Company.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var filePath = @"..\..\..\..\InchecapData.db";
var connectionString = $@"Data Source={filePath}";

if (File.Exists(filePath))
{
    File.Delete(filePath);
}

var serviceProvider = new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSQLite()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(typeof(AddSeedData).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .AddDbContext<CompanyContext>(o => o.UseSqlite(connectionString).EnableSensitiveDataLogging())
                .AddSingleton<AddSeedData>()
                .BuildServiceProvider(false);

using var scope = serviceProvider.CreateScope();

var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
runner.MigrateUp();

var seedData = serviceProvider.GetRequiredService<AddSeedData>();
seedData.LoadData();