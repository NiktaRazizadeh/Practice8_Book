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
        public BookCategoryController(IRepasitory<BookCategory> repasitory)
        {
            this.repasitory = repasitory;
        }
        [HttpPost]
        public string Register(BookCategory bookcat)
        {
            repasitory.Insert(bookcat);
            repasitory.Save();
            return bookcat.Id + " register...";
        }
        [HttpDelete]
        public string Un_Register(int id)
        {
            repasitory.Delete(id);
            repasitory.Save();
            return $"the BookCategory with id :{id} deleted...";
        }
    }
}
