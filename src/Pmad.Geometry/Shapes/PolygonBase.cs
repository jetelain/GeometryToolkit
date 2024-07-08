using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pmad.Geometry.Shapes
{
    public abstract class PolygonBase<TPrimitive, TVector>
        where TPrimitive : unmanaged
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        public PolygonBase(IReadOnlyList<TVector> shell, IReadOnlyList<IReadOnlyList<TVector>> holes)
        {
            this.Shell = shell;
            this.Holes = holes;
            Bounds = VectorEnvelope<TVector>.FromList(shell);
        }

        public IReadOnlyList<TVector> Shell { get; }

        public IReadOnlyList<IReadOnlyList<TVector>> Holes { get; }

        public VectorEnvelope<TVector> Bounds { get; }

    }
}
