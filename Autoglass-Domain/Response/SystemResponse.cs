using FluentValidation.Results;


namespace Autoglass_Domain.Response
{
    public class SystemResponse
    {
        public  object Data { get; set; }
        public  ValidationResult ValidationResult { get; set; }

        public SystemResponse()
        {
            ValidationResult = new ValidationResult();
        }

        public SystemResponse(object data)
        {
            Data = data;
        }

        public SystemResponse(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }

        public  SystemResponse(ValidationResult validationResult, object data)
        {
            ValidationResult = validationResult;
            Data = data;
        }

        public void AddError(string codigo, string message)
        {
            ValidationResult.Errors.Add(new ValidationFailure(codigo, message));
        }

        public void Result(object data)
        {
            Data = data;
        }

        public SystemResponse Return()
        {
            return this;
        }
    }
}
