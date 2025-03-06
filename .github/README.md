# Models Builder .Property Override 

[![Downloads](https://img.shields.io/nuget/dt/Umbraco.Community.ModelsBuilder.PropertyOverride?color=cc9900)](https://www.nuget.org/packages/Umbraco.Community.ModelsBuilder.PropertyOverride/)
[![NuGet](https://img.shields.io/nuget/vpre/Umbraco.Community.ModelsBuilder.PropertyOverride?color=0273B3)](https://www.nuget.org/packages/Umbraco.Community.ModelsBuilder.PropertyOverride)
[![GitHub license](https://img.shields.io/github/license/Gibe/Umbraco.Community.ModelsBuilder.PropertyOverride?color=8AB803)](../LICENSE)

This package provides functionality for overriding Models Builder property implementations.

Umbraco versions 13.x - 15.x are supported.

Properties can be marked up with a re-implemented [ImplementPropertyType("alias")] attribute, which causes them to be ignored when generating models through the default Models Builder.

In addition, classes can be marked up with [ImplementAllPropertyTypes], which causes all properties on the class to be ignored, this is functionally equivalent to adding [ImplementPropertyType("alias")] to every property on the class.

## Examples

[ImplementPropertyType("alias")] to ignore properties on an individual basis:

![ImplementPropertyType](docs/screenshots/implement-property-type.png)

[ImplementAllPropertyTypes] to ignore all properties:

![ImplementAllPropertyTypes](docs/screenshots/implement-all-property-types.png)

## Installation

Add the package to an existing Umbraco website (v13+) from nuget:

`dotnet add package Umbraco.Community.ModelsBuilder.PropertyOverride`

## Contributing

Contributions to this package are most welcome!

## Acknowledgments

[tristanjthompson](https://github.com/tristanjthompson) & [zade107](http://github/zade107)