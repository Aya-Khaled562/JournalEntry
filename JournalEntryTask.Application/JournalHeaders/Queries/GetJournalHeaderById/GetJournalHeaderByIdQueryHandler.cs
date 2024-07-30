using ErrorOr;
using JournalEntryTask.Application.Common.Interfaces.Presistence;
using JournalEntryTask.Domain.Errors;
using JournalEntryTask.Domain.Models;
using MediatR;

namespace JournalEntryTask.Application.JournalHeaders.Queries.GetJournalHeaderById
{
    public class GetJournalHeaderByIdQueryHandler : IRequestHandler<GetJournalHeaderByIdQuery, ErrorOr<JournalHeader>>
    {
        private readonly IJournalHeaderRepository _headerRepository;

        public GetJournalHeaderByIdQueryHandler(IJournalHeaderRepository headerRepository)
        {
            _headerRepository = headerRepository;
        }

        public async Task<ErrorOr<JournalHeader>> Handle(GetJournalHeaderByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _headerRepository.GetByIdAsync(query.Id);
            }
            catch (Exception ex)
            {
                return Errors.JournalHeader.NotFound(query.Id);
            }
        }
    }
}
