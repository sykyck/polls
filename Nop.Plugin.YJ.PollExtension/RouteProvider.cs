using System;
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

            routeBuilder.MapRoute("Plugin.YJ.PollExtension.GetAllPolls", "Plugins/PollExtension/GetAllPolls",
            new { controller = "Stories", action = "GetAllPolls" });

            routeBuilder.MapRoute("Plugin.YJ.PollExtension.GetPollById", "Plugins/PollExtension/GetPollById/{pollId}",
            new { controller = "Stories", action = "GetPollById", pollId = "" });

            routeBuilder.MapRoute("Plugin.YJ.PollExtension.GetPollAnswerImage", "Plugins/PollExtension/GetPollAnswerImage/{pollAnswerId}",
            new { controller = "Stories", action = "GetPollAnswerImage", pollAnswerId = "" });

            routeBuilder.MapRoute("Plugin.YJ.PollExtension.GetPollAnswerProduct", "Plugins/PollExtension/GetPollAnswerProduct/{pollAnswerId}",
            new { controller = "Stories", action = "GetPollAnswerProduct", pollAnswerId = "" });

            routeBuilder.MapRoute("Plugin.YJ.PollExtension.GetPollAnswers", "Plugins/PollExtension/GetPollAnswers/{pollId}",
            new { controller = "Stories", action = "GetPollAnswers", pollId = "" });
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
