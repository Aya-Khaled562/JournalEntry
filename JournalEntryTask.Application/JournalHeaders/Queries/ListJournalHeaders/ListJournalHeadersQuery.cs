using ErrorOr;
using JournalEntryTask.Domain.Models;
using MediatR;

namespace JournalEntryTask.Application.JournalHeaders.Queries.ListJournalHeaders
{
    public record ListJournalHeadersQuery(): IRequest<ErrorOr<List<JournalHeader>>>;
}
