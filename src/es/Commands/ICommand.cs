namespace es.Commands
{
    public interface ICommand
    {
        void Initialise(string json);
        string Json { get; }
    }
}
