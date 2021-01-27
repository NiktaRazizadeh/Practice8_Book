using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice8_Book.Repasitory
{
    public interface IRepasitory<T>
    {
        T Get(int id);
        List<T> GetAll();
        void Insert(T item);
        T Update(T item);
        void Delete(int id);
        void Save();
    }
}
