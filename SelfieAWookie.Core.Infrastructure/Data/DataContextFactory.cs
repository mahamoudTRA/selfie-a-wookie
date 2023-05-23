using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql;

namespace SelfieAWookie.Core.Infrastructure.Data
{
    public class DataContextFactory :IDesignTimeDbContextFactory<DataContext>
    {

        public DataContext CreateDbContext(string[] args)
        {
            var connectionString = "SelfieDataBase";
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "Settings", "appSettings.json"));

            IConfigurationRoot configurationRoot = configurationBuilder.Build();

            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();

            builder.UseMySql(configurationRoot.GetConnectionString(connectionString),
                             new MySqlServerVersion(new Version(8, 0, 28))
                             /*b => b.MigrationsAssembly("SelfieAWookie.Data.Migrations")*/);
            DataContext context = new DataContext(builder.Options);

            return context;
        }
    }
}

