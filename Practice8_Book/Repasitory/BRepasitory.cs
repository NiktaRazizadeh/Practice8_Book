using Practice8_Book.DataBase;
using Practice8_Book.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice8_Book.Repasitory
{
    public class BRepasitory<T> : IRepasitory<T> where T :class , IHasidentity
    {
        private readonly AppBookContext dBContext;

        public BRepasitory(AppBookContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public void Delete(int id)
        {
            var item = this.dBContext.Set<T>().FirstOrDefault(x => x.Id == id);
            this.dBContext.Remove(item);

        }

        public T Get(int id)
        {
            return this.dBContext.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public List<T> GetAll()
        {
            return this.dBContext.Set<T>().ToList();
        }

        public void Insert(T item)
        {
            this.dBContext.Add<T>(item);
        }

        public T Update(T item)
        {
            this.dBContext.Update(item);
            return item;
        }
        public void Save()
        {
            this.dBContext.SaveChanges();
        }
    }
}
