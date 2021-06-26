using Lab4NET.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4NET.Data
{
    public class SchoolCommunityContext : DbContext
    {
        public SchoolCommunityContext(DbContextOptions<SchoolCommunityContext> options) : base(options)
        {
        }

        public DbSet<CommunityMembership> CommunityMemberships { get; set; }
        public DbSet<Community> Communities { get; set; }
        public DbSet<Student> Students { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommunityMembership>().HasKey(c => new {
                c.StudentId, c.CommunityId }); ;
            modelBuilder.Entity<Community>().ToTable("Communities");
            modelBuilder.Entity<Student>().ToTable("Students");
            
        }

    }
}
