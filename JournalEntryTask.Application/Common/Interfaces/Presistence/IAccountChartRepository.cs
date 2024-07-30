using JournalEntryTask.Domain.Models;

namespace JournalEntryTask.Application.Common.Interfaces.Presistence
{
    public interface IAccountChartRepository
    {
        Task<List<AccountsChart>> GetAllAsync();
        Task<AccountsChart> GetByIdAsync(Guid id);
    }
}
