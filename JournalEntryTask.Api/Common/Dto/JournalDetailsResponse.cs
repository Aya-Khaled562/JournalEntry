namespace JournalEntryTask.Api.Common.Dto
{
    public class JournalDetailsResponse
    {
        public Guid Id { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public Guid JournalHeaderId { get; set; }
        public AccountChartResponse Account { get; set; }
    }
}
