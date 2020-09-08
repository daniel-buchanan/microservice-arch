namespace microservice_arch.common
{
    public static class Resources
    {
        public static IResource Farm = Resource.FromUrn("urn:ag:farm").WithName("Farm");
        public static IResource Animal = Resource.FromUrn("urn:ag:animal").WithName("Animal");
    }
}
