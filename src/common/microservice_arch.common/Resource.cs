namespace microservice_arch.common
{
    public interface IResource
    {
        string Urn { get; }
        string Name { get; }
        IResource WithName(string name);
    }

    public class Resource : IResource
    {
        public string Urn { get; private set; }
        public string Name { get; private set; }

        public IResource WithName(string name)
        {
            Name = name;
            return this;
        }

        public override string ToString() => Urn;

        public static IResource FromUrn(string urn) => new Resource()
        {
            Urn = urn
        };
    }
}
