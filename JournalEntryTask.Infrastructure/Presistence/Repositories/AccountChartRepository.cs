using JournalEntryTask.Application.Common.Interfaces.Presistence;
using JournalEntryTask.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace JournalEntryTask.Infrastructure.Presistence.Repositories
{
    public class AccountChartRepository : IAccountChartRepository
    {
        private readonly JournalEntryTaskContext _context;

        public AccountChartRepository(JournalEntryTaskContext context)
        {
            _context = context;
        }

        public async Task<List<AccountsChart>> GetAllAsync()
        {
            return await _context.AccountsCharts.ToListAsync();
        }

        public async Task<AccountsChart> GetByIdAsync(Guid id)
        {
            return await _context.AccountsCharts.FirstOrDefaultAsync(acc => acc.Id == id);
        }
    }
}
