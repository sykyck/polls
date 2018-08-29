﻿using System;
using System.Collections.Generic;
using System.Text;
using Nop.Web.Framework.Mvc.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Nop.Plugin.YJ.PollExtension
{
    public partial class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Plugin.YJ.PollExtension.GetRandomPoll", "Plugins/PollExtension/GetRandomPoll",
            new { controller = "Stories", action = "GetRandomPoll" });
        }
        public int Priority
        {
            get
            {
                return -1;
            }
        }
    }
}
