using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Json.Serialization
{
    public sealed class JsonGeometryConverterFactory : JsonConverterFactory
    {
        private static readonly Dictionary<Type, Type> genericMapping = new (){
            {typeof(Coordinates<,>),      typeof(JsonCoordinatesConverter<,>)},
            {typeof(Polygon<,>),          typeof(JsonPolygonConverter<,>)},
            {typeof(MultiPolygon<,>),     typeof(JsonMultiPolygonConverter<,>)},
            {typeof(Path<,>),             typeof(JsonPathConverter<,>)},
            {typeof(Circle<,>),           typeof(JsonCircleConverter<,>)},
            {typeof(RotatedRectangle<,>), typeof(JsonRotatedRectangleConverter<,>)},
            {typeof(MultiPath<,>),        typeof(JsonMultiPathConverter<,>)}
        };


        public override bool CanConvert(Type typeToConvert)
        {
            if (typeToConvert.IsGenericType)
            {
                return genericMapping.ContainsKey(typeToConvert.GetGenericTypeDefinition());
            }
            if (typeToConvert.IsValueType)
            {
                return GetVector2(typeToConvert) != null;
            }
            return false;
        }

        private static Type? GetVector2(Type typeToConvert)
        {
            return typeToConvert.GetInterfaces().FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IVector2<,>));
        }

        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            return CreateConverter(typeToConvert);
        }

        internal static JsonConverter? CreateConverter(Type typeToConvert)
        {
            if (typeToConvert.IsGenericType)
            {
                if (genericMapping.TryGetValue(typeToConvert.GetGenericTypeDefinition(), out var convertType))
                {
                    return (JsonConverter)Activator.CreateInstance(convertType.MakeGenericType(typeToConvert.GetGenericArguments()))!;
                }
            }
            else if (typeToConvert.IsValueType)
            {
                var vector2 = GetVector2(typeToConvert);
                if (vector2 != null)
                {
                    return (JsonConverter)Activator.CreateInstance(typeof(JsonVectorConverter<,>).MakeGenericType(vector2.GetGenericArguments()))!;
                }
            }
            return null;
        }
    }
}
