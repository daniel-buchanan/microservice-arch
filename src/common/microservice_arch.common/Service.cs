namespace microservice_arch.common
{
    public class Service
    {
        public const string ServiceLocator = "servicelocator";
        public const string Authenticator = "authenticator";
        public const string Authorization = "authorization";
        public const string Farms = "farms";
        public const string Animals = "animals";
        public const string Processing = "processing";
        

        public string Url { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public bool RequiresAuth { get; set; }

        public Service WithName(string name)
        {
            Name = name;
            return this;
        }

        public Service WithKey(string key)
        {
            Key = key;
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
