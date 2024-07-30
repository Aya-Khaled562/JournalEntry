using JournalEntryTask.Domain.Models;

namespace JournalEntryTask.Api.Common.Dto
{
    public class JournalHeaderResponse
    {
        public Guid Id { get; set; }
        public DateTime EntryDate { get; set; }
        public int EntryNumber { get; set; }
        public string Description { get; set; }
        public List<JournalDetails> JournalDetails { get; set; } = new();
    }

}
