using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice8_Book.Models
{
    public class BookCategory : IHasidentity
    {
        public int Id { get; set; }
        public int IdBook { get; set; }
        public int IdCategory { get; set; }
        public Book Book { get; set; }
        public Category Category { get; set; }
       

    }
}
