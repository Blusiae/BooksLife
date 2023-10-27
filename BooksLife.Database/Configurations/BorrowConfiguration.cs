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
    internal class BorrowConfiguration : IEntityTypeConfiguration<BorrowEntity>
    {
        public void Configure(EntityTypeBuilder<BorrowEntity> builder)
        {
            builder.HasOne(b => b.Reader)
                .WithMany(r => r.Borrows)
                .HasForeignKey(b => b.ReaderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(b => b.Book)
                .WithMany(b => b.Borrows)
                .HasForeignKey(b => b.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(b => b.BorrowDate)
                .HasDefaultValueSql("getutcdate()")
                .ValueGeneratedOnAdd();

            builder.Property(b => b.ReturnDeadline)
                .IsRequired()
                .HasDefaultValueSql("dateadd(m, 1, getutcdate())"); // Default value is a month after adding a borrow.

            builder.Property(b => b.IsActive)
                .HasDefaultValue(true);

        }
    }
}
