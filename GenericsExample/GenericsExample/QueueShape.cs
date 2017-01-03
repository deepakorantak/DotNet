using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExample
{
    class QueueShape<T> : IBufferShape<T> 
    {
        Queue<T> _queue = new Queue<T>();

        public void add(T shape)
        {
            _queue.Enqueue(shape);  
        }

        public T delete()
        {
            return _queue.Dequeue();
        }

        public bool delete(T shape)
        {
            if (shape.Equals(_queue.Peek()))
            {
                _queue.Dequeue();
                return true;
            }
            else return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _queue)
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
