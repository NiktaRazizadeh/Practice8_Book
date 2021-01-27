using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice8_Book.Models
{
    public class Author : IHasidentity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<BookAuthor> BookAuthorsList { get; set; }
    }
}
