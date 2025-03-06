using Umbraco.Cms.Infrastructure.ModelsBuilder;
using Umbraco.Community.ModelsBuilder.PropertyOverride.Attributes;

namespace ModelsBuilder.PropertyOverride.TestSite.Models
{
    public partial class Home
    {
        [PropertyOverride("content")]
        public global::Umbraco.Cms.Core.Models.Blocks.BlockListModel Content => this.Value<global::Umbraco.Cms.Core.Models.Blocks.BlockListModel>(_publishedValueFallback, "content");

        [PropertyOverride("title")]
        public virtual string Title => this.Value<string>(_publishedValueFallback, "title");
    }
}
