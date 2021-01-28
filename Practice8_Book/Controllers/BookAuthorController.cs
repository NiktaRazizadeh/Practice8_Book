using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice8_Book.Models;
using Practice8_Book.Repasitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice8_Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAuthorController : ControllerBase
    {
        private readonly IRepasitory<BookAuthor> repasitory;
        private readonly IRepasitory<Book> b_repository;
        private readonly IRepasitory<Author> a_repository;
        public BookAuthorController(IRepasitory<BookAuthor> repasitory)
        {
            this.repasitory = repasitory;
            this.a_repository = a_repository;
            this.b_repository = b_repository;
        }
        [HttpPost]
        public string Register(BookAuthor bookAuthor)
        {
            var testbook = b_repository.GetAll().Where(ab => ab.Id == bookAuthor.IdBook).ToList().Count;
            var testauthor = a_repository.GetAll().Where(ab => ab.Id == bookAuthor.IdAuthor).ToList().Count;

            if (testauthor == 0)
                return "Not Found any author with this id";
            if (testbook == 0)
                return "Not Found any book with this id";

            repasitory.Insert(bookAuthor);
            repasitory.Save();
            return bookAuthor.Id + " register...";
        }
        [HttpDelete("{id}")]
        public string Un_Register(int id)
        {
            if (repasitory.GetAll().Where(ab => ab.Id == id).ToList().Count != 0)
            {
                repasitory.Delete(id);
                repasitory.Save();
                return $"the author_book with id :{id} is deleted...";
            }
            return "Not Found any author-book to un-register";
        }
        [HttpGet]
        public List<BookAuthor> GetAll()
        {
            return repasitory.GetAll();
        }
    }
}
