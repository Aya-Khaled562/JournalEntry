using ErrorOr;

namespace JournalEntryTask.Domain.Errors
{
    public static partial class Errors
    {
        public static class JournalDetails
        {
            public static Error NotFound(Guid id) => Error.NotFound(
                code: "JournalDetails.NotFound",
                description: $"JournalHeader with ID {id} was not found.");

            public static Error CreateFailure(string message) => Error.Failure(
                code: "JournalDetails.CreateFailure",
                description: message );

            public static Error UpdateFailure(string message) => Error.Failure(
                code: "JournalDetails.UpdateFailure",
                description: message );

            public static Error DeleteFailure(string message) => Error.Failure(
                code: "JournalDetails.DeleteFailure",
                description: message);
        }
    }

}
