using ErrorOr;
using MediatR;
using DomainJournalDetails = JournalEntryTask.Domain.Models.JournalDetails;

namespace JournalEntryTask.Application.JournalDetails.Queries.ListJournalDetails
{
    public record ListJournalDetailsQuery: IRequest<ErrorOr<List<DomainJournalDetails>>>;
}
