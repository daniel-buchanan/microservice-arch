using Refit;

namespace api.core
{
    public class ApiFactory : IApiFactory
    {
        public T Get<T>(string baseUri) => RestService.For<T>(baseUri);
    }
}
