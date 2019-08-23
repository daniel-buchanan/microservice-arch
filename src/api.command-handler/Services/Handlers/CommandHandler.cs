using System.Threading.Tasks;
using es;
using es.Commands;

namespace api.command_handler.Services.Handlers
{
    public abstract class CommandHandler<T> : ICommandHandler<T> where T: ICommand
    {
        private readonly ICommandValidator<T> _validator;
        private readonly IEventStreamApi _eventStreamApi;

        protected CommandHandler(IEventStreamApi eventStreamApi,
            ICommandValidator<T> validator)
        {
            _eventStreamApi = eventStreamApi;
            _validator = validator;
        }

        protected IEventStreamApi EventStreamApi => _eventStreamApi;

        public ValidationResult Validate(T command)
        {
            return _validator?.Validate(command) ?? ValidationResult.Success();
        }

        public abstract Task Process(T command);

        public ValidationResult Validate(ICommand command) => Validate((T) command);

        public Task Process(ICommand command) => Process((T) command);
    }
}
