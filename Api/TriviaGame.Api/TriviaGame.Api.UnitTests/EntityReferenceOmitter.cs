using System.Reflection;
using AutoFixture.Kernel;

namespace TriviaGame.Api.UnitTests;

public class EntityReferenceOmitter : ISpecimenBuilder
{
    private readonly Dictionary<Type, IEnumerable<string>> _typeIndex;

    /// <summary>
    ///     AutoFixture Customization To exclude Entity Framework Reference properties to prevent circular reference errors
    /// </summary>
    public EntityReferenceOmitter(Dictionary<Type, IEnumerable<string>> typeIndex)
    {
        _typeIndex = typeIndex;
    }

    public object Create(object request, ISpecimenContext context)
    {
        var propInfo = request as PropertyInfo;
        if (propInfo != null
            && _typeIndex.TryGetValue(propInfo.DeclaringType, out var names)
            && names.Contains(propInfo.Name))
        {
            return new OmitSpecimen();
        }

        return new NoSpecimen();
    }
}
