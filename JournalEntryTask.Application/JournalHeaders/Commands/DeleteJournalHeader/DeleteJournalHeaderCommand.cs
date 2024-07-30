using ErrorOr;
using MediatR;

namespace JournalEntryTask.Application.JournalHeaders.Commands.DeleteJournalHeader
{
    public record DeleteJournalHeaderCommand(Guid id) : IRequest<ErrorOr<Unit>>;
}
