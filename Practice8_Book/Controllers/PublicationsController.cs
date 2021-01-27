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
        public void Create(Publications Publications)
        {
            repasitory.Insert(Publications);
            repasitory.Save();
        }
        [HttpGet("{id}")]
        public Publications Get(int id)
        {
            return repasitory.Get(id);
        }
        [HttpGet]
        public List<Publications> GetAll()
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
        public Publications Update(Publications publications)
        {
            var end = repasitory.Update(publications);
            repasitory.Save();
            return end;
        }
    }
}
