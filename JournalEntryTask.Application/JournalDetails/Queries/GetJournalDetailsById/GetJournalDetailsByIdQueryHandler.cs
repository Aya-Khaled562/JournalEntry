using ErrorOr;
using JournalEntryTask.Application.Common.Interfaces.Presistence;
using JournalEntryTask.Domain.Errors;
using MediatR;
using DomainJournalDetails = JournalEntryTask.Domain.Models.JournalDetails;

namespace JournalEntryTask.Application.JournalDetails.Queries.GetJournalDetailsById
{
    public class GetJournalDetailsByIdQueryHandler : IRequestHandler<GetJournalDetailsByIdQuery, ErrorOr<DomainJournalDetails>>
    {
        private readonly IJournalDetailsRepository _detailsRepository;

        public GetJournalDetailsByIdQueryHandler(IJournalDetailsRepository detailsRepository)
        {
            _detailsRepository = detailsRepository;
        }
        public async Task<ErrorOr<DomainJournalDetails>> Handle(GetJournalDetailsByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _detailsRepository.GetByIdAsync(query.Id);
            }
            catch (Exception ex)
            {
                return Errors.JournalDetails.NotFound(query.Id);
            }
        }
    }
}
