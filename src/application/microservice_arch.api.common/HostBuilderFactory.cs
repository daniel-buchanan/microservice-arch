using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace microservice_arch.api.common
{
    public interface IHostBuilderFactory<T>
        where T : class
    {
        IHostBuilder Get(string[] args);
    }

    public class HostBuilderFactory<T> : IHostBuilderFactory<T>
        where T : class
    {
        public IHostBuilder Get(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<T>();
                });
        }
    }
}
