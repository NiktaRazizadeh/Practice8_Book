using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice8_Book.Models
{
    public class Book : IHasidentity
    {
        public int Id { get; set; }
        public string Titele { get; set; }
        public DateTime PublishDate { get; set; }
        public string Publisher { get; set; }
        public string ISBN { get; set; }
        public int IdPublications { get; set; }
        public Publications Publications { get; set; }
        public List<BookCategory> BookCategoriesList { get; set; }
        public List<BookAuthor> BookAuthorsList { get; set; }
    }
}
