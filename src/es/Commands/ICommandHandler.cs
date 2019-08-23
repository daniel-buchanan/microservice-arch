using System.Threading.Tasks;

namespace es.Commands
{
    public interface ICommandHandler
    {
        ValidationResult Validate(ICommand command);

        Task Process(ICommand command);
    }

    public interface ICommandHandler<T> : ICommandHandler where T: ICommand
    {
        ValidationResult Validate(T command);

        Task Process(T command);
    }
}
