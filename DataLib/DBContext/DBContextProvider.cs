using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLib.Entity;

namespace DataLib.DBContext
{
    public class DBContextProvider : DbContext
    {
        public DBContextProvider()
        {

        }
        public DBContextProvider(DbContextOptions<DBContextProvider> options) : base(options)
        {
            Database.EnsureCreated();
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlite("Data Source=mydatabase.db");
        //}
        public DbSet<Customers> Customers { get; set; }
    }
}
