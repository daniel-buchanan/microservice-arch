using System;
using System.Collections.Generic;
using System.Text;

namespace microservice_arch.common.auth
{
    public class ResourceAccess
    {
        public Guid ResourceId { get; private set; }
        public IResource Resource { get; private set; }
        public Guid Subject { get; private set; }
        public AccessType Access { get; private set; }

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
