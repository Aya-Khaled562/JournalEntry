using FluentValidation;

namespace JournalEntryTask.Application.JournalHeaders.Commands.CreateJournalHeader
{
    public class CreateJournalHeaderCommandValidator : AbstractValidator<CreateJournalHeaderCommand>
    {
        public CreateJournalHeaderCommandValidator()
        {
            RuleFor(jh => jh.EntryDate).NotEmpty();
            RuleFor(jh => jh.Description).NotEmpty();
            RuleFor(jh => jh.EntryNumber).NotEmpty();
        }
    }
}
