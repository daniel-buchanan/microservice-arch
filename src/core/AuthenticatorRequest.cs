namespace core
{
    public class AuthenticatorRequest
    {
        public string Path { get; set; }
        public string Subject { get; set; }
        public ServiceAuthOptions Service { get; set; }
    }
}
