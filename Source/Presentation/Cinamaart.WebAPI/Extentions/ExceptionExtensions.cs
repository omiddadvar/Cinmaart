using Cinamaart.Domain.Abstractions;
using FluentValidation;
using FluentValidation.Results;

namespace Cinamaart.WebAPI.Extentions
{
    public static class ExceptionExtensions
    {
        public static IList<Error> ToStandardErrors(this ValidationException ex)
        {
            var errors = new List<Error>();
            var validationFailureList = (List<ValidationFailure>)ex.Errors;
            validationFailureList.ForEach(x => errors.Add(new Error("Validation.Error", x.ErrorMessage)));
            return errors;
        }
        public static IList<Error> ToStandardErrors(this Exception ex)
        {
            var errors = new List<Error>();
            errors.Add(new Error("Unexpected.Error", ex.Message));
            return errors;
        }
    }
}
