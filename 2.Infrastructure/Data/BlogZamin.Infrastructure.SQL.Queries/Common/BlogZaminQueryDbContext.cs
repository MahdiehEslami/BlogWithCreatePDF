using Microsoft.EntityFrameworkCore;
using Zamin.Infra.Data.Sql.Queries;

namespace BlogZamin.Infrastructure.SQL.Queries.Common
{
    public partial class BlogZaminQueryDbContext : BaseQueryDbContext
    {
        public BlogZaminQueryDbContext(DbContextOptions<BlogZaminQueryDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Blog> Blog { get; set; } = null!;
        public virtual DbSet<Category> Category { get; set; } = null!;
        public virtual DbSet<Photo> Photo { get; set; } = null!;
        public virtual DbSet<BlogCategory> BlogCategory { get; set; } = null!;
        public virtual DbSet<BlogPhoto> BlogPhoto { get; set; } = null!;


        public virtual DbSet<OutBoxEventItem> OutBoxEventItems { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=BlogZamin;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OutBoxEventItem>(entity =>
            {
                entity.Property(e => e.AccuredByUserId).HasMaxLength(255);

                entity.Property(e => e.AggregateName).HasMaxLength(255);

                entity.Property(e => e.AggregateTypeName).HasMaxLength(500);

                entity.Property(e => e.EventName).HasMaxLength(255);

                entity.Property(e => e.EventTypeName).HasMaxLength(500);
            });

            //modelBuilder.Entity<BusinessId>().OwnsOne(x => x.Value);
            modelBuilder.Entity<BlogPhoto>()
               .ToTable("BlogPhoto");
            modelBuilder.Entity<BlogCategory>()
                .ToTable("BlogCategory");

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

