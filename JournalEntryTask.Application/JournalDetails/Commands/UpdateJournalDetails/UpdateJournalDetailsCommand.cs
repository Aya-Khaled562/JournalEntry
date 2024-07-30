using ErrorOr;
using MediatR;
using DomainJournalDetails = JournalEntryTask.Domain.Models.JournalDetails;
namespace JournalEntryTask.Application.JournalDetails.Commands.UpdateJournalDetails
{
    public record UpdateJournalDetailsCommand(
         Guid Id,
         decimal? Debit,
         decimal? Credit,
         Guid? JournalHeaderId,
         Guid? AccountId) : IRequest<ErrorOr<DomainJournalDetails>>;
}
