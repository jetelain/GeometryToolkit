namespace Pmad.Geometry.Json.Serialization
{
    internal interface IArrayBuilder
    {
        void Add(object value);

        object Build();
    }
}