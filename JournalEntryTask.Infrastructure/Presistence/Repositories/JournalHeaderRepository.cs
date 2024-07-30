using JournalEntryTask.Application.Common.Interfaces.Presistence;
using JournalEntryTask.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace JournalEntryTask.Infrastructure.Presistence.Repositories
{
    public class JournalHeaderRepository : IJournalHeaderRepository
    {
        private readonly JournalEntryTaskContext _context;

        public JournalHeaderRepository(JournalEntryTaskContext context)
        {
            _context = context;
        }
        public async Task AddAsync(JournalHeader journalHeader)
        {
            _context.JournalHeaders.Add(journalHeader);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var existingJouralHeader = await GetByIdAsync(id);
            if(existingJouralHeader is null)
            {
                throw new KeyNotFoundException();
            }

            _context.JournalHeaders.Remove(existingJouralHeader);
            await _context.SaveChangesAsync();
        }

        public async Task<List<JournalHeader>> GetAllAsync()
        {
            return await _context.JournalHeaders.ToListAsync();
        }

        public async Task<JournalHeader> GetByIdAsync(Guid id)
        {
            return await _context.JournalHeaders.Include(jh => jh.JournalDetails).FirstOrDefaultAsync(jh => jh.Id == id);
        }

        public async Task UpdateAsync(JournalHeader journalHeader)
        {
            var existingJournalHeader = await GetByIdAsync(journalHeader.Id);
            if(existingJournalHeader is null)
            {
                throw new KeyNotFoundException();
            }

            _context.JournalHeaders.Update(journalHeader);
            await _context.SaveChangesAsync();
        }
    }
}
