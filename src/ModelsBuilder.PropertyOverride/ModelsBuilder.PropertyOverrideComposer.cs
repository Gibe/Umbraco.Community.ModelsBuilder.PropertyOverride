using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Umbraco.Community.ModelsBuilder.PropertyOverride
{
    internal class ModelsBuilder.PropertyOverrideComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.ManifestFilters().Append<ModelsBuilder.PropertyOverrideManifestFilter>();
        }
    }
}
