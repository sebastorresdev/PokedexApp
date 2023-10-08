using Newtonsoft.Json;
using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Util;

public class PokeClient
{
    public HttpClient Client { get; set; }
    
    public PokeClient()
    {
        Client = new HttpClient();
    }

    public PokeClient(HttpClient client)
    {
        Client = client;
    }

    public async Task<Pokemon> GetPokemon(string id)
    {
        var response = await Client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{id}");
        var content = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<Pokemon>(content);
    }
}
