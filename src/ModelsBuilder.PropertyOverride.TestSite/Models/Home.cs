using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Infrastructure.ModelsBuilder;

namespace ModelsBuilder.PropertyOverride.TestSite.Models
{
    public partial class Home
    {
        //[ImplementPropertyType("content")]
        //public IEnumerable<HomePageBlock> Content => this.Value<BlockListModel>("content").Select(x => x.Content as HomePageBlock).ToList();

        [ImplementPropertyType("title")]
        public virtual string Title { get; set; }
    }
}
