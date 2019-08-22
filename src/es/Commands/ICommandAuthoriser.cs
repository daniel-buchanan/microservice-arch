namespace es.Commands
{
    public interface ICommandAuthoriser<T> where T: ICommand
    {
        bool Authorise(T command);
    }
}
