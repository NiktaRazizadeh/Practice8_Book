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
    public class CategoryController : ControllerBase
    {
        private readonly IRepasitory<Category> repasitory;
        public CategoryController(IRepasitory<Category> repasitory)
        {
            this.repasitory = repasitory;
        }
        [HttpPost]
        public void Create(Category category)
        {
            repasitory.Insert(category);
            repasitory.Save();
        }
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return repasitory.Get(id);
        }
        [HttpGet]
        public List<Category> GetAll()
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
        public Category Update(Category category)
        {
            var end = repasitory.Update(category);
            repasitory.Save();
            return end;

        }
    }
}
