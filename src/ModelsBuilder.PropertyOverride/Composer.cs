using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Infrastructure.ModelsBuilder.Building;

namespace Umbraco.Community.ModelsBuilder.PropertyOverride
{
    public class Composer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.AddSingleton<IModelsGenerator, PropertyOverrideModelsGenerator>();
        }
    }
}
