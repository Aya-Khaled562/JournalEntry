using ErrorOr;
using JournalEntryTask.Application.Common.Interfaces.Presistence;
using JournalEntryTask.Domain.Errors;
using JournalEntryTask.Domain.Models;
using MapsterMapper;
using MediatR;

namespace JournalEntryTask.Application.JournalHeaders.Commands.UpdateJournalHeader
{
    public class UpdateJournalHeaderCommandHandler : IRequestHandler<UpdateJournalHeaderCommand, ErrorOr<JournalHeader>>
    {
        private readonly IJournalHeaderRepository _headerRepository;
        private readonly IMapper _mapper;
        public UpdateJournalHeaderCommandHandler(IJournalHeaderRepository headerRepository ,IMapper mapper)
        {
            _headerRepository = headerRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<JournalHeader>> Handle(UpdateJournalHeaderCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var journalHeader = _mapper.Map<JournalHeader>(command);
                await _headerRepository.UpdateAsync(journalHeader);
                return journalHeader;
            }
            catch (Exception ex)
            {
                return Errors.JournalHeader.UpdateFailure(ex.Message);
            }
        }
    }
}
