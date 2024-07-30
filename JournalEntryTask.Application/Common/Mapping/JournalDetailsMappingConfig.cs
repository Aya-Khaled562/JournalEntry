using JournalEntryTask.Application.JournalDetails.Commands.CreateJournalDetails;
using JournalEntryTask.Application.JournalDetails.Commands.UpdateJournalDetails;
using Mapster;
using DomainJournalDetails = JournalEntryTask.Domain.Models.JournalDetails;

namespace JournalEntryTask.Application.Common.Mapping
{
    public class JournalDetailsMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateJournalDetailsCommand, DomainJournalDetails>();
            config.NewConfig<UpdateJournalDetailsCommand, DomainJournalDetails>();
        }
    }
}
