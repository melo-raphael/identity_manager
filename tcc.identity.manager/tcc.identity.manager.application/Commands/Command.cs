using FluentValidation.Results;

namespace tcc.identity.manager.application.Commands
{
    public abstract class Command
    {
        protected ValidationResult ValidationResult { get; set; }
        public ValidationResult GetValidationResult()
        {
            return ValidationResult;
        }

        public abstract bool IsValid();
    }
}
