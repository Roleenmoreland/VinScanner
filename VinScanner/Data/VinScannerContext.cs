using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinScanner.Models.Repository;

namespace VinScanner.Data
{
    public class VinScannerContext : DbContext
    {
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<VechileDetails> VechileDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //todo move to config
            options.UseSqlServer("Server=delta-test-db-server;Initial Catalog=sqldb-delta-test;Persist Security Info=False;User ID=DeltaAdmin;Password=B87RGlME8tHk6u;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
