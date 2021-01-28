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
        public string Create(Author author)
        {
            var result = repasitory.Insert(author);
            repasitory.Save();
            return author.Id + result;
        }
        [HttpGet("{id}")]
        public Author Get(int id)
        {
            if(repasitory.GetAll().Where(a => a.Id == id).ToList().Count != 0)
                return repasitory.Get(id);
            return null;
        }
        [HttpGet]
        public List<Author> GetAll()
        {
            return repasitory.GetAll();
        }
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            if (repasitory.GetAll().Where(a => a.Id == id).ToList().Count != 0)
            {
                try
                {
                    var result = repasitory.Delete(id);
                    repasitory.Save();
                    return result;
                }
                catch
                {
                    return "There is a dependency for this author in Author-Book table ....";

                }
            }
            return "Not found any author with this id for delete";
        }
        [HttpPut]
        public string Update(Author author)
        {
            try
            {
                var end = repasitory.Update(author);
                repasitory.Save();
                return end;
            }
            catch (Exception)
            {
                return " Not found any author with this id for update";
            }
        }
    }
}
