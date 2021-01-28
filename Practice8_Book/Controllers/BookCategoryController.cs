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
    public class BookCategoryController : ControllerBase
    {
        private readonly IRepasitory<BookCategory> repasitory;
        private readonly IRepasitory<Category> c_repository;
        private readonly IRepasitory<Book> b_repository;
        public BookCategoryController(IRepasitory<BookCategory> repasitory)
        {
            this.repasitory = repasitory;
            this.c_repository = c_repository;
            this.b_repository = b_repository;
        }
        [HttpPost]
        public string Register(BookCategory bookcat)
        {
            var testbook = b_repository.GetAll().Where(ab => ab.Id == bookcat.IdBook).ToList().Count;
            var testcategory = c_repository.GetAll().Where(ab => ab.Id == bookcat.IdCategory).ToList().Count;

            if (testcategory == 0)
                return "Not Found any author whit this id";
            if (testbook == 0)
                return "Not Found any book whit this id";

            repasitory.Insert(bookcat);
            repasitory.Save();
            return bookcat.Id + " register...";
        }
        [HttpDelete("{id}")]
        public string Un_Register(int id)
        {
            if (repasitory.GetAll().Where(cb => cb.Id == id).ToList().Count != 0)
            {
                repasitory.Delete(id);
                repasitory.Save();
                return $"the category-book with id :{id} is deleted...";
            }
            return "Not Found any cattegory-book to un-register";
        }
        [HttpGet]
        public List<BookCategory> GetAll()
        {
            return repasitory.GetAll();
        }
    }
}
