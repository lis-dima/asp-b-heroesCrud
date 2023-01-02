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
        public async Task GetComics()
        {
            var res = await http.GetFromJsonAsync<List<Comic>>("api/superhero/comics");
            if (res != null) Comics = res;
        }

        public async Task<SuperHero> GetSingleHero(int id)
        {
            var res = await http.GetFromJsonAsync<SuperHero>($"api/superhero/{id}");
            if (res != null) return res;
            throw new Exception("Not found");
        }

        public async Task GetSuperHeroes()
        {
            var res = await http.GetFromJsonAsync<List<SuperHero>>("api/superhero");
            if(res != null) Heroes = res;
        }
    }
}
