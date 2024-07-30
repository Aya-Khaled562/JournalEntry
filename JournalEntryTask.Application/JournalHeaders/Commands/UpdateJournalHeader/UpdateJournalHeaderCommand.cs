using ErrorOr;
using JournalEntryTask.Domain.Models;
using MediatR;

namespace JournalEntryTask.Application.JournalHeaders.Commands.UpdateJournalHeader
{
    public record UpdateJournalHeaderCommand(
        Guid Id,
        DateTime? EntryDate,
        int? EntryNumber,
        string? Description): IRequest<ErrorOr<JournalHeader>>;
}
