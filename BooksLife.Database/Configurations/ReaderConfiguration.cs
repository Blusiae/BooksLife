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
    internal class ReaderConfiguration : IEntityTypeConfiguration<ReaderEntity>
    {
        public void Configure(EntityTypeBuilder<ReaderEntity> builder)
        {
            builder.Property(r => r.Firstname)
                .IsRequired();

            builder.Property(r => r.Lastname)
                .IsRequired();

            builder.HasOne(r => r.Address)
                .WithMany(a => a.Readers)
                .HasForeignKey(r => r.AddressId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
