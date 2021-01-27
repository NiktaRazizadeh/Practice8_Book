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
        public BookAuthorController(IRepasitory<BookAuthor> repasitory)
        {
            this.repasitory = repasitory;
        }
        [HttpPost]
        public string Register(BookAuthor bookAuthor)
        {
            repasitory.Insert(bookAuthor);
            repasitory.Save();
            return bookAuthor.Id + " register...";
        }
        [HttpDelete]
        public string Un_Register(int id)
        {
            repasitory.Delete(id);
            repasitory.Save();
            return $"the book author with id :{id} is deleted...";
        }
    }
}
