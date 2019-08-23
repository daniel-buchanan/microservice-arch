using Newtonsoft.Json;

namespace es.Commands
{
    public class Command : ICommand
    {
        private string _json;

        public Command()
        {
            
        }

        protected Command(string type)
        {
            CommandType = type;
        }

        public virtual void Initialise(string json)
        {
            _json = json;
        }

        public string Json => _json;
        public string CommandType { get; set; }

        public static ICommand FromType(string json) 
        {
            var genericCommand = JsonConvert.DeserializeObject<Command>(json);
            return CommandFinder.FromType(genericCommand.CommandType, json);
        }
    }
}
