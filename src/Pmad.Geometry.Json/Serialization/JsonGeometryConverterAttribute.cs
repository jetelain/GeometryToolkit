using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Pmad.Geometry.Json.Serialization
{
    public sealed class JsonGeometryConverterAttribute : JsonConverterAttribute
    {
        public override JsonConverter? CreateConverter(Type typeToConvert)
        {
            return JsonGeometryConverterFactory.CreateConverter(typeToConvert);
        }
    }
}