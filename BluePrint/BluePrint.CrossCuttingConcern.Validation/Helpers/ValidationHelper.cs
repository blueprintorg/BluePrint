using FluentValidation;

namespace BluePrint.CrossCuttingConcern.Validation.Helpers
{
    public static class ValidationHelper
    {
        /// <summary>
        /// Validates the specified validator.
        /// </summary>
        /// <param name="validator">The validator.</param>
        /// <param name="entity">The entity.</param>
        /// <exception cref="ValidationException"></exception>
        public static void Validate(IValidator validator, object entity)
        {
            var result = validator.Validate(entity);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
