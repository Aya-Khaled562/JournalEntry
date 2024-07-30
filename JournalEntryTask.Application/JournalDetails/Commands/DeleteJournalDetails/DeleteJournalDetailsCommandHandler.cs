using ErrorOr;
using JournalEntryTask.Application.Common.Interfaces.Presistence;
using JournalEntryTask.Domain.Errors;
using MediatR;

namespace JournalEntryTask.Application.JournalDetails.Commands.DeleteJournalDetails
{
    public class DeleteJournalDetailsCommandHandler : IRequestHandler<DeleteJournalDetailsCommand, ErrorOr<Unit>>
    {
        private readonly IJournalDetailsRepository _detailsRepository;

        public DeleteJournalDetailsCommandHandler(IJournalDetailsRepository detailsRepository)
        {
            _detailsRepository = detailsRepository;
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteJournalDetailsCommand command, CancellationToken cancellationToken)
        {
            try
            {
                await _detailsRepository.DeleteAsync(command.id);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                return Errors.JournalDetails.DeleteFailure(ex.Message);
            }
        }
    }
}
