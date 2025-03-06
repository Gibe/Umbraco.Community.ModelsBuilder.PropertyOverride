using Umbraco.Cms.Core.Manifest;

namespace Umbraco.Community.ModelsBuilder.PropertyOverride
{
    internal class ModelsBuilder.PropertyOverrideManifestFilter : IManifestFilter
    {
        public void Filter(List<PackageManifest> manifests)
        {
            var assembly = typeof(ModelsBuilder.PropertyOverrideManifestFilter).Assembly;

            manifests.Add(new PackageManifest
            {
                PackageName = "Models Builder .Property Override ",
                Version = assembly.GetName()?.Version?.ToString(3) ?? "0.1.0",
                AllowPackageTelemetry = true,
                Scripts = new string[] {
                    // List any Script files
                    // Urls should start '/App_Plugins/ModelsBuilder.PropertyOverride/' not '/wwwroot/ModelsBuilder.PropertyOverride/', e.g.
                    // "/App_Plugins/ModelsBuilder.PropertyOverride/Scripts/scripts.js"
                },
                Stylesheets = new string[]
                {
                    // List any Stylesheet files
                    // Urls should start '/App_Plugins/ModelsBuilder.PropertyOverride/' not '/wwwroot/ModelsBuilder.PropertyOverride/', e.g.
                    // "/App_Plugins/ModelsBuilder.PropertyOverride/Styles/styles.css"
                }
            });
        }
    }
}
