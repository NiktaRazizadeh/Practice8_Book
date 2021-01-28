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
    public class PublicationsController : ControllerBase
    {
        private readonly IRepasitory<Publications> repasitory;
        public PublicationsController(IRepasitory<Publications> repasitory)
        {
            this.repasitory = repasitory;
        }
        [HttpPost]
        public string Create(Publications Publications)
        {
            var result = repasitory.Insert(Publications);
            repasitory.Save();
            return Publications.Id + result;
        }
        [HttpGet("{id}")]
        public Publications Get(int id)
        {
            if (repasitory.GetAll().Where(p => p.Id == id).ToList().Count != 0)
                return repasitory.Get(id);
            return null;
        }
        [HttpGet]
        public List<Publications> GetAll()
        {
            return repasitory.GetAll();
        }
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            if (repasitory.GetAll().Where(p => p.Id == id).ToList().Count != 0)
            {
                try
                {
                    var result = repasitory.Delete(id);
                    repasitory.Save();
                    return result;
                }
                catch
                {
                    return "There is a dependency for this publication in Book table ....";

                }
            }
            return "Not found any publication with this id for delete";
        }
            [HttpPut]
        public string Update(Publications publications)
        {
            try
            {
                var end = repasitory.Update(publications);
                repasitory.Save();
                return end;
            }
            catch (Exception)
            {
                return " Not found any publication with this id for update";
            }
        }
    }
}
