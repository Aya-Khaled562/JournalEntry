using ErrorOr;
using MediatR;
using DomainJournalDetails = JournalEntryTask.Domain.Models.JournalDetails;

namespace JournalEntryTask.Application.JournalDetails.Queries.GetJournalDetailsById
{
    public record GetJournalDetailsByIdQuery(Guid Id): IRequest<ErrorOr<DomainJournalDetails>>;
}
