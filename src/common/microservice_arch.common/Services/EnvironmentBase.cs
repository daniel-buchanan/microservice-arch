using Microsoft.Extensions.Logging;
using System;

namespace microservice_arch.common.Services
{
    public interface IEnvironmentBase
    {
        string GetEnvironmentVariable(string name);
    }

    public class EnvironmentBase : IEnvironmentBase
    {
        private readonly ILogger<EnvironmentBase> logger;

        public EnvironmentBase(ILogger<EnvironmentBase> logger)
        {
            this.logger = logger;
        }

        public string GetEnvironmentVariable(string name)
        {
            this.logger.LogInformation($"EnvironmentBase :: Get {name}");
            return Environment.GetEnvironmentVariable(name);
        }
    }
}
