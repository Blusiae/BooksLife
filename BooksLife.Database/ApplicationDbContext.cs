using BooksLife.Core;
using Microsoft.EntityFrameworkCore;

namespace BooksLife.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<ReaderEntity> Readers { get; set; }
        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<TitleEntity> Titles { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReaderEntity>()
                .HasOne(a => a.Address)
                .WithMany(r => r.Readers)
                .HasForeignKey(a => a.AddressId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BookEntity>()
                .HasOne(t => t.Title)
                .WithMany(b => b.Books)
                .HasForeignKey(t => t.TitleId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TitleEntity>()
                .HasOne(a => a.Author)
                .WithMany(t => t.Titles)
                .HasForeignKey(a => a.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
