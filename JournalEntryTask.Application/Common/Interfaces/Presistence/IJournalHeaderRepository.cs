using JournalEntryTask.Domain.Models;

namespace JournalEntryTask.Application.Common.Interfaces.Presistence
{
    public interface IJournalHeaderRepository
    {
        Task<List<JournalHeader>> GetAllAsync();
        Task<JournalHeader> GetByIdAsync(Guid id);
        Task AddAsync(JournalHeader journalHeader);
        Task UpdateAsync(JournalHeader journalHeader);
        Task DeleteAsync(Guid id);
    }
}
