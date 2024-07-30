using DomainJournalDetails = JournalEntryTask.Domain.Models.JournalDetails;
namespace JournalEntryTask.Application.Common.Interfaces.Presistence
{
    public interface IJournalDetailsRepository
    {
        Task<List<DomainJournalDetails>> GetAllAsync(Guid journalHeaderId);
        Task<DomainJournalDetails> GetByIdAsync(Guid id);
        Task AddAsync(DomainJournalDetails journalDetails);
        Task UpdateAsync(DomainJournalDetails journalDetails);
        Task DeleteAsync(Guid id);
    }
}
