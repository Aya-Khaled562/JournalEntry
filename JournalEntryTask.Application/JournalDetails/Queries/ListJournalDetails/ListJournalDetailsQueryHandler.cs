using ErrorOr;
using JournalEntryTask.Application.Common.Interfaces.Presistence;
using MediatR;
using DomainJournalDetails = JournalEntryTask.Domain.Models.JournalDetails;

namespace JournalEntryTask.Application.JournalDetails.Queries.ListJournalDetails
{
    public class ListJournalDetailsQueryHandler : IRequestHandler<ListJournalDetailsQuery, ErrorOr<List<DomainJournalDetails>>>
    {
        private readonly IJournalDetailsRepository _detailsRepository;

        public ListJournalDetailsQueryHandler(IJournalDetailsRepository detailsRepository)
        {
            _detailsRepository = detailsRepository;
        }

        public async Task<ErrorOr<List<DomainJournalDetails>>> Handle(ListJournalDetailsQuery query, CancellationToken cancellationToken)
        {
            return await _detailsRepository.GetAllAsync();
        }
    }
}
