using FluentValidation;
using JournalEntryTask.Application.Common.Interfaces.Presistence;

namespace JournalEntryTask.Application.JournalDetails.Commands.CreateJournalDetails
{
    public class CreateJournalDetailsCommandValidation: AbstractValidator<CreateJournalDetailsCommand>
    {
        private readonly IJournalHeaderRepository _headerRepository;
        private readonly IAccountChartRepository _chartRepository;

        public CreateJournalDetailsCommandValidation(IJournalHeaderRepository headerRepository , IAccountChartRepository chartRepository)
        {
            _headerRepository = headerRepository;
            _chartRepository = chartRepository;

            RuleFor(jd => jd.Debit)
                .NotEmpty().WithMessage("Debit is required");

            RuleFor(jd => jd.Credit)
                .NotEmpty().WithMessage("Credit is required");

            RuleFor(jd => jd.JournalHeaderId)
                .NotEmpty().WithMessage("JournalHeaderId is required")
                .Must(IsJournalHeaderIdValid).WithMessage("Invalid JournalHeaderId");

            RuleFor(jd => jd.AccountId)
                .NotEmpty().WithMessage("AccountId is required")
                .Must(IsJournalHeaderIdValid).WithMessage("Invalid AccountId");
        }

        private bool IsJournalHeaderIdValid(Guid journalHeaderId)
        {
            var isJournalExist = _headerRepository.GetByIdAsync(journalHeaderId).Result;

            if (isJournalExist == null)
            {
                return false;
            }
            return true;
        }

        private bool IsAccountIdValid(Guid accountId)
        {
            var isJournalExist = _chartRepository.GetByIdAsync(accountId).Result;

            if (isJournalExist == null)
            {
                return false;
            }
            return true;
        }
    }
}
