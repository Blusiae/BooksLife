using BooksLife.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLife.Database.Configurations
{
    internal class BookConfiguration : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            builder.HasOne(b => b.BookTitle)
                .WithMany(bt => bt.Books)
                .HasForeignKey(b => b.BookTitleId);

            builder.Property(b => b.IsBorrowed)
                .HasDefaultValue(false);

            builder.Property(b => b.EditionPublicationYear)
                .IsRequired();

            builder.Property(b => b.Condition)
                .IsRequired();
        }
    }
}
