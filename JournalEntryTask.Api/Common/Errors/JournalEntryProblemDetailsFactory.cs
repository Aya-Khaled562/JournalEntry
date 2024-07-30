using ErrorOr;
using JournalEntryTask.Api.Common.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace JournalEntryTask.Api.Common.Errors
{
    public class JournalEntryProblemDetailsFactory : ProblemDetailsFactory
    {
        private readonly ApiBehaviorOptions _options;

        public JournalEntryProblemDetailsFactory(IOptions<ApiBehaviorOptions> options)
        {
            _options = options.Value ?? throw new ArgumentNullException(nameof(options));
        }

        public override ProblemDetails CreateProblemDetails(
            HttpContext httpContext,
            int? statusCode = null,
            string? title = null,
            string? type = null,
            string? detail = null,
            string? instance = null)
        {
            statusCode ??= 500;
            ProblemDetails problemDetails = new ProblemDetails()
            {
                Title = title,
                Status = statusCode,
                Type = type,
                Detail = detail,
                Instance = instance
            };

            ApplyProblemDetailsDefault(httpContext, problemDetails, statusCode.Value);

            return problemDetails;
        }

        public override ValidationProblemDetails CreateValidationProblemDetails(
            HttpContext httpContext,
            ModelStateDictionary modelStateDictionary,
            int? statusCode = null,
            string? title = null,
            string? type = null,
            string? detail = null,
            string? instance = null)
        {
            statusCode ??= 400;
            title ??= "One or more validation errors occurred.";
            type ??= "https://tools.ietf.org/html/rfc7231#section-6.5.1";

            var problemDetails = new ValidationProblemDetails()
            {
                Title = title,
                Status = statusCode,
                Type = type,
                Detail = detail,
                Instance = instance
            };

            ApplyProblemDetailsDefault(httpContext, problemDetails , statusCode.Value);

            return problemDetails;
        }

        private void ApplyProblemDetailsDefault(HttpContext httpContext, ProblemDetails problemDetails , int statusCode)
        {
            problemDetails.Status ??= statusCode;

            if(_options.ClientErrorMapping.TryGetValue(statusCode, out var clientErrorData))
            {
                problemDetails.Title ??= clientErrorData.Title;
                problemDetails.Type ??= clientErrorData.Link;
            }

            var traceId = Activity.Current?.Id ?? httpContext?.TraceIdentifier;
            if (traceId != null)
            {
                problemDetails.Extensions["traceId"] = traceId;
            }

            var errors = httpContext?.Items[HttpContextItemKeys.Errors] as List<Error>;
            if (errors is not null)
            {
                problemDetails.Extensions.Add("errors", errors.Select(e => e.Description));
            }
        }
    }
}
