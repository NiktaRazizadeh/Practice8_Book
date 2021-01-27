using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice8_Book.Models
{
    public class Publications
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<Book> BookList { get; set; }
    }
}
