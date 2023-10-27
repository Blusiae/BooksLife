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
        public DbSet<BookTitleEntity> BookTitles { get; set; }
        public DbSet<BorrowEntity> Borrows { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            modelBuilder.Entity<ReaderEntity>()
                .HasOne(a => a.Address)
                .WithMany(r => r.Readers)
                .HasForeignKey(a => a.AddressId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BookTitleEntity>()
                .HasOne(a => a.Author)
                .WithMany(t => t.BookTitles)
                .HasForeignKey(a => a.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
