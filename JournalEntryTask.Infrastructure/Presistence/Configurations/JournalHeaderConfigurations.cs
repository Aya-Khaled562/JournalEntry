using JournalEntryTask.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JournalEntryTask.Infrastructure.Presistence.Configurations
{
    public class JournalHeaderConfigurations : IEntityTypeConfiguration<JournalHeader>
    {
        public void Configure(EntityTypeBuilder<JournalHeader> builder)
        {
            builder.HasKey(jh => jh.Id);

            builder.Property(jh => jh.EntryDate)
                .IsRequired();

            builder.Property(jh => jh.Description)
                .HasMaxLength(500);
        }
    }
}
