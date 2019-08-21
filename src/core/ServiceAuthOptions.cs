namespace core
{
    public class ServiceAuthOptions
    {
        public ServiceAuthOptions() { }

        public ServiceAuthOptions(string service, string key)
        {
            Service = service;
            Key = key;
        }

        public string Key { get; set; }
        public string Service { get; set; }
    }
}
