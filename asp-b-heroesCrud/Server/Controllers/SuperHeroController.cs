using asp_b_heroesCrud.Server.Data;
using asp_b_heroesCrud.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asp_b_heroesCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        public DataContext context { get; }

        public SuperHeroController(DataContext dataContext)
        {
            context = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes()
        {
            return Ok(await context.SuperHeroes.ToListAsync());
        }

        [HttpGet("comics")]
        public async Task<ActionResult<List<SuperHero>>> GetComics()
        {
            return Ok(await context.Comics.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var hero = await context.SuperHeroes
                .Include(h => h.Comic)
                .FirstOrDefaultAsync(h => h.Id == id);
            if (hero == null)
                return NotFound("Sorry :(");
            return Ok(hero);
        }
    }
}
