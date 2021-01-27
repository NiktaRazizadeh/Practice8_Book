using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice8_Book.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookCategory> BookCategoriesList { get; set; }
    }
}
