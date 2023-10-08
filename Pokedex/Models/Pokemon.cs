using System.Collections.Generic;

namespace Pokedex.Models;

public class Pokemon
{
    public int Id {  get; set; }
    public string Name { get; set; }
    public int Weight { get; set; }
    public int Height { get; set; }
    public Sprites Sprites { get; set; }
    public List<Stat> Stats { get; set; }
    public List<Type> Types { get; set; }

}
