using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarkPeople.DBLayer
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<People> Peoples { get; set; }
        public DbSet<MarkQuality> MarkQualities { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=LTT_TEST;Username=postgres;Password=123456");
        }
    }
}
