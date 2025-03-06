using Umbraco.Cms.Infrastructure.ModelsBuilder;

namespace ModelsBuilder.PropertyOverride.TestSite.Models
{
    public partial class Home
    {
        [ImplementPropertyType("content")]
        public global::Umbraco.Cms.Core.Models.Blocks.BlockListModel Content { get; set; }
        [ImplementPropertyType("title")]
        public virtual string Title { get; set; }
    }
}
