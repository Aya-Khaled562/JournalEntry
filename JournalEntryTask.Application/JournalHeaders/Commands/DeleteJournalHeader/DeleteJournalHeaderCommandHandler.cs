using ErrorOr;
using JournalEntryTask.Application.Common.Interfaces.Presistence;
using JournalEntryTask.Domain.Errors;
using MediatR;

namespace JournalEntryTask.Application.JournalHeaders.Commands.DeleteJournalHeader
{
    public class DeleteJournalHeaderCommandHandler : IRequestHandler<DeleteJournalHeaderCommand, ErrorOr<Unit>>
    {
        private readonly IJournalHeaderRepository _headerRepository;

        public DeleteJournalHeaderCommandHandler(IJournalHeaderRepository headerRepository)
        {
            _headerRepository = headerRepository;
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteJournalHeaderCommand command, CancellationToken cancellationToken)
        {
            try
            {
                await _headerRepository.DeleteAsync(command.id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                return Errors.JournalHeader.DeleteFailure(ex.Message);  
            }
        }
    }
}
