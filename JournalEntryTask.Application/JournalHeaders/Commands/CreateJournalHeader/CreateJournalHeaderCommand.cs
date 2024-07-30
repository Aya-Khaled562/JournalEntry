using ErrorOr;
using MediatR;
using JournalEntryTask.Domain.Models;

namespace JournalEntryTask.Application.JournalHeaders.Commands.CreateJournalHeader
{
    public record CreateJournalHeaderCommand(
        DateTime EntryDate,
        int EntryNumber,
        string Description) : IRequest<ErrorOr<JournalHeader>>;

}
