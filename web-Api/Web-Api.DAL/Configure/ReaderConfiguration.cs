using Entites.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Web_Api.DAL.Configure
{
    public class ReaderConfiguration : IEntityTypeConfiguration<Reader>
    {
        public void Configure(EntityTypeBuilder<Reader> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id).IsRequired();
            builder.Property(r => r.FirstName).IsRequired();
            builder.Property(r => r.LastName).IsRequired();
            builder.Property(r => r.PhoneNumber).IsRequired();
            builder.Property(r => r.Email).IsRequired();
            builder.Property(r => r.HomeAddress).IsRequired();

            builder.HasMany(r => r.Issues)
                .WithOne(i => i.Reader)
                .HasForeignKey(i => i.ReaderId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
