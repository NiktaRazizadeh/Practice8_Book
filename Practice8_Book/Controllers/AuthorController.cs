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
    public class AuthorController : ControllerBase
    {
        private readonly IRepasitory<Author> repasitory;
        public AuthorController(IRepasitory<Author> repasitory)
        {
            this.repasitory = repasitory;
        }
        [HttpPost]
        public void Create(Author author)
        {
             repasitory.Insert(author);
            repasitory.Save();
        }
        [HttpGet("{id}")]
        public Author Get(int id)
        {
            return repasitory.Get(id);
        }
        [HttpGet]
        public List<Author> GetAll()
        {
            return repasitory.GetAll();
        }
        [HttpDelete]
        public string Delete(int id)
        {
            repasitory.Delete(id);
            repasitory.Save();
            return "delete...";
        }
        [HttpPut]
        public Author Update(Author author)
        {
            var end = repasitory.Update(author);
            repasitory.Save();
            return end;
        }
    }
}
