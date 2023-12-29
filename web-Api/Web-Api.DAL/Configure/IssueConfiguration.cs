using Entites.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Web_Api.DAL.Configure
{
    public class IssueConfiguration : IEntityTypeConfiguration<Issue>
    {
        public void Configure(EntityTypeBuilder<Issue> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id).IsRequired();
            builder.Property(i => i.DateOfIssue).IsRequired();
            builder.Property(i => i.DateOfReturn).IsRequired();

            builder.HasOne(i => i.Book)
                .WithMany(b => b.Issues)
                .HasForeignKey(i => i.BookId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(i => i.Reader)
                .WithMany(r => r.Issues)
                .HasForeignKey(i => i.ReaderId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
