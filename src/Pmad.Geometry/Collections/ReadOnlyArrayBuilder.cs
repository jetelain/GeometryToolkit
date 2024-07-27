using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Pmad.Geometry.Collections
{
    /// <summary>
    /// Grow-only list that can create a snapshot as a <see cref="ReadOnlyArray{T}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DebuggerDisplay("Count = {Count}")]
    public class ReadOnlyArrayBuilder<T> : IReadOnlyCollection<T>, ICollection<T>
    {
        private T[] array;
        private int length;
        private bool arrayIsUsed;

        public ReadOnlyArrayBuilder()
            : this(4)
        {

        }

        public ReadOnlyArrayBuilder(int capacity)
        {
            array = new T[capacity];
        }

        public int Count => length;

        bool ICollection<T>.IsReadOnly => false;

        public T this[int index]
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

        /// <summary>
        /// Add an item at the end of the list
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            var newLength = length + 1;
            EnsureCapacity(newLength);
            array[length] = item;
            length = newLength;
        }

        /// <summary>
        /// Add an item at the end of the list
        /// </summary>
        /// <param name="item"></param>
        public void Prepend(T item)
        {
            var newLength = length + 1;
            if (newLength > array.Length)
            {
                Prepend(item, new T[GetNewSize(newLength)]);
            }
            else if (arrayIsUsed)
            {
                Prepend(item, new T[array.Length]);
            }
            else
            {
                Array.Copy(array, 0, array, 1, length);
                array[0] = item;
            }
            length = newLength;
        }

        private void Prepend(T item, T[] newArray)
        {
            arrayIsUsed = false;
            Array.Copy(array, 0, newArray, 1, length);
            newArray[0] = item;
            array = newArray;
        }

        /// <summary>
        /// Add items at the end of the list
        /// </summary>
        /// <param name="collection">Items to add</param>
        public void AddRange(ICollection<T> collection)
        {
            var newLength = length + collection.Count;
            EnsureCapacity(newLength);
            collection.CopyTo(array, length);
            length = newLength;
        }

        /// <summary>
        /// Add items at the end of the list
        /// </summary>
        /// <param name="collection">Items to add</param>
        public void AddRange(IEnumerable<T> list)
        {
            if (list is ICollection<T> collection)
            {
                AddRange(collection);
            }
            else
            {
                foreach(var item in list)
                {
                    Add(item);
                }
            }
        }

        /// <summary>
        /// Add items at the end of the list
        /// </summary>
        /// <param name="list">Items to add</param>
        public void AddRange(ReadOnlyArray<T> list)
        {
            var newLength = length + list.Count;
            EnsureCapacity(newLength);
            list.CopyTo(array, length);
            length = newLength;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ReadOnlySpan<T> AsSpan() => new ReadOnlySpan<T>(array, 0, length);

        public void EnsureCapacity(int requested)
        {
            if (requested > array.Length)
            {
                Array.Resize(ref array, GetNewSize(requested));
            }
        }

        private int GetNewSize(int requested)
        {
            var newSize = array.Length * 2;
            while (requested > newSize)
            {
                newSize = newSize * 2;
            }
            return newSize;
        }

        /// <summary>
        /// Create a snapshot
        /// </summary>
        /// <returns></returns>
        public ReadOnlyArray<T> Build()
        {
            arrayIsUsed = true;
            return new ReadOnlyArray<T>(array, length);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => ((IEnumerable<T>)Build()).GetEnumerator();
       
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)Build()).GetEnumerator();

        void ICollection<T>.Clear()
        {
            array = new T[4];
            length = 0;
        }

        bool ICollection<T>.Contains(T item)
        {
            return Array.IndexOf(array, item, 0, length) != -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(this.array, 0, array, arrayIndex, length);
        }

        bool ICollection<T>.Remove(T item)
        {
            throw new NotSupportedException();
        }
    }
}
