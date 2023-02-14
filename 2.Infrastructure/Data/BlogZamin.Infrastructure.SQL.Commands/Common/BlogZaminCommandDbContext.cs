using BlogZamin.Core.Domain.Blogs.Entities;
using BlogZamin.Core.Domain.Categories.Entities;
using BlogZamin.Core.Domain.Photos.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.Events.Outbox.Dal.EF;

namespace BlogZamin.Infrastructure.SQL.Commands.Common
{
    public class BlogZaminCommandDbContext : BaseOutboxCommandDbContext
    {
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Photo> Photo { get; set; }
        public DbSet<BlogCategory> BlogCategory { get; set; }
        public DbSet<BlogPhoto> BlogPhoto { get; set; }



        public BlogZaminCommandDbContext(DbContextOptions<BlogZaminCommandDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BlogPhoto>()
                .ToTable("BlogPhoto");
            modelBuilder.Entity<BlogCategory>()
                .ToTable("BlogCategory");
        }
    }
}
