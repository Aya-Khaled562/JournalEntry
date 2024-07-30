using FluentValidation;

namespace JournalEntryTask.Application.JournalHeaders.Commands.CreateJournalHeader
{
    public class CreateJournalHeaderCommandValidator : AbstractValidator<CreateJournalHeaderCommand>
    {
        public CreateJournalHeaderCommandValidator()
        {
            RuleFor(jh => jh.EntryDate)
                 .NotEmpty().WithMessage("EntryDate is required");

            RuleFor(jh => jh.Description)
                .NotEmpty().WithMessage("Description is required");

            RuleFor(jh => jh.EntryNumber)
                .NotEmpty().WithMessage("EntryNumber is required");
        }
    }
}
