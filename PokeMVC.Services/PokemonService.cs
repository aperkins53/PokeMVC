using PokeMVC.Data;
using PokeMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

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
                    Level = pokemon.Level,
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
                                    Level = p.Level,
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
            List<MoveListItem> _moves = new List<MoveListItem>();

            using (var ctx = new ApplicationDbContext())
            {
                var pokemon = 
                    ctx
                        .AllPokemon
                        .Single(p => p.PokemonId == id);

                foreach (var move in pokemon.Moves)
                {
                    var newMove = new MoveListItem
                    {
                        MoveId = move.MoveId,
                        MoveName = move.Move.MoveName,
                        MovePower = move.Move.MovePower,
                        MoveAccuracy = move.Move.MoveAccuracy,
                        MovePP = move.Move.MovePP,
                        ExtraEffect = move.Move.ExtraEffect
                    };

                    _moves.Add(newMove);
                }

                return
                    new PokemonDetail
                    {
                        PokemonId = pokemon.PokemonId,
                        PokedexNumber = pokemon.PokedexNumber,
                        Species = pokemon.Species,
                        Level = pokemon.Level,
                        PrimaryType = pokemon.PrimaryType,
                        SecondaryType = pokemon.SecondaryType,
                        EvoCondition = pokemon.EvoCondition,
                        OriginalRegion = pokemon.OriginalRegion,
                        IsLegendary = pokemon.IsLegendary,
                        IsMythical = pokemon.IsMythical,
                        Moves = _moves
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
                pokemonToUpdate.Level = pokemon.Level;
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

        public bool AddMoveToPokemon(int pokemonId, int moveId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                //var pokemon =
                //    ctx.AllPokemon.Single(p => p.PokemonId == pokemonId);     // Unnecessary database call

                ////var move =
                ////    ctx.Moves.Single(m => m.MoveId == moveId);              // Unnecessary database call
                var newPokemonMove = new PokemonMove()                          //We only care about the ID's!
                {
                    MoveId = moveId,
                    PokemonId = pokemonId
                };

                ctx.PokemonMoves.Add(newPokemonMove);

                return ctx.SaveChanges() == 1;
            }
        }

        //public bool AddPokemonToUserTeam(int pokemonId)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        Pokemon pokemon = new Pokemon();

        //        var pokemonToAdd =
        //            ctx.AllPokemon.Single(p => p.PokemonId == pokemonId);

        //        pokemon.UserTeam.Add(pokemonToAdd);

        //        return ctx.SaveChanges() == 1;
        //    }
        //}
    }
}
