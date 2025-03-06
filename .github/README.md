# Umbraco.Community.ModelsBuilder.PropertyOverride 

[![Downloads](https://img.shields.io/nuget/dt/Umbraco.Community.ModelsBuilder.PropertyOverride?color=cc9900)](https://www.nuget.org/packages/Umbraco.Community.ModelsBuilder.PropertyOverride/)
[![NuGet](https://img.shields.io/nuget/vpre/Umbraco.Community.ModelsBuilder.PropertyOverride?color=0273B3)](https://www.nuget.org/packages/Umbraco.Community.ModelsBuilder.PropertyOverride)
[![GitHub license](https://img.shields.io/github/license/Gibe/Umbraco.Community.ModelsBuilder.PropertyOverride?color=8AB803)](../LICENSE)

This package re-introduces functionality for overriding ModelsBuilder property implementations that was lost in Umbraco 9+.

Umbraco versions 13.x are supported.

Properties can be marked up with a re-implemented `[ImplementPropertyType("alias")]` attribute, which causes them to be ignored when generating models through the default ModelsBuilder.

In addition, classes can be marked up with `[ImplementAllPropertyTypes]`, which causes all properties on the class to be ignored, this is functionally equivalent to adding `[ImplementPropertyType("alias")]` to every property on the class.

Legacy (Umbraco 8.x) documentation for the `[ImplementPropertyType("alias")]` attribute can be found [here](https://our.umbraco.com/Documentation/Reference/Templating/Modelsbuilder/Control-Generation-vpre8_5#implement-property-type).

## Examples

`[ImplementPropertyType("alias")]` to ignore properties on an individual basis:

```
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
```

`[ImplementAllPropertyTypes]` to ignore all properties:

```
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
```

## Installation

Add the package to an existing Umbraco website (Umbraco 13+) from nuget:

`dotnet add package Umbraco.Community.ModelsBuilder.PropertyOverride`

## Contributing

Contributions to this package are most welcome!

## Acknowledgments

[tristanjthompson](https://github.com/tristanjthompson) & [zade107](http://github.com/zade107)
