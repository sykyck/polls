using System;
using System.Collections.Generic;
using System.Text;
using Nop.Core.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Nop.Plugin.YJ.PollExtension.Services;
using Microsoft.AspNetCore.Builder;
using Nop.Plugin.YJ.PollExtension.Data;
using Nop.Web.Framework.Infrastructure.Extensions;


namespace Nop.Plugin.YJ.PollExtension
{
    public class PollExtensionStartup : INopStartup
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PollExtensionObjectContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlServerWithLazyLoading(services);
            });
            services.AddSingleton<IPollExtensionService, PollExtensionService>();
        }

        public void Configure(IApplicationBuilder app)
        {
        }

        public int Order { get; }
    }
}
