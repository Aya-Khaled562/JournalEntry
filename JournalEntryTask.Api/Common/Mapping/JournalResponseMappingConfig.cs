using JournalEntryTask.Api.Common.Dto;
using JournalEntryTask.Domain.Models;
using Mapster;

namespace JournalEntryTask.Api.Common.Mapping
{
    public class JournalResponseMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<JournalHeader, JournalHeaderResponse>();
            config.NewConfig<JournalDetails, JournalDetailsResponse>();
            config.NewConfig<AccountsChart, AccountChartResponse>();
        }
    }
}
