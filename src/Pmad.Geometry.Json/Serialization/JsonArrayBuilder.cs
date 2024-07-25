using Pmad.Geometry.Collections;

namespace Pmad.Geometry.Json.Serialization
{
    internal class JsonArrayBuilder<T> : ReadOnlyArrayBuilder<T>, IArrayBuilder
    {
        public JsonArrayBuilder(T first)
        {
            base.Add(first);
        }

        public void Add(object value)
        {
            base.Add((T)value);
        }

        object IArrayBuilder.Build()
        {
            return Build();
        }
    }
}