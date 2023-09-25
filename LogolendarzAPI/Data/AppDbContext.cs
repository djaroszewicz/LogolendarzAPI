using LogolendarzAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LogolendarzAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Visit> Visits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Visit>().HasData(new Visit
            {
                VisitId = 1,
                PatientId = 1,
                SpeechTherId = 1,
                VisitDate = DateTime.Now,
                LastUpdated = DateTime.Now,
                Created = DateTime.Now

            });

            modelBuilder.Entity<Visit>().HasData(new Visit
            {
                VisitId = 2,
                PatientId = 1,
                SpeechTherId = 1,
                VisitDate = DateTime.Now.AddDays(1),
                LastUpdated = DateTime.Now,
                Created = DateTime.Now
            });

            modelBuilder.Entity<Visit>().HasData(new Visit
            {
                VisitId = 3,
                PatientId = 1,
                SpeechTherId = 1,
                VisitDate = DateTime.Now.AddDays(3),
                LastUpdated = DateTime.Now,
                Created = DateTime.Now
            });
        }
    }
}
