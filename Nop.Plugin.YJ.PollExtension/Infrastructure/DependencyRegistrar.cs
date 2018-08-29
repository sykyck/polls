using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Core;
using Nop.Data;
using Nop.Core.Data;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Plugin.YJ.PollExtension.Services;
using Nop.Plugin.YJ.PollExtension.Data;
using Nop.Web.Framework.Infrastructure.Extensions;
using Nop.Plugin.YJ.PollExtension.Domain;

namespace Nop.Plugin.YJ.PollExtension.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        private const string CONTEXT_NAME = "nop_object_context_yj_pollextension";
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            //register PollExtensionService
            builder.RegisterType<PollExtensionService>().As<IPollExtensionService>().InstancePerLifetimeScope();

            //data context
            builder.RegisterPluginDataContext<PollExtensionObjectContext>(CONTEXT_NAME);

            //override required repository with our custom context
          //  builder.RegisterType<EfRepository<PollAnswer>>().As<IRepository<PollAnswer>>()
            //   .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
           //    .InstancePerLifetimeScope();
        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order
        {
            get { return 1; }
        }
    }
}
