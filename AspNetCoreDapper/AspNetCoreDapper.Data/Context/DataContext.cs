using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace AspNetCoreDapper.Data.Context
{
    public class DataContext : IDisposable
    {

        public SqlConnection Connection { get; set; }

        

        public DataContext()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            Connection = new SqlConnection(config.GetConnectionString("DefaultConnection"));
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
        //public DbSet<Product> Products { get; set; }
        //public DbSet<Category> Categories { get; set; }

        //public DataContext(DbContextOptions<DataContext> options) : base(options)
        //{

        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //base.OnModelCreating(modelBuilder);

        //    modelBuilder.ApplyConfiguration(new ProductMap());
        //    modelBuilder.ApplyConfiguration(new CategoryMap());
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // get the configuration from the app settings
        //    var config = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json")
        //        .Build();

        //    // define the database to use
        //    optionsBuilder
        //        .UseSqlServer(config.GetConnectionString("DefaultConnection"));
        //}
    }
}
