using JournalEntryTask.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace JournalEntryTask.Infrastructure.Presistence.Configurations
{
    public class JournalDetailsConfigurations : IEntityTypeConfiguration<JournalDetails>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<JournalDetails> builder)
        {
            builder.HasKey(jd => jd.Id);

            builder.HasOne(jd => jd.JournalHeader)
                .WithMany(jh => jh.JournalDetails)
                .HasForeignKey(jd => jd.JournalHeaderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(jd => jd.AccountChart)
                .WithMany()
                .HasForeignKey(jd => jd.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(jd => jd.Debit)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(jd => jd.Credit)
                .HasColumnType("decimal(18,2)")
                .IsRequired();


        }
    }
}
