using ErrorOr;
using JournalEntryTask.Application.Common.Interfaces.Presistence;
using JournalEntryTask.Domain.Errors;
using MapsterMapper;
using MediatR;
using DomainJournalDetails = JournalEntryTask.Domain.Models.JournalDetails;

namespace JournalEntryTask.Application.JournalDetails.Commands.UpdateJournalDetails
{
    public class UpdateJournalDetailsCommandHandler : IRequestHandler<UpdateJournalDetailsCommand, ErrorOr<DomainJournalDetails>>
    {
        private readonly IJournalDetailsRepository _detailsRepository;
        private readonly IMapper _mapper;

        public UpdateJournalDetailsCommandHandler(IJournalDetailsRepository detailsRepository, IMapper mapper)
        {
            _detailsRepository = detailsRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<DomainJournalDetails>> Handle(UpdateJournalDetailsCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var journalDetail = _mapper.Map<DomainJournalDetails>(command);
                await _detailsRepository.UpdateAsync(journalDetail);
                return journalDetail;
            }
            catch (Exception ex)
            {
                return Errors.JournalDetails.UpdateFailure(ex.Message);
            }
        }
    }
}
