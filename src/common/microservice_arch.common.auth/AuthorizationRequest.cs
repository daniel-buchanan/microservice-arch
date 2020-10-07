using System;
using System.Security.Cryptography;
using System.Text;

namespace microservice_arch.common.auth
{
    public class AuthorizationRequest
    {
        public string Path { get; set; }
        public Guid Subject { get; set; }
        public AccessType Access { get; set; }
        public Guid? ObjectId { get; set; }

        public string GetHash()
        {
            var content = $"{Subject}.{Path}.{ObjectId}.{Access}";
            using (var algorithm = SHA512.Create()) //or MD5 SHA256 etc.
            {
                var hashedBytes = algorithm.ComputeHash(Encoding.UTF8.GetBytes(content));

                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}
