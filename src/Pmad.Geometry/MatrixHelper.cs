using System.Numerics;
using System.Runtime.CompilerServices;

namespace Pmad.Geometry
{
    internal static class MatrixHelper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static (double Sin, double Cos) SinCosV1(double radians)
        {
            radians = Math.IEEERemainder(radians, Math.PI * 2.0);
            if (radians > -1.7453294E-05 && radians < 1.7453294E-05)
            {
                return (0, 1);
            }
            if (radians > 1.570779 && radians < 1.5708138)
            {
                return (1, 0);
            }
            if (radians < -3.1415753 || radians > 3.1415753)
            {
                return (0, -1);
            }
            if (radians > -1.5708138 && radians < -1.570779)
            {
                return (-1, 0);
            }
            return Math.SinCos(radians);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static (double Sin, double Cos) SinCos(double radians)
        {
            radians = radians % (Math.PI * 2);
            if (radians > Math.PI)
            {
                radians -= Math.PI * 2;
            }
            else if (radians < -Math.PI)
            {
                radians += Math.PI * 2;
            }
            if (radians > -1.7453294E-05 && radians < 1.7453294E-05)
            {
                return (0, 1);
            }
            if (radians > 1.570779 && radians < 1.5708138)
            {
                return (1, 0);
            }
            if (radians < -3.1415753 || radians > 3.1415753)
            {
                return (0, -1);
            }
            if (radians > -1.5708138 && radians < -1.570779)
            {
                return (-1, 0);
            }
            return Math.SinCos(radians);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static (float Sin, float Cos) SinCosV1(float radians)
        {
            radians = MathF.IEEERemainder(radians, MathF.PI * 2f);
            if (radians > -1.7453294E-05f && radians < 1.7453294E-05f)
            {
                return (0, 1);
            }
            if (radians > 1.570779f && radians < 1.5708138f)
            {
                return (1, 0);
            }
            if (radians < -3.1415753f || radians > 3.1415753f)
            {
                return (0, -1);
            }
            if (radians > -1.5708138f && radians < -1.570779f)
            {
                return (-1, 0);
            }
            return MathF.SinCos(radians);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static (float Sin, float Cos) SinCos(float radians)
        {
            radians = radians % (MathF.PI * 2);
            if (radians > MathF.PI)
            {
                radians -= MathF.PI * 2;
            }
            else if (radians < -MathF.PI)
            {
                radians += MathF.PI * 2;
            }
            if (radians > -1.7453294E-05f && radians < 1.7453294E-05f)
            {
                return (0, 1);
            }
            if (radians > 1.570779f && radians < 1.5708138f)
            {
                return (1, 0);
            }
            if (radians < -3.1415753f || radians > 3.1415753f)
            {
                return (0, -1);
            }
            if (radians > -1.5708138f && radians < -1.570779f)
            {
                return (-1, 0);
            }
            return MathF.SinCos(radians);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static (T, T) SinCos<T>(T radians) where T : unmanaged, IFloatingPointIeee754<T>
        {
            if (typeof(T) == typeof(float))
            {
                return ((T, T))(object)SinCos((float)(object)radians);
            }
            if (typeof(T) == typeof(double))
            {
                return ((T, T))(object)SinCos((double)(object)radians);
            }
            ThrowHelper.ThrowNotSupportedException();
            return default;
        }
    }
}
