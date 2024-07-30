namespace JournalEntryTask.Domain.Models
{
    public class JournalHeader
    {
        public Guid Id { get; set; }
        public DateTime EntryDate { get; set; }
        public int EntryNumber { get; set; }
        public string Description { get; set; }
        public virtual ICollection<JournalDetails> JournalDetails { get; set; }
    }
}
