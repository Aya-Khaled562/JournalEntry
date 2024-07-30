using ErrorOr;
using JournalEntryTask.Application.Common.Interfaces.Presistence;
using JournalEntryTask.Domain.Models;
using MediatR;

namespace JournalEntryTask.Application.AccountCharts.Queries.ListAccountCharts
{
    public class ListAccountChartsQueryHandler : IRequestHandler<ListAccountChartsQuery, ErrorOr<List<AccountsChart>>>
    {
        private readonly IAccountChartRepository _chartRepository;

        public ListAccountChartsQueryHandler(IAccountChartRepository chartRepository)
        {
            _chartRepository = chartRepository;
        }

        public async Task<ErrorOr<List<AccountsChart>>> Handle(ListAccountChartsQuery request, CancellationToken cancellationToken)
        {
            return await _chartRepository.GetAllAsync();
        }
    }
}
