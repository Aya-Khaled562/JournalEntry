namespace JournalEntryTask.Domain.Models
{
    public class JournalDetails
    {
        public Guid Id { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public Guid JournalHeaderId { get; set; }
        public Guid AccountId { get; set; }
        public JournalHeader JournalHeader { get; set; }
        public AccountsChart AccountChart { get; set; }
    }
}
