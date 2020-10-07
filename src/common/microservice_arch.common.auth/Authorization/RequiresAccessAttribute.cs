using System;

namespace microservice_arch.common.auth.Authorization
{
    public class RequiresAccessAttribute : Attribute
    {
        public AccessType Access { get; set; }

        public RequiresAccessAttribute() { }

        public RequiresAccessAttribute(AccessType access)
        {
            Access = access;
        }
    }
}
