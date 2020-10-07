using System;

namespace microservice_arch.common.auth
{
    public class AuthorizationResponse
    {
        public bool Success { get; set; }
        public Guid Subject { get; set; }
        public string Reason { get; set; }
        public Guid? ObjectId { get; set; }
        public DateTimeOffset? Expires { get; set; }
        public Guid Id { get; set; }
    }
}
