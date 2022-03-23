//https://dev.to/isaacojeda/aspnet-core-6-minimal-apis-y-carter-3f8k

using FluentValidation.Results;

namespace DTMoney.Api.Extensions
{
    public static class ValidationResultExtensions
    {
        public static Dictionary<string, string[]> ToValidationProblems(this ValidationResult result)
        {
            return result.Errors
                    .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                    .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

    }
}
