using ErrorOr;
using JournalEntryTask.Application.Common.Interfaces.Presistence;
using JournalEntryTask.Domain.Models;
using MediatR;

namespace JournalEntryTask.Application.JournalHeaders.Queries.ListJournalHeaders
{
    public class ListJournalHeadersQueryHandler : IRequestHandler<ListJournalHeadersQuery, ErrorOr<List<JournalHeader>>>
    {
        private readonly IJournalHeaderRepository _headerRepository;

        public ListJournalHeadersQueryHandler(IJournalHeaderRepository headerRepository)
        {
            _headerRepository = headerRepository;
        }
        public async Task<ErrorOr<List<JournalHeader>>> Handle(ListJournalHeadersQuery query, CancellationToken cancellationToken)
        {
             return await _headerRepository.GetAllAsync();
        }
    }
}
