using Authentication.DataAccess.Context;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class FireSystemContext : AuthContext
    {
        public FireSystemContext(DbContextOptions<FireSystemContext> options) : base(options)
        {
        }

        public DbSet<FireReport> FireReports { get; set; }
        public DbSet<Postulation> Postulations { get; set; }
        public DbSet<Release> Releases { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
