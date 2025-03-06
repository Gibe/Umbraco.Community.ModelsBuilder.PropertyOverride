using Umbraco.Cms.Infrastructure.ModelsBuilder;

namespace ModelsBuilder.PropertyOverride.TestSite.Models
{
    public partial class Home
    {
        [ImplementPropertyType("content")]
        public global::Umbraco.Cms.Core.Models.Blocks.BlockListModel Content => this.Value<global::Umbraco.Cms.Core.Models.Blocks.BlockListModel>(_publishedValueFallback, "content");

        [ImplementPropertyType("title")]
        public virtual string Title => this.Value<string>(_publishedValueFallback, "title");
    }
}
