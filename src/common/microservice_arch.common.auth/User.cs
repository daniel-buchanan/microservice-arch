using System;
using System.Collections.Generic;

namespace microservice_arch.common.auth
{
    public class User
    {
        public Guid Subject { get; set; }
        public UserType Type { get; set; }
        public List<ResourceAccess> Access { get; set; }
    }
}
