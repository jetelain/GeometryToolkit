namespace Pmad.Geometry.Algorithms
{
    public interface IPathFollower<TPrimitive, TVector>
        where TPrimitive : unmanaged
        where TVector : struct, IVector2<TPrimitive, TVector>, IVectorFP<TPrimitive, TVector>
    {
        TVector Current { get; }

        TVector Previous { get; }

        TVector Vector { get; }

        bool IsLast { get; }

        bool IsFirst { get; }

        void Reset();

        bool Move(TPrimitive step);
    }
}
