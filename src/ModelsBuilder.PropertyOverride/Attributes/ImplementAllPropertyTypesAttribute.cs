namespace Umbraco.Cms.Infrastructure.ModelsBuilder
{
    /// <summary>
    /// Attribute which can be used to ignore every property when building models.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class ImplementAllPropertyTypesAttribute : Attribute
    {
    }
}
