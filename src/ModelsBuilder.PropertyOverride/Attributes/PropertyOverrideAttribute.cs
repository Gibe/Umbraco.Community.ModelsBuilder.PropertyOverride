using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umbraco.Community.ModelsBuilder.PropertyOverride.Attributes
{
    /// <summary>
	/// Attribute which can be used to ignore a single property type when building models.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class PropertyOverrideAttribute : Attribute
    {
        /// <summary>
        /// Gets the alias provided to the attribute.
        /// </summary>
        public string? Alias { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelBuilderIgnoreAttribute"/> class.
        /// </summary>
        public PropertyOverrideAttribute() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelBuilderIgnoreAttribute"/> class with a specified alias, use this if the alias of your property doesn't match the property name.
        /// </summary>
        public PropertyOverrideAttribute(string alias)
        {
            Alias = alias;
        }
    }
}
