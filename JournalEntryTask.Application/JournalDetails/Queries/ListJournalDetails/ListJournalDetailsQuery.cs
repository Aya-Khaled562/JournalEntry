using ErrorOr;
using MediatR;
using DomainJournalDetails = JournalEntryTask.Domain.Models.JournalDetails;

namespace JournalEntryTask.Application.JournalDetails.Queries.ListJournalDetails
{
    public record ListJournalDetailsQuery(Guid journalHeaderId): IRequest<ErrorOr<List<DomainJournalDetails>>>;
}
