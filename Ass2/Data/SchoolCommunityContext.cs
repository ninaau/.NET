using Ass2NET.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;


namespace Ass2NET.Data
{
    public class SchoolCommunityContext : DbContext
    {
        public SchoolCommunityContext(DbContextOptions<SchoolCommunityContext> options)
            : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Community> Communities { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<CommunityMembership> CommunityMemberships { get; set; }
        public DbSet<CommunityAdvertisement> CommunityAdvertisements { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");

            modelBuilder.Entity<Community>().ToTable("Community");

            modelBuilder.Entity<CommunityMembership>().ToTable("CommunityMembership");

            modelBuilder.Entity<Advertisement>().ToTable("Advertisement");

            modelBuilder.Entity<CommunityAdvertisement>()
                .HasKey(c => new { c.CommunityId, c.AdvertisementsId });

            modelBuilder.Entity<CommunityMembership>()
                .HasKey(c => new { c.StudentsId, c.CommunitiesId });
           
        }
    }

}
