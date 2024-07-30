using ErrorOr;
using MediatR;
using DomainJournalDetails = JournalEntryTask.Domain.Models.JournalDetails;
namespace JournalEntryTask.Application.JournalDetails.Commands.CreateJournalDetails
{
    public record CreateJournalDetailsCommand(
         decimal Debit,
         decimal Credit,
         Guid JournalHeaderId,
         Guid AccountId): IRequest<ErrorOr<DomainJournalDetails>>;
}
