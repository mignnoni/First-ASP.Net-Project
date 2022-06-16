using EFCore.Domain1;
using EFCore.Repo1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly HeroContext _context;
        public HeroController(HeroContext context)
        {
            _context = context;
        }
        // GET: api/<HeroController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var heroes = _context.Heroes.ToList();
                return Ok(heroes);
            }
            catch (Exception e)
            {

                return BadRequest($"Erro: {e}");
            }
        }

        // GET api/<HeroController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok("value");
        }

        // POST api/<HeroController>
        [HttpPost]
        public ActionResult Post(Hero hero)
        {
            try
            {
                _context.Heroes.Add(hero);
                _context.SaveChanges();
                return Ok("Success");
            }
            catch (Exception e)
            {

                return BadRequest($"Erro: {e}");
            }
        }

        // PUT api/<HeroController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Hero hero)
        {
            try
            {
                if(_context.Heroes
                            .AsNoTracking()
                            .FirstOrDefault(h => h.Id == id) != null)
                {
                    hero.Id = id;
                    _context.Update(hero);
                    _context.SaveChanges();
                    return Ok("Success");
                }
                return Ok("Hero not found");

            } catch (Exception e)
            {
                return BadRequest($"Erro: {e}");
            }
        }

        // DELETE api/<HeroController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
