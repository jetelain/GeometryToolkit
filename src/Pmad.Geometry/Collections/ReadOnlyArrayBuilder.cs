using System.Collections;

namespace Pmad.Geometry.Collections
{
    /// <summary>
    /// Grow-only list that can create a snapshot as a <see cref="ReadOnlyArray{T}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class ReadOnlyArrayBuilder<T> : IReadOnlyCollection<T>, ICollection<T>
    {
        private T[] array;
        private int length;

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

        public void EnsureCapacity(int requested)
        {
            if (requested > array.Length)
            {
                var newSize = array.Length * 2;
                while (requested > newSize)
                {
                    newSize = newSize * 2;
                }
                Array.Resize(ref array, newSize);
            }
        }

        /// <summary>
        /// Create a snapshot
        /// </summary>
        /// <returns></returns>
        public ReadOnlyArray<T> Build()
        {
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
