using EFCore.Domain1;
using EFCore.Repo1;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly HeroContext _context;
        public ValuesController(HeroContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet("")]
        public ActionResult Get(string name)
        {
            var listHero = _context.Heroes
                .ToList();
            return Ok(listHero);
        }

        // GET api/values/5
        [HttpGet("{heroName}")]
        public ActionResult CreateHero(string heroName)
        {
            var hero = new Hero { Name = heroName };
                _context.Heroes.Add(hero);
                _context.SaveChanges();
            return Ok();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var hero = _context.Heroes
                               .Where(x => x.Id == id)
                               .Single();
            _context.Heroes.Remove(hero);
            _context.SaveChanges();
        }
    }
}
