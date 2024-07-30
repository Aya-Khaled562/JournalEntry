using JournalEntryTask.Application.JournalHeaders.Commands.CreateJournalHeader;
using JournalEntryTask.Application.JournalHeaders.Commands.UpdateJournalHeader;
using JournalEntryTask.Domain.Models;
using Mapster;

namespace JournalEntryTask.Application.Common.Mapping
{
    public class JournalHeaderMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateJournalHeaderCommand, JournalHeader>();
            config.NewConfig<UpdateJournalHeaderCommand, JournalHeader>();
        }
    }
}
