using ErrorOr;

namespace JournalEntryTask.Domain.Errors
{
    public static partial class Errors
    {
        public static class JournalHeader
        {
            public static Error NotFound(Guid id) => Error.NotFound(
                code: "JournalHeader.NotFound",
                description: $"JournalHeader with ID {id} was not found.");

            public static Error CreateFailure(string message) => Error.Failure(
                code: "JournalHeader.CreateFailure",
                description: message );

            public static Error UpdateFailure(string message) => Error.Failure(
                code: "JournalHeader.UpdateFailure",
                description: message );

            public static Error DeleteFailure(string message) => Error.Failure(
                code: "JournalHeader.DeleteFailure",
                description: message);
        }
    }

}
