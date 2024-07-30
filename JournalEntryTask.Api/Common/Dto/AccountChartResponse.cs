namespace JournalEntryTask.Api.Common.Dto
{

    public class AccountChartResponse
    {
        public Guid Id { get; set; }
        public string NameAr { get; set; } = null!;
        public string NameEn { get; set; } = null!;
        public string Number { get; set; } = null!;
    }
}
