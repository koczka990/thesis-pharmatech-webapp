using Backend.DLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DLL.Context
{
    public class DataContext : DbContext, IDataContext
    {
        public DbSet<CountingData> countingDatas { get; set; }
        public DbSet<StatData> statDatas { get; set; }

        public DataContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DBSettings settings = new DBSettings()
            {
                Host = "134.122.79.245",
                Port = "5432",
                User = "postgres",
                Password = "supersecret",
                Db = "test"
            };

            optionsBuilder.UseNpgsql(settings.GetConnectionString());
        }
    }
}
