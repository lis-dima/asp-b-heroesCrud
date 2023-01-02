using asp_b_heroesCrud.Shared;
using Microsoft.AspNetCore.Mvc;

namespace asp_b_heroesCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        public static List<Comic> comics = new List<Comic> {
            new Comic {Id = 1, Name = "Marvel"},
            new Comic {Id = 2, Name = "DC"}
        };

        public static List<SuperHero> superHeroes = new List<SuperHero>
        {
            new SuperHero {Id = 1, FirstName = "Peter", LastName = "Parker", HeroName="SpiderM@n" },
            new SuperHero {Id = 2, FirstName = "Bruce", LastName = "Wayne", HeroName="B@tm@n" },
        };

    }
}
