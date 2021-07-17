using Lab5NET.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5NET.Data
{
    public class AnswerImageDataContext : DbContext
    {
        public AnswerImageDataContext(DbContextOptions<AnswerImageDataContext> options)
            : base(options)
        {

        }

        public DbSet<AnswerImage> AnswerImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnswerImage>().ToTable("AnswerImage");
        }
    }
}
