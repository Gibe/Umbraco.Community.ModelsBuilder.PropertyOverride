using System.Reflection;
using System.Text;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Core.Configuration.Models;
using Umbraco.Cms.Core.Hosting;
using Umbraco.Cms.Infrastructure.ModelsBuilder;
using Umbraco.Cms.Infrastructure.ModelsBuilder.Building;
using Umbraco.Community.ModelsBuilder.PropertyOverride.Attributes;
using Umbraco.Extensions;
using File = System.IO.File;

namespace Umbraco.Community.ModelsBuilder.PropertyOverride
{
    public class PropertyOverrideModelsGenerator : IModelsGenerator
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly OutOfDateModelsStatus _outOfDateModels;
        private readonly UmbracoServices _umbracoService;
        private ModelsBuilderSettings _config;
        public PropertyOverrideModelsGenerator(UmbracoServices umbracoService,
            IOptionsMonitor<ModelsBuilderSettings> config,
            OutOfDateModelsStatus outOfDateModels,
            IHostingEnvironment hostingEnvironment)
        {
            _umbracoService = umbracoService;
            _config = config.CurrentValue;
            _outOfDateModels = outOfDateModels;
            _hostingEnvironment = hostingEnvironment;
            config.OnChange(x => _config = x);
        }

        public void GenerateModels()
        {
            var modelsDirectory = _config.ModelsDirectoryAbsolute(_hostingEnvironment);
            if (!Directory.Exists(modelsDirectory))
            {
                Directory.CreateDirectory(modelsDirectory);
            }

            foreach (var file in Directory.GetFiles(modelsDirectory, "*.generated.cs"))
            {
                File.Delete(file);
            }

            IList<TypeModel> typeModels = _umbracoService.GetAllTypes();

            // This is the custom bit
            typeModels = FilterForPropertyOverrides(typeModels);

            var builder = new TextBuilder(_config, typeModels);

            foreach (TypeModel typeModel in builder.GetModelsToGenerate())
            {
                var sb = new StringBuilder();
                builder.Generate(sb, typeModel);
                var filename = Path.Combine(modelsDirectory, typeModel.ClrName + ".generated.cs");
                File.WriteAllText(filename, sb.ToString());
            }

            // the idea was to calculate the current hash and to add it as an extra file to the compilation,
            // in order to be able to detect whether a DLL is consistent with an environment - however the
            // environment *might not* contain the local partial files, and thus it could be impossible to
            // calculate the hash. So... maybe that's not a good idea after all?
            /*
            var currentHash = HashHelper.Hash(ourFiles, typeModels);
            ourFiles["models.hash.cs"] = $@"using Umbraco.ModelsBuilder;
    [assembly:ModelsBuilderAssembly(SourceHash = ""{currentHash}"")]
    ";
            */

            _outOfDateModels.Clear();
        }


        /// <summary>
        /// Note - this is the part we have customised - all other code is from Umbraco.Cms.Infrastructure.ModelsBuilder.Building.ModelsGenerator
        /// </summary>
        /// <param name="typeModels"></param>
        /// <returns></returns>
        private IList<TypeModel> FilterForPropertyOverrides(IList<TypeModel> typeModels)
        {
            foreach (var model in typeModels)
            {
                string fullTypeName = $"{_config.ModelsNamespace}.{model.ClrName}";

                var underlyingType = Type.GetType(fullTypeName)
                        ?? AppDomain.CurrentDomain.GetAssemblies()
                            .Select(a => a.GetType(fullTypeName))
                            .FirstOrDefault(t => t != null);

                if (underlyingType == null)
                {
                    continue;
                }

                var aliasOverrides = underlyingType
                        .GetProperties()
                        .Select(propertyInfo => new { Property = propertyInfo, Attr = propertyInfo.GetCustomAttribute<PropertyOverrideAttribute>(inherit: true) })
                        .Where(x => x.Attr != null && !string.IsNullOrWhiteSpace(x.Attr.Alias))
                        .Select(x => x.Attr!.Alias)
                        .ToHashSet(StringComparer.OrdinalIgnoreCase);

                var propertiesToRemove = new List<PropertyModel>();
                foreach (var property in model.Properties)
                {
                    if (aliasOverrides.Contains(property.Alias))
                    {
                        propertiesToRemove.Add(property);
                        continue;
                    }

                    var propertyInfo = underlyingType.GetProperty(property.ClrName);
                    if (propertyInfo != null)
                    {
                        var attr = propertyInfo.GetCustomAttribute<PropertyOverrideAttribute>(inherit: true);
                        if (attr != null && string.IsNullOrWhiteSpace(attr.Alias))
                        {
                            propertiesToRemove.Add(property);
                            continue;
                        }
                    }
                }

                if (propertiesToRemove.Any())
                {
                    model.Properties.RemoveAll(propertiesToRemove.Contains);
                }
            }

            return typeModels;
        }
    }
}
