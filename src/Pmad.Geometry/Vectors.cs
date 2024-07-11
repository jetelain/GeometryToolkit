using System.Runtime.CompilerServices;

namespace Pmad.Geometry
{
    public static class Vectors
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector Create<TPrimitive,TVector>(TPrimitive x, TPrimitive y)
            where TVector : struct, IVector<TVector>, IVector2<TPrimitive,TVector>
            where TPrimitive : unmanaged
        {
            if (typeof(TVector) == typeof(Vector2I))
            {
                return (TVector)(object)new Vector2I((int)(object)x, (int)(object)y);
            }
            if (typeof(TVector) == typeof(Vector2F))
            {
                return (TVector)(object)new Vector2F((float)(object)x, (float)(object)y);
            }
            if (typeof(TVector) == typeof(Vector2L))
            {
                return (TVector)(object)new Vector2L((long)(object)x, (long)(object)y);
            }
            if (typeof(TVector) == typeof(Vector2D))
            {
                return (TVector)(object)new Vector2D((double)(object)x, (double)(object)y);
            }
            if (typeof(TVector) == typeof(Vector2IS))
            {
                return (TVector)(object)new Vector2IS((int)(object)x, (int)(object)y);
            }
            if (typeof(TVector) == typeof(Vector2FS))
            {
                return (TVector)(object)new Vector2FS((float)(object)x, (float)(object)y);
            }
            if (typeof(TVector) == typeof(Vector2LS))
            {
                return (TVector)(object)new Vector2LS((long)(object)x, (long)(object)y);
            }
            if (typeof(TVector) == typeof(Vector2DS))
            {
                return (TVector)(object)new Vector2DS((double)(object)x, (double)(object)y);
            }
            if (typeof(TVector) == typeof(Vector2FN))
            {
                return (TVector)(object)new Vector2FN((float)(object)x, (float)(object)y);
            }
            ThrowHelper.ThrowNotSupportedException();
            return default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector Create<TPrimitive,TVector>(int x, int y)
            where TVector : struct, IVector<TVector>, IVector2<TPrimitive,TVector>
            where TPrimitive : unmanaged
        {
            if (typeof(TVector) == typeof(Vector2I))
            {
                return (TVector)(object)new Vector2I(x, y);
            }
            if (typeof(TVector) == typeof(Vector2F))
            {
                return (TVector)(object)new Vector2F(x, y);
            }
            if (typeof(TVector) == typeof(Vector2L))
            {
                return (TVector)(object)new Vector2L(x, y);
            }
            if (typeof(TVector) == typeof(Vector2D))
            {
                return (TVector)(object)new Vector2D(x, y);
            }
            if (typeof(TVector) == typeof(Vector2IS))
            {
                return (TVector)(object)new Vector2IS(x, y);
            }
            if (typeof(TVector) == typeof(Vector2FS))
            {
                return (TVector)(object)new Vector2FS(x, y);
            }
            if (typeof(TVector) == typeof(Vector2LS))
            {
                return (TVector)(object)new Vector2LS(x, y);
            }
            if (typeof(TVector) == typeof(Vector2DS))
            {
                return (TVector)(object)new Vector2DS(x, y);
            }
            if (typeof(TVector) == typeof(Vector2FN))
            {
                return (TVector)(object)new Vector2FN(x, y);
            }
            ThrowHelper.ThrowNotSupportedException();
            return default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector Create<TPrimitive,TVector>(long x, long y)
            where TVector : struct, IVector<TVector>, IVector2<TPrimitive,TVector>
            where TPrimitive : unmanaged
        {
            if (typeof(TVector) == typeof(Vector2I))
            {
                return (TVector)(object)new Vector2I((int)x, (int)y);
            }
            if (typeof(TVector) == typeof(Vector2F))
            {
                return (TVector)(object)new Vector2F((float)x, (float)y);
            }
            if (typeof(TVector) == typeof(Vector2L))
            {
                return (TVector)(object)new Vector2L((long)x, (long)y);
            }
            if (typeof(TVector) == typeof(Vector2D))
            {
                return (TVector)(object)new Vector2D((double)x, (double)y);
            }
            if (typeof(TVector) == typeof(Vector2IS))
            {
                return (TVector)(object)new Vector2IS((int)x, (int)y);
            }
            if (typeof(TVector) == typeof(Vector2FS))
            {
                return (TVector)(object)new Vector2FS((float)x, (float)y);
            }
            if (typeof(TVector) == typeof(Vector2LS))
            {
                return (TVector)(object)new Vector2LS((long)x, (long)y);
            }
            if (typeof(TVector) == typeof(Vector2DS))
            {
                return (TVector)(object)new Vector2DS((double)x, (double)y);
            }
            if (typeof(TVector) == typeof(Vector2FN))
            {
                return (TVector)(object)new Vector2FN((float)x, (float)y);
            }
            ThrowHelper.ThrowNotSupportedException();
            return default;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector Add<TVector>(TVector left, TVector right)
            where TVector : struct, IVector<TVector>
        {
            if (typeof(TVector) == typeof(Vector2I))
            {
                return (TVector)(object)(((Vector2I)(object)left) + ((Vector2I)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2F))
            {
                return (TVector)(object)(((Vector2F)(object)left) + ((Vector2F)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2L))
            {
                return (TVector)(object)(((Vector2L)(object)left) + ((Vector2L)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2D))
            {
                return (TVector)(object)(((Vector2D)(object)left) + ((Vector2D)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2IS))
            {
                return (TVector)(object)(((Vector2IS)(object)left) + ((Vector2IS)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2FS))
            {
                return (TVector)(object)(((Vector2FS)(object)left) + ((Vector2FS)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2LS))
            {
                return (TVector)(object)(((Vector2LS)(object)left) + ((Vector2LS)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2DS))
            {
                return (TVector)(object)(((Vector2DS)(object)left) + ((Vector2DS)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2FN))
            {
                return (TVector)(object)(((Vector2FN)(object)left) + ((Vector2FN)(object)right));
            }
            ThrowHelper.ThrowNotSupportedException();
            return default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector Substract<TVector>(TVector left, TVector right)
            where TVector : struct, IVector<TVector>
        {
            if (typeof(TVector) == typeof(Vector2I))
            {
                return (TVector)(object)(((Vector2I)(object)left) - ((Vector2I)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2F))
            {
                return (TVector)(object)(((Vector2F)(object)left) - ((Vector2F)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2L))
            {
                return (TVector)(object)(((Vector2L)(object)left) - ((Vector2L)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2D))
            {
                return (TVector)(object)(((Vector2D)(object)left) - ((Vector2D)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2IS))
            {
                return (TVector)(object)(((Vector2IS)(object)left) - ((Vector2IS)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2FS))
            {
                return (TVector)(object)(((Vector2FS)(object)left) - ((Vector2FS)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2LS))
            {
                return (TVector)(object)(((Vector2LS)(object)left) - ((Vector2LS)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2DS))
            {
                return (TVector)(object)(((Vector2DS)(object)left) - ((Vector2DS)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2FN))
            {
                return (TVector)(object)(((Vector2FN)(object)left) - ((Vector2FN)(object)right));
            }
            ThrowHelper.ThrowNotSupportedException();
            return default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector Divide<TVector>(TVector left, TVector right)
            where TVector : struct, IVector<TVector>
        {
            if (typeof(TVector) == typeof(Vector2I))
            {
                return (TVector)(object)(((Vector2I)(object)left) / ((Vector2I)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2F))
            {
                return (TVector)(object)(((Vector2F)(object)left) / ((Vector2F)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2L))
            {
                return (TVector)(object)(((Vector2L)(object)left) / ((Vector2L)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2D))
            {
                return (TVector)(object)(((Vector2D)(object)left) / ((Vector2D)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2IS))
            {
                return (TVector)(object)(((Vector2IS)(object)left) / ((Vector2IS)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2FS))
            {
                return (TVector)(object)(((Vector2FS)(object)left) / ((Vector2FS)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2LS))
            {
                return (TVector)(object)(((Vector2LS)(object)left) / ((Vector2LS)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2DS))
            {
                return (TVector)(object)(((Vector2DS)(object)left) / ((Vector2DS)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2FN))
            {
                return (TVector)(object)(((Vector2FN)(object)left) / ((Vector2FN)(object)right));
            }
            ThrowHelper.ThrowNotSupportedException();
            return default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector Multiply<TVector>(TVector left, TVector right)
            where TVector : struct, IVector<TVector>
        {
            if (typeof(TVector) == typeof(Vector2I))
            {
                return (TVector)(object)(((Vector2I)(object)left) * ((Vector2I)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2F))
            {
                return (TVector)(object)(((Vector2F)(object)left) * ((Vector2F)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2L))
            {
                return (TVector)(object)(((Vector2L)(object)left) * ((Vector2L)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2D))
            {
                return (TVector)(object)(((Vector2D)(object)left) * ((Vector2D)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2IS))
            {
                return (TVector)(object)(((Vector2IS)(object)left) * ((Vector2IS)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2FS))
            {
                return (TVector)(object)(((Vector2FS)(object)left) * ((Vector2FS)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2LS))
            {
                return (TVector)(object)(((Vector2LS)(object)left) * ((Vector2LS)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2DS))
            {
                return (TVector)(object)(((Vector2DS)(object)left) * ((Vector2DS)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2FN))
            {
                return (TVector)(object)(((Vector2FN)(object)left) * ((Vector2FN)(object)right));
            }
            ThrowHelper.ThrowNotSupportedException();
            return default;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals<TVector>(TVector left, TVector right)
            where TVector : struct, IVector<TVector>
        {
            if (typeof(TVector) == typeof(Vector2I))
            {
                return (((Vector2I)(object)left) == ((Vector2I)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2F))
            {
                return (((Vector2F)(object)left) == ((Vector2F)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2L))
            {
                return (((Vector2L)(object)left) == ((Vector2L)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2D))
            {
                return (((Vector2D)(object)left) == ((Vector2D)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2IS))
            {
                return (((Vector2IS)(object)left) == ((Vector2IS)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2FS))
            {
                return (((Vector2FS)(object)left) == ((Vector2FS)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2LS))
            {
                return (((Vector2LS)(object)left) == ((Vector2LS)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2DS))
            {
                return (((Vector2DS)(object)left) == ((Vector2DS)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2FN))
            {
                return (((Vector2FN)(object)left) == ((Vector2FN)(object)right));
            }
            ThrowHelper.ThrowNotSupportedException();
            return default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotEquals<TVector>(TVector left, TVector right)
            where TVector : struct, IVector<TVector>
        {
            if (typeof(TVector) == typeof(Vector2I))
            {
                return (((Vector2I)(object)left) != ((Vector2I)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2F))
            {
                return (((Vector2F)(object)left) != ((Vector2F)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2L))
            {
                return (((Vector2L)(object)left) != ((Vector2L)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2D))
            {
                return (((Vector2D)(object)left) != ((Vector2D)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2IS))
            {
                return (((Vector2IS)(object)left) != ((Vector2IS)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2FS))
            {
                return (((Vector2FS)(object)left) != ((Vector2FS)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2LS))
            {
                return (((Vector2LS)(object)left) != ((Vector2LS)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2DS))
            {
                return (((Vector2DS)(object)left) != ((Vector2DS)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2FN))
            {
                return (((Vector2FN)(object)left) != ((Vector2FN)(object)right));
            }
            ThrowHelper.ThrowNotSupportedException();
            return default;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector Divide<TVector,TPrimitive>(TVector left, TPrimitive right)
            where TVector : struct, IVector<TVector>, IVector2<TPrimitive,TVector>
            where TPrimitive : unmanaged
        {
            if (typeof(TVector) == typeof(Vector2I))
            {
                return (TVector)(object)(((Vector2I)(object)left) / ((int)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2F))
            {
                return (TVector)(object)(((Vector2F)(object)left) / ((float)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2L))
            {
                return (TVector)(object)(((Vector2L)(object)left) / ((long)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2D))
            {
                return (TVector)(object)(((Vector2D)(object)left) / ((double)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2IS))
            {
                return (TVector)(object)(((Vector2IS)(object)left) / ((int)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2FS))
            {
                return (TVector)(object)(((Vector2FS)(object)left) / ((float)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2LS))
            {
                return (TVector)(object)(((Vector2LS)(object)left) / ((long)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2DS))
            {
                return (TVector)(object)(((Vector2DS)(object)left) / ((double)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2FN))
            {
                return (TVector)(object)(((Vector2FN)(object)left) / ((float)(object)right));
            }
            ThrowHelper.ThrowNotSupportedException();
            return default;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector Divide<TVector>(TVector left, int right)
            where TVector : struct, IVector<TVector>
        {
            if (typeof(TVector) == typeof(Vector2I))
            {
                return (TVector)(object)(((Vector2I)(object)left) / right);
            }
            if (typeof(TVector) == typeof(Vector2F))
            {
                return (TVector)(object)(((Vector2F)(object)left) / right);
            }
            if (typeof(TVector) == typeof(Vector2L))
            {
                return (TVector)(object)(((Vector2L)(object)left) / right);
            }
            if (typeof(TVector) == typeof(Vector2D))
            {
                return (TVector)(object)(((Vector2D)(object)left) / right);
            }
            if (typeof(TVector) == typeof(Vector2IS))
            {
                return (TVector)(object)(((Vector2IS)(object)left) / right);
            }
            if (typeof(TVector) == typeof(Vector2FS))
            {
                return (TVector)(object)(((Vector2FS)(object)left) / right);
            }
            if (typeof(TVector) == typeof(Vector2LS))
            {
                return (TVector)(object)(((Vector2LS)(object)left) / right);
            }
            if (typeof(TVector) == typeof(Vector2DS))
            {
                return (TVector)(object)(((Vector2DS)(object)left) / right);
            }
            if (typeof(TVector) == typeof(Vector2FN))
            {
                return (TVector)(object)(((Vector2FN)(object)left) / right);
            }
            ThrowHelper.ThrowNotSupportedException();
            return default;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector Multiply<TVector,TPrimitive>(TVector left, TPrimitive right)
            where TVector : struct, IVector<TVector>, IVector2<TPrimitive,TVector>
            where TPrimitive : unmanaged
        {
            if (typeof(TVector) == typeof(Vector2I))
            {
                return (TVector)(object)(((Vector2I)(object)left) * ((int)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2F))
            {
                return (TVector)(object)(((Vector2F)(object)left) * ((float)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2L))
            {
                return (TVector)(object)(((Vector2L)(object)left) * ((long)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2D))
            {
                return (TVector)(object)(((Vector2D)(object)left) * ((double)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2IS))
            {
                return (TVector)(object)(((Vector2IS)(object)left) * ((int)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2FS))
            {
                return (TVector)(object)(((Vector2FS)(object)left) * ((float)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2LS))
            {
                return (TVector)(object)(((Vector2LS)(object)left) * ((long)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2DS))
            {
                return (TVector)(object)(((Vector2DS)(object)left) * ((double)(object)right));
            }
            if (typeof(TVector) == typeof(Vector2FN))
            {
                return (TVector)(object)(((Vector2FN)(object)left) * ((float)(object)right));
            }
            ThrowHelper.ThrowNotSupportedException();
            return default;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector Multiply<TVector>(TVector left, int right)
            where TVector : struct, IVector<TVector>
        {
            if (typeof(TVector) == typeof(Vector2I))
            {
                return (TVector)(object)(((Vector2I)(object)left) * right);
            }
            if (typeof(TVector) == typeof(Vector2F))
            {
                return (TVector)(object)(((Vector2F)(object)left) * right);
            }
            if (typeof(TVector) == typeof(Vector2L))
            {
                return (TVector)(object)(((Vector2L)(object)left) * right);
            }
            if (typeof(TVector) == typeof(Vector2D))
            {
                return (TVector)(object)(((Vector2D)(object)left) * right);
            }
            if (typeof(TVector) == typeof(Vector2IS))
            {
                return (TVector)(object)(((Vector2IS)(object)left) * right);
            }
            if (typeof(TVector) == typeof(Vector2FS))
            {
                return (TVector)(object)(((Vector2FS)(object)left) * right);
            }
            if (typeof(TVector) == typeof(Vector2LS))
            {
                return (TVector)(object)(((Vector2LS)(object)left) * right);
            }
            if (typeof(TVector) == typeof(Vector2DS))
            {
                return (TVector)(object)(((Vector2DS)(object)left) * right);
            }
            if (typeof(TVector) == typeof(Vector2FN))
            {
                return (TVector)(object)(((Vector2FN)(object)left) * right);
            }
            ThrowHelper.ThrowNotSupportedException();
            return default;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector Min<TVector>(TVector left, TVector right)
            where TVector : struct, IVector<TVector>
        {
            if (typeof(TVector) == typeof(Vector2I))
            {
                return (TVector)(object)Vector2I.Min((Vector2I)(object)left,(Vector2I)(object)right);
            }
            if (typeof(TVector) == typeof(Vector2F))
            {
                return (TVector)(object)Vector2F.Min((Vector2F)(object)left,(Vector2F)(object)right);
            }
            if (typeof(TVector) == typeof(Vector2L))
            {
                return (TVector)(object)Vector2L.Min((Vector2L)(object)left,(Vector2L)(object)right);
            }
            if (typeof(TVector) == typeof(Vector2D))
            {
                return (TVector)(object)Vector2D.Min((Vector2D)(object)left,(Vector2D)(object)right);
            }
            if (typeof(TVector) == typeof(Vector2IS))
            {
                return (TVector)(object)Vector2IS.Min((Vector2IS)(object)left,(Vector2IS)(object)right);
            }
            if (typeof(TVector) == typeof(Vector2FS))
            {
                return (TVector)(object)Vector2FS.Min((Vector2FS)(object)left,(Vector2FS)(object)right);
            }
            if (typeof(TVector) == typeof(Vector2LS))
            {
                return (TVector)(object)Vector2LS.Min((Vector2LS)(object)left,(Vector2LS)(object)right);
            }
            if (typeof(TVector) == typeof(Vector2DS))
            {
                return (TVector)(object)Vector2DS.Min((Vector2DS)(object)left,(Vector2DS)(object)right);
            }
            if (typeof(TVector) == typeof(Vector2FN))
            {
                return (TVector)(object)Vector2FN.Min((Vector2FN)(object)left,(Vector2FN)(object)right);
            }
            ThrowHelper.ThrowNotSupportedException();
            return default;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector Max<TVector>(TVector left, TVector right)
            where TVector : struct, IVector<TVector>
        {
            if (typeof(TVector) == typeof(Vector2I))
            {
                return (TVector)(object)Vector2I.Max((Vector2I)(object)left,(Vector2I)(object)right);
            }
            if (typeof(TVector) == typeof(Vector2F))
            {
                return (TVector)(object)Vector2F.Max((Vector2F)(object)left,(Vector2F)(object)right);
            }
            if (typeof(TVector) == typeof(Vector2L))
            {
                return (TVector)(object)Vector2L.Max((Vector2L)(object)left,(Vector2L)(object)right);
            }
            if (typeof(TVector) == typeof(Vector2D))
            {
                return (TVector)(object)Vector2D.Max((Vector2D)(object)left,(Vector2D)(object)right);
            }
            if (typeof(TVector) == typeof(Vector2IS))
            {
                return (TVector)(object)Vector2IS.Max((Vector2IS)(object)left,(Vector2IS)(object)right);
            }
            if (typeof(TVector) == typeof(Vector2FS))
            {
                return (TVector)(object)Vector2FS.Max((Vector2FS)(object)left,(Vector2FS)(object)right);
            }
            if (typeof(TVector) == typeof(Vector2LS))
            {
                return (TVector)(object)Vector2LS.Max((Vector2LS)(object)left,(Vector2LS)(object)right);
            }
            if (typeof(TVector) == typeof(Vector2DS))
            {
                return (TVector)(object)Vector2DS.Max((Vector2DS)(object)left,(Vector2DS)(object)right);
            }
            if (typeof(TVector) == typeof(Vector2FN))
            {
                return (TVector)(object)Vector2FN.Max((Vector2FN)(object)left,(Vector2FN)(object)right);
            }
            ThrowHelper.ThrowNotSupportedException();
            return default;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector CrossProduct<TVector>(TVector left, TVector right)
            where TVector : struct, IVector<TVector>
        {
            if (typeof(TVector) == typeof(Vector2I))
            {
                return (TVector)(object)Vector2I.CrossProduct((Vector2I)(object)left,(Vector2I)(object)right);
            }
            if (typeof(TVector) == typeof(Vector2F))
            {
                return (TVector)(object)Vector2F.CrossProduct((Vector2F)(object)left,(Vector2F)(object)right);
            }
            if (typeof(TVector) == typeof(Vector2L))
            {
                return (TVector)(object)Vector2L.CrossProduct((Vector2L)(object)left,(Vector2L)(object)right);
            }
            if (typeof(TVector) == typeof(Vector2D))
            {
                return (TVector)(object)Vector2D.CrossProduct((Vector2D)(object)left,(Vector2D)(object)right);
            }
            if (typeof(TVector) == typeof(Vector2IS))
            {
                return (TVector)(object)Vector2IS.CrossProduct((Vector2IS)(object)left,(Vector2IS)(object)right);
            }
            if (typeof(TVector) == typeof(Vector2FS))
            {
                return (TVector)(object)Vector2FS.CrossProduct((Vector2FS)(object)left,(Vector2FS)(object)right);
            }
            if (typeof(TVector) == typeof(Vector2LS))
            {
                return (TVector)(object)Vector2LS.CrossProduct((Vector2LS)(object)left,(Vector2LS)(object)right);
            }
            if (typeof(TVector) == typeof(Vector2DS))
            {
                return (TVector)(object)Vector2DS.CrossProduct((Vector2DS)(object)left,(Vector2DS)(object)right);
            }
            if (typeof(TVector) == typeof(Vector2FN))
            {
                return (TVector)(object)Vector2FN.CrossProduct((Vector2FN)(object)left,(Vector2FN)(object)right);
            }
            ThrowHelper.ThrowNotSupportedException();
            return default;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TPrimitive Dot<TPrimitive,TVector>(TVector left, TVector right)
            where TVector : struct, IVector<TVector>, IVectorFP<TPrimitive,TVector>
            where TPrimitive : unmanaged
        {
            if (typeof(TVector) == typeof(Vector2F))
            {
                return (TPrimitive)(object)Vector2F.Dot((Vector2F)(object)left,(Vector2F)(object)right);
            }
            if (typeof(TVector) == typeof(Vector2D))
            {
                return (TPrimitive)(object)Vector2D.Dot((Vector2D)(object)left,(Vector2D)(object)right);
            }
            if (typeof(TVector) == typeof(Vector2FS))
            {
                return (TPrimitive)(object)Vector2FS.Dot((Vector2FS)(object)left,(Vector2FS)(object)right);
            }
            if (typeof(TVector) == typeof(Vector2DS))
            {
                return (TPrimitive)(object)Vector2DS.Dot((Vector2DS)(object)left,(Vector2DS)(object)right);
            }
            if (typeof(TVector) == typeof(Vector2FN))
            {
                return (TPrimitive)(object)Vector2FN.Dot((Vector2FN)(object)left,(Vector2FN)(object)right);
            }
            ThrowHelper.ThrowNotSupportedException();
            return default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double DotD<TPrimitive,TVector>(TVector left, TVector right)
            where TVector : struct, IVector<TVector>, IVectorFP<TPrimitive,TVector>
            where TPrimitive : unmanaged
        {
            if (typeof(TVector) == typeof(Vector2F))
            {
                return Vector2F.Dot((Vector2F)(object)left,(Vector2F)(object)right);
            }
            if (typeof(TVector) == typeof(Vector2D))
            {
                return Vector2D.Dot((Vector2D)(object)left,(Vector2D)(object)right);
            }
            if (typeof(TVector) == typeof(Vector2FS))
            {
                return Vector2FS.Dot((Vector2FS)(object)left,(Vector2FS)(object)right);
            }
            if (typeof(TVector) == typeof(Vector2DS))
            {
                return Vector2DS.Dot((Vector2DS)(object)left,(Vector2DS)(object)right);
            }
            if (typeof(TVector) == typeof(Vector2FN))
            {
                return Vector2FN.Dot((Vector2FN)(object)left,(Vector2FN)(object)right);
            }
            ThrowHelper.ThrowNotSupportedException();
            return default;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector Lerp<TPrimitive,TVector>(TVector left, TVector right, TPrimitive amount)
            where TVector : struct, IVector<TVector>, IVectorFP<TPrimitive,TVector>
            where TPrimitive : unmanaged
        {
            if (typeof(TVector) == typeof(Vector2F))
            {
                return (TVector)(object)Vector2F.Lerp((Vector2F)(object)left,(Vector2F)(object)right,(float)(object)amount);
            }
            if (typeof(TVector) == typeof(Vector2D))
            {
                return (TVector)(object)Vector2D.Lerp((Vector2D)(object)left,(Vector2D)(object)right,(double)(object)amount);
            }
            if (typeof(TVector) == typeof(Vector2FS))
            {
                return (TVector)(object)Vector2FS.Lerp((Vector2FS)(object)left,(Vector2FS)(object)right,(float)(object)amount);
            }
            if (typeof(TVector) == typeof(Vector2DS))
            {
                return (TVector)(object)Vector2DS.Lerp((Vector2DS)(object)left,(Vector2DS)(object)right,(double)(object)amount);
            }
            if (typeof(TVector) == typeof(Vector2FN))
            {
                return (TVector)(object)Vector2FN.Lerp((Vector2FN)(object)left,(Vector2FN)(object)right,(float)(object)amount);
            }
            ThrowHelper.ThrowNotSupportedException();
            return default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector Lerp<TPrimitive,TVector>(TVector left, TVector right, double amount)
            where TVector : struct, IVector<TVector>, IVectorFP<TPrimitive,TVector>
            where TPrimitive : unmanaged
        {
            if (typeof(TVector) == typeof(Vector2F))
            {
                return (TVector)(object)Vector2F.Lerp((Vector2F)(object)left,(Vector2F)(object)right,(float)amount);
            }
            if (typeof(TVector) == typeof(Vector2D))
            {
                return (TVector)(object)Vector2D.Lerp((Vector2D)(object)left,(Vector2D)(object)right,(double)amount);
            }
            if (typeof(TVector) == typeof(Vector2FS))
            {
                return (TVector)(object)Vector2FS.Lerp((Vector2FS)(object)left,(Vector2FS)(object)right,(float)amount);
            }
            if (typeof(TVector) == typeof(Vector2DS))
            {
                return (TVector)(object)Vector2DS.Lerp((Vector2DS)(object)left,(Vector2DS)(object)right,(double)amount);
            }
            if (typeof(TVector) == typeof(Vector2FN))
            {
                return (TVector)(object)Vector2FN.Lerp((Vector2FN)(object)left,(Vector2FN)(object)right,(float)amount);
            }
            ThrowHelper.ThrowNotSupportedException();
            return default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector Normalize<TPrimitive,TVector>(TVector left)
            where TVector : struct, IVector<TVector>, IVectorFP<TPrimitive,TVector>
            where TPrimitive : unmanaged
        {
            if (typeof(TVector) == typeof(Vector2F))
            {
                return (TVector)(object)Vector2F.Normalize((Vector2F)(object)left);
            }
            if (typeof(TVector) == typeof(Vector2D))
            {
                return (TVector)(object)Vector2D.Normalize((Vector2D)(object)left);
            }
            if (typeof(TVector) == typeof(Vector2FS))
            {
                return (TVector)(object)Vector2FS.Normalize((Vector2FS)(object)left);
            }
            if (typeof(TVector) == typeof(Vector2DS))
            {
                return (TVector)(object)Vector2DS.Normalize((Vector2DS)(object)left);
            }
            if (typeof(TVector) == typeof(Vector2FN))
            {
                return (TVector)(object)Vector2FN.Normalize((Vector2FN)(object)left);
            }
            ThrowHelper.ThrowNotSupportedException();
            return default;
        }

	}

}
