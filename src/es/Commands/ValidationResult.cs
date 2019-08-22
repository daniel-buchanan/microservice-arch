namespace es.Commands
{
    public class ValidationResult
    {
        public bool IsValid { get; private set; }

        public void MarkSuccess()
        {
            IsValid = true;
        }

        public static ValidationResult Success()
        {
            return new ValidationResult() { IsValid = true };
        }
    }
}
