using Microsoft.Extensions.DependencyInjection;
using Portfolio.Core.Services;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Portfolio.Core.Models.Umbraco.Components
{
    public class StartupComposer: IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.AddSingleton<ITestService, TestService>();
            throw new System.NotImplementedException();
        }
    }
}