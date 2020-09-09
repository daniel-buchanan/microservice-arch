using System;

namespace microservice_arch.common.auth
{
    public class ResourceAccess
    {
        public Guid ResourceId { get; set; }
        public IResource Resource { get; set; }
        public Guid Subject { get; set; }
        public AccessType Access { get; set; }

        public static ResourceAccess ForKind(Resource resource)
        {
            return new ResourceAccess()
            {
                Resource = resource
            };
        }

        public ResourceAccess ForUser(Guid subject)
        {
            Subject = subject;
            return this;
        }

        public ResourceAccess WithAccess(AccessType access)
        {
            Access = access;
            return this;
        }

        public ResourceAccess ForResourceId(Guid resourceId)
        {
            ResourceId = resourceId;
            return this;
        }
    }
}
