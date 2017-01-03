using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExample
{
    class ListShape<T> : IBufferShape<T>
    {
        List<T> _list = new List<T>();

        public void add(T shape)
        {
            _list.Add(shape);
        }

        public T delete()
        {
            T element = _list.ElementAt(_list.Count - 1);
            _list.Remove(element);

            return element;
        }

        public bool delete(T shape)
        {
            return _list.Remove(shape);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _list)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
} 
