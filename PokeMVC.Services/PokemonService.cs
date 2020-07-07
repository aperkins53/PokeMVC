using PokeMVC.Data;
using PokeMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeMVC.Services
{
    public class PokemonService
    {
        public bool CreatePokemon(PokemonCreate pokemon)
        {
            var pokemonToAdd = 
                new Pokemon()
                {
                    PokedexNumber = pokemon.PokedexNumber,
                    Species = pokemon.Species,
                    PrimaryType = pokemon.PrimaryType,
                    SecondaryType = pokemon.SecondaryType,
                    EvoCondition = pokemon.EvoCondition,
                    OriginalRegion = pokemon.OriginalRegion,
                    IsLegendary = pokemon.IsLegendary,
                    IsMythical = pokemon.IsMythical
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.AllPokemon.Add(pokemonToAdd);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PokemonListItem> GetAllPokemon()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var allPokemon = 
                    ctx
                        .AllPokemon
                        .Select(
                            p => 
                                new PokemonListItem
                                {
                                    PokemonId = p.PokemonId,
                                    PokedexNumber = p.PokedexNumber,
                                    Species = p.Species,
                                    PrimaryType = p.PrimaryType,
                                    SecondaryType = p.SecondaryType,
                                    EvoCondition = p.EvoCondition,
                                    OriginalRegion = p.OriginalRegion,
                                    IsLegendary = p.IsLegendary,
                                    IsMythical = p.IsMythical
                                });

                return allPokemon.ToArray();
            }
        }

        public PokemonDetail GetPokemonById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var pokemon = 
                    ctx
                        .AllPokemon
                        .Single(p => p.PokemonId == id);
                return
                    new PokemonDetail
                    {
                        PokemonId = pokemon.PokemonId,
                        PokedexNumber = pokemon.PokedexNumber,
                        Species = pokemon.Species,
                        PrimaryType = pokemon.PrimaryType,
                        SecondaryType = pokemon.SecondaryType,
                        EvoCondition = pokemon.EvoCondition,
                        OriginalRegion = pokemon.OriginalRegion,
                        IsLegendary = pokemon.IsLegendary,
                        IsMythical = pokemon.IsMythical
                    };
            }
        }

        public bool UpdatePokemon(PokemonEdit pokemon)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var pokemonToUpdate = 
                    ctx
                        .AllPokemon
                        .Single(p => p.PokemonId == pokemon.PokemonId);

                pokemonToUpdate.PokedexNumber = pokemon.PokedexNumber;
                pokemonToUpdate.Species = pokemon.Species;
                pokemonToUpdate.PrimaryType = pokemon.PrimaryType;
                pokemonToUpdate.SecondaryType = pokemon.SecondaryType;
                pokemonToUpdate.EvoCondition = pokemon.EvoCondition;
                pokemonToUpdate.OriginalRegion = pokemon.OriginalRegion;
                pokemonToUpdate.IsLegendary = pokemon.IsLegendary;
                pokemonToUpdate.IsMythical = pokemon.IsMythical;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePokemon(int pokemonId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var pokemonToDelete =
                    ctx
                        .AllPokemon
                        .Single(p => p.PokemonId == pokemonId);

                ctx.AllPokemon.Remove(pokemonToDelete);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
