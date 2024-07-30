using ErrorOr;
using JournalEntryTask.Application.Common.Interfaces.Presistence;
using JournalEntryTask.Domain.Errors;
using JournalEntryTask.Domain.Models;
using MapsterMapper;
using MediatR;

namespace JournalEntryTask.Application.JournalHeaders.Commands.CreateJournalHeader
{
    public class CreateJournalHeaderCommandHandler: IRequestHandler<CreateJournalHeaderCommand,ErrorOr<JournalHeader>>
    {
        private readonly IJournalHeaderRepository _headerRepository;
        private readonly IMapper _mapper;

        public CreateJournalHeaderCommandHandler(IJournalHeaderRepository headerRepository , IMapper mapper)
        {
            _headerRepository = headerRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<JournalHeader>> Handle(CreateJournalHeaderCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var journalHeader = _mapper.Map<JournalHeader>(command);
                await _headerRepository.AddAsync(journalHeader);
                return journalHeader;

            }
            catch (Exception ex)
            {
                return Errors.JournalHeader.CreateFailure(ex.Message);
            }
        }
    }
}
