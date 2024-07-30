using ErrorOr;
using JournalEntryTask.Application.Common.Interfaces.Presistence;
using JournalEntryTask.Domain.Errors;
using JournalEntryTask.Domain.Models;
using MapsterMapper;
using MediatR;
using DomainJournalDetails = JournalEntryTask.Domain.Models.JournalDetails;

namespace JournalEntryTask.Application.JournalDetails.Commands.CreateJournalDetails
{
    public class CreateJournalDetailsCommandHandler : IRequestHandler<CreateJournalDetailsCommand, ErrorOr<DomainJournalDetails>>
    {
        private readonly IJournalDetailsRepository _detailsRepository;
        private readonly IMapper _mapper;

        public CreateJournalDetailsCommandHandler(IJournalDetailsRepository detailsRepository, IMapper mapper)
        {
            _detailsRepository = detailsRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<DomainJournalDetails>> Handle(CreateJournalDetailsCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var journalDetail = _mapper.Map<DomainJournalDetails>(command);
                await _detailsRepository.AddAsync(journalDetail);
                return journalDetail;
            }
            catch (Exception ex)
            {
                return Errors.JournalDetails.CreateFailure(ex.Message);
            }
        }
    }
}
