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
        public string Delete(int id)
        {
            var item = dBContext.Set<T>().FirstOrDefault(x => x.Id == id);
            if (item == null) return "not found";
            dBContext.Remove(item);
            return item.Id + " delete...";
        }

        public T Get(int id)
        {
            return this.dBContext.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public List<T> GetAll()
        {
            return this.dBContext.Set<T>().ToList();
        }

        public string Insert(T item)
        {
            this.dBContext.Add<T>(item);
            return " added...";
        }

        public string Update(T item)
        {
            this.dBContext.Update(item);
            return item.Id + " updated...";
        }
        public void Save()
        {
            this.dBContext.SaveChanges();
        }
    }
}
