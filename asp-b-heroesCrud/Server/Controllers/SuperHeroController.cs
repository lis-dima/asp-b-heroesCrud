using asp_b_heroesCrud.Client.Pages;
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
            return Ok(await context.SuperHeroes.Include(h => h.Comic).ToListAsync());
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

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> CreateSuperHero(SuperHero hero)
        {
            hero.Comic = null;
            context.SuperHeroes.Add(hero);
            await context.SaveChangesAsync();

            return Ok(await GetSuperHeroes());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateSuperHero(SuperHero hero, int id)
        {
            var dbHero = await context.SuperHeroes
                .Include(h => h.Comic)
                .FirstOrDefaultAsync();

            if (dbHero == null) return NotFound("Sorry, but not found ;(");

            dbHero.FirstName = hero.FirstName;
            dbHero.LastName = hero.LastName;
            dbHero.HeroName = hero.HeroName;
            dbHero.ComicId = hero.ComicId;

            await context.SaveChangesAsync();
            return Ok(await GetSuperHeroes());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteSuperHero(int id)
        {
            var dbHero = await context.SuperHeroes
                .Include(h => h.Comic)
                .FirstOrDefaultAsync();

            if (dbHero == null) return NotFound("Sorry, but not found ;(");

            context.SuperHeroes.Remove(dbHero);
            await context.SaveChangesAsync();
            
            return Ok(await GetSuperHeroes());
        }
    }
}
