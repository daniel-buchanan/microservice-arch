using System;

namespace microservice_arch.common.auth
{
    [Flags]
    public enum AccessType
    {
        Read = 0,
        Create = 1,
        Put = 2,
        Delete = 4
    }
}
