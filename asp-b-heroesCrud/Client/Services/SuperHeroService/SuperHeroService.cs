using asp_b_heroesCrud.Client.Pages;
using asp_b_heroesCrud.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace asp_b_heroesCrud.Client.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly HttpClient http;
        private readonly NavigationManager navigationManager;

        public List<SuperHero> Heroes { get; set; } = new List<SuperHero>();
        public List<Comic> Comics { get; set; } = new List<Comic>();

        public SuperHeroService(HttpClient http, NavigationManager navigationManager)
        {
            this.http = http;
            this.navigationManager = navigationManager;
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
            if (res != null) Heroes = res;
        }

        public async Task CreateHero(SuperHero hero)
        {
            var res = await http.PostAsJsonAsync("api/superhero", hero);
            Heroes = await res.Content.ReadFromJsonAsync<List<SuperHero>>();
            navigationManager.NavigateTo("superheroes");
        }

        public async Task UpdateHero(SuperHero hero)
        {
            var res = await http.PutAsJsonAsync($"api/superhero/{hero.Id}", hero);
            Heroes = await res.Content.ReadFromJsonAsync<List<SuperHero>>();
            navigationManager.NavigateTo("superheroes");
        }

        public async Task DeleteHero(int id)
        {
            var res = await http.DeleteAsync($"api/superhero/{id}");
            Heroes = await res.Content.ReadFromJsonAsync<List<SuperHero>>();
            navigationManager.NavigateTo("superheroes");
        }
    }
}
