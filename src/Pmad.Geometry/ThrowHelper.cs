
using System.Diagnostics.CodeAnalysis;

namespace Pmad.Geometry
{
    internal static class ThrowHelper
    {
        [DoesNotReturn]
        internal static void ThrowNotSupportedException()
            => throw new NotSupportedException();

        [DoesNotReturn]
        internal static void ThrowNoElementsException()
            => throw new InvalidOperationException("No elements."); 
        
        [DoesNotReturn]
        internal static void ThrowIndexOutOfRangeException()
            => throw new IndexOutOfRangeException();
    }
}