using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Pmad.Geometry.Collections
{
    /// <summary>
    /// Thin wrapper above an array to ensure it's immutability.
    /// 
    /// Provide access with a ReadOnlySpan to acheive memory-aligned operations. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DebuggerDisplay("Count = {Count}")]
    public struct ReadOnlyArray<T> : IReadOnlyList<T>
    {
        private readonly T[] array;
        private readonly int length;

        public static ReadOnlyArray<T> Empty() => new ReadOnlyArray<T>(Array.Empty<T>());

        public readonly T this[int index] 
        { 
            get 
            {
                if ((uint)index >= (uint)length)
                {
                    ThrowHelper.ThrowIndexOutOfRangeException();
                }
                return array[index]; 
            } 
        }

        public readonly int Count => length;

        public ReadOnlyArray(params T[] array)
        {
            this.array = array;
            this.length = array.Length;
        }

        public ReadOnlyArray(T[] array, int length)
        {
            this.array = array;
            this.length = Math.Min(length, array.Length);
        }

        readonly IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new Enumerator(this);
        }

        readonly IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly ReadOnlySpan<T> AsSpan() => new ReadOnlySpan<T>(array, 0, length);

        public readonly ReadOnlySpan<T>.Enumerator GetEnumerator() => AsSpan().GetEnumerator();

        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < length; i++)
            {
                action(array[i]);
            }
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(this.array, 0, array, arrayIndex, length);
        }

        public ReadOnlyArray<T> ToReverse()
        {
            var result = new T[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = array[length-1-i];
            }
            return new (result);
        }

        private class Enumerator : IEnumerator<T>
        {
            private readonly T[] array;
            private readonly int length;
            private int index;

            internal Enumerator(ReadOnlyArray<T> arraySegment)
            {
                array = arraySegment.array;
                length = arraySegment.length;
                index = -1;
            }

            public bool MoveNext()
            {
                int index = this.index + 1;
                if (index < length)
                {
                    this.index = index;
                    return true;
                }
                return false;
            }

            public T Current => array[index];

            object? IEnumerator.Current => Current;

            void IEnumerator.Reset()
            {
                index = -1;
            }

            public void Dispose()
            {
            }
        }
    }
}
