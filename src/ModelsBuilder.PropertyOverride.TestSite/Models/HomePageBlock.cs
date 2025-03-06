using Umbraco.Cms.Infrastructure.ModelsBuilder;

namespace ModelsBuilder.PropertyOverride.TestSite.Models
{
    [ImplementAllPropertyTypes]
    public partial class HomePageBlock 
    {
        public virtual global::Umbraco.Cms.Core.Models.MediaWithCrops Image { get; set; }
        public virtual string SubTitle { get; set; }
        public virtual string Title { get; set; }
    }
}
