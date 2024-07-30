using ErrorOr;
using JournalEntryTask.Domain.Models;
using MediatR;

namespace JournalEntryTask.Application.AccountCharts.Queries.ListAccountCharts
{
    public record ListAccountChartsQuery(): IRequest<ErrorOr<List<AccountsChart>>>;
}
