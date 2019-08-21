namespace api.core
{
    public interface IApiFactory
    {
        T Get<T>(string baseUri);
    }
}
