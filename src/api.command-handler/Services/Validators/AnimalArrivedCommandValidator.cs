using System.Linq;
using es.Commands;

namespace api.command_handler.Services.Validators
{
    public class AnimalsArrivedCommandValidator : ICommandValidator<AnimalsArrivedCommand>
    {
        public ValidationResult Validate(ICommand command) => Validate((AnimalsArrivedCommand) command);

        public ValidationResult Validate(AnimalsArrivedCommand command)
        {
            var result = new ValidationResult();

            if (command == null) return result;
            if (string.IsNullOrEmpty(command.From)) return result;
            if (command.Animals.Count() == 0) return result;

            result.MarkSuccess();

            return result;
        }
    }
}