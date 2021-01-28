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
        public string Create(Category category)
        {
            var result = repasitory.Insert(category);
            repasitory.Save();
            return category.Id + result;
        }
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            if (repasitory.GetAll().Where(c => c.Id == id).ToList().Count != 0)
                return repasitory.Get(id);
            return null;
        }
        [HttpGet]
        public List<Category> GetAll()
        {
            return repasitory.GetAll();
        }
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            if (repasitory.GetAll().Where(c => c.Id == id).ToList().Count != 0)
            {
                try
                {
                    var result = repasitory.Delete(id);
                    repasitory.Save();
                    return result;
                }
                catch
                {
                    return "There is a dependency for this category in Book-Category table ....";
                }
            }
            return "Not found any category with this id for delete";
        }
        [HttpPut]
        public string Update(Category category)
        {
            try
            {
                var end = repasitory.Update(category);
                repasitory.Save();
                return end;
            }
            catch (Exception)
            {
                return " Not found any category with this id for update";
            }

        }
    }
}
