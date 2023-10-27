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
    internal class BookTitleConfiguration : IEntityTypeConfiguration<BookTitleEntity>
    {
        public void Configure(EntityTypeBuilder<BookTitleEntity> builder)
        {
            builder.Property(bt => bt.Title)
                .IsRequired();

            builder.Property(bt => bt.PublicationYear)
                .IsRequired();

            builder.HasOne(bt => bt.Author)
                .WithMany(a => a.BookTitles)
                .HasForeignKey(bt => bt.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
