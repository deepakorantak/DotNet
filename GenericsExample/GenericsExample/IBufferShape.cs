using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExample
{
    interface IBufferShape<T> : IBufferReadOnlyShape<T>,IBufferWriteOnlyShape<T>
    {
                   
    }

    interface IBufferReadOnlyShape<out T> : IEnumerable<T>
    {
        T delete();
    }

    interface IBufferWriteOnlyShape<in T> 
    {
        void add(T shape);
        bool delete(T shape);
    }
}

