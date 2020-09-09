namespace microservice_arch.common
{
    public class Service
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public bool RequiresAuth { get; set; }

        public Service WithName(string name)
        {
            Name = name;
            return this;
        }

        public Service RequiresAuthentication()
        {
            RequiresAuth = true;
            return this;
        }

        public static Service FromUrl(string url)
        {
            return new Service() { Url = url };
        }
    }
}
