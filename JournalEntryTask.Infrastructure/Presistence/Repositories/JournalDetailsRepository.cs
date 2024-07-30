﻿using JournalEntryTask.Application.Common.Interfaces.Presistence;
using JournalEntryTask.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace JournalEntryTask.Infrastructure.Presistence.Repositories
{
    public class JournalDetailsRepository : IJournalDetailsRepository
    {
        private readonly JournalEntryTaskContext _context;

        public JournalDetailsRepository(JournalEntryTaskContext context)
        {
           _context = context;
        }

        public async Task AddAsync(JournalDetails journalDetails)
        {
            _context.JournalDetails.Add(journalDetails);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var existingJournalDetails = await GetByIdAsync(id);
            if (existingJournalDetails is null)
            {
                throw new KeyNotFoundException();
            }

            _context.JournalDetails.Remove(existingJournalDetails);
            await _context.SaveChangesAsync();
        }

        public async Task<List<JournalDetails>> GetAllAsync()
        {
            return await _context.JournalDetails.ToListAsync();
        }

        public async Task<JournalDetails> GetByIdAsync(Guid id)
        {
            return await _context.JournalDetails.FirstOrDefaultAsync(jd => jd.Id == id);
        }

        public async Task UpdateAsync(JournalDetails journalDetails)
        {
            var existingJournalDetails = await GetByIdAsync(journalDetails.Id);
            if (existingJournalDetails is null)
            {
                throw new KeyNotFoundException();
            }

            _context.JournalDetails.Update(journalDetails);
            await _context.SaveChangesAsync();
        }
    }
}