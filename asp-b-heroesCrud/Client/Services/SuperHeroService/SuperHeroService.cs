using asp_b_heroesCrud.Shared;
using System.Net.Http.Json;

namespace asp_b_heroesCrud.Client.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly HttpClient http;

        public List<SuperHero> Heroes { get; set; } = new List<SuperHero>();
        public List<Comic> Comics { get; set; } = new List<Comic>();

        public SuperHeroService(HttpClient http)
        {
            this.http = http;
        }
        public Task GetComics()
        {
            throw new NotImplementedException();
        }

        public Task<SuperHero> GEtSIngleHero(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GetSuperHeroes()
        {
            var res = await http.GetFromJsonAsync<List<SuperHero>>("api/superhero");
            if(res != null) Heroes = res;
        }
    }
}
