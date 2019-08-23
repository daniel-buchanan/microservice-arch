namespace es.Commands
{
    public abstract class Command : ICommand
    {
        private string _json;

        public virtual void Initialise(string json)
        {
            _json = json;
        }

        public string Json => _json;
        public abstract string CommandType { get; }
    }
}
