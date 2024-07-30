using JournalEntryTask.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace JournalEntryTask.Infrastructure.Presistence
{
    public class JournalEntryTaskContext: DbContext
    {
        public JournalEntryTaskContext(DbContextOptions<JournalEntryTaskContext> options) : base(options)
        { }

        public DbSet<JournalHeader> JournalHeaders { get; set; }
        public DbSet<JournalDetails> JournalDetails { get; set; }
        public DbSet<AccountsChart> AccountsCharts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(JournalEntryTaskContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
