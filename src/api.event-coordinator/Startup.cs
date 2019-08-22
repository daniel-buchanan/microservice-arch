using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using auth;
using api.core;
using Hangfire;
using Hangfire.MemoryStorage;
using api.event_coordinator.Services;
using core;

namespace api.event_coordinator
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiFactory();
            AuthRegistry.RegisterServices(services, KnownServices.Authenticator);
            services.AddScoped<ServiceAuthOptions>((provider) => {
                return new ServiceAuthOptions(KnownServices.EventCoordinator, string.Empty);
            });

            services.AddApiService<ISnapshotApi>(KnownServices.Snapshot);
            services.AddSingleton<IQueue, Queue>();
            services.AddScoped<QueueCheckJob>();

            services.AddMvc(AuthRegistry.RegisterFilters).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            SetupHangfire(serviceProvider);
            app.UseHangfireServer(new Hangfire.BackgroundJobServerOptions() {
                Queues = new[] { "DEFAULT" },
                WorkerCount = 1
            });
            app.UseHangfireDashboard();
        }

        private void SetupHangfire(IServiceProvider serviceProvider)
        {
            GlobalConfiguration.Configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseActivator(new HangfireActivator(serviceProvider))
                .UseMemoryStorage();

            RecurringJob.AddOrUpdate<QueueCheckJob>(q => q.Run(), Cron.Minutely());
        }
    }
}
