using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentifierGenerator.Infrastructure
{
    public class ScaffoldContext : IdentifierGeneratorDbContext
    {
        public ScaffoldContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=IdentifierGenerator;Trusted_Connection=True";

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
