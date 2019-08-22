namespace es.Commands
{
    public interface ICommandValidator
    {
        ValidationResult Validate(ICommand command);
    }

    public interface ICommandValidator<T> : ICommandValidator where T: ICommand
    {
        ValidationResult Validate(T command);
    }
}
