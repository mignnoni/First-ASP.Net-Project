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
    public class BattleController : ControllerBase
    {
        private readonly IEFCoreRepository _repo;

        public BattleController(IEFCoreRepository repo)
        {
            _repo = repo;
        }
        // GET: api/<BattleController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var battles = await _repo.GetAllBattles();
                return Ok(battles);
            }
            catch (Exception e)
            {

                return BadRequest($"Erro: {e}");
            }
        }

        // GET api/<BattleController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Battle battle = await _repo.GetBattleById(id);

            return Ok(battle);
        }

        // POST api/<BattleController>
        [HttpPost]
        public async Task<IActionResult> Post(Battle battle)
        {
            try
            {
                _repo.Add(battle);
                if (await _repo.SaveChangeAsync())
                {
                    return Ok("Success");
                }
                return Ok("Not saved");



            }
            catch (Exception e)
            {

                return BadRequest($"Erro: {e}");
            }
        }

        // PUT api/<BattleController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Battle battle)
        {
            try
            {
                Battle getBattle = await _repo.GetBattleById(id);
                if (getBattle != null)
                {
                    _repo.Update(battle);

                    if (await _repo.SaveChangeAsync())
                        return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Not updated!");
        }

        // DELETE api/<BattleController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Battle getBattle = await _repo.GetBattleById(id);
                if (getBattle != null)
                {
                    _repo.Delete(getBattle);

                    if (await _repo.SaveChangeAsync())
                        return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Not updated!");
        }

    }     
    
}
