using ErrorOr;
using JournalEntryTask.Domain.Models;
using MediatR;

namespace JournalEntryTask.Application.JournalHeaders.Queries.GetJournalHeaderById
{
    public record GetJournalHeaderByIdQuery(Guid Id): IRequest<ErrorOr<JournalHeader>>;
}
