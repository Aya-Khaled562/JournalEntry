using ErrorOr;
using MediatR;

namespace JournalEntryTask.Application.JournalDetails.Commands.DeleteJournalDetails
{
    public record DeleteJournalDetailsCommand(Guid id): IRequest<ErrorOr<Unit>>;
}
