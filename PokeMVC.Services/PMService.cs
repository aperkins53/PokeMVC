using PokeMVC.Data;
using PokeMVC.Models;
using PokeMVC.Models.PMModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace PokeMVC.Services
{
    public class PMService
    {
        public bool CreatePM(PMCreate pokemon)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var pokemonToAdd = new PokemonMove()
                {
                    PokemonId = pokemon.PokemonId,
                    MoveId = pokemon.MoveId
                };

                ctx.PokemonMoves.Add(pokemonToAdd);
                return ctx.SaveChanges() == 1;
            }
        }

        //public IEnumerable<PMListItem> GetAllPM()
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var allPokemon =
        //            ctx.AllPokemon.Select(p => new PMListItem
        //            {
        //                //pass data
        //            });

        //        return allPokemon.ToArray();
        //    }
        //}

        //public PMDetail GetPMById(int id)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var pokemon =
        //            ctx.AllPokemon.Single(p => p.PokemonId == id);

        //        return
        //            new PMDetail
        //            {
        //                //pass data
        //            };
        //    }
        //}

        //public bool UpdatePM(PMEdit pokemon)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var pokemonToUpdate =
        //            ctx.AllPokemon.Single(p => p.PokemonId == );

        //        //pass data

        //        return ctx.SaveChanges() == 1;
        //    }
        //}

        //public bool DeletePM(int pokemonId)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var pokemonToDelete =
        //            ctx.AllPokemon.Single(p => p.PokemonId == pokemonId);

        //        ctx.AllPokemon.Remove(pokemonToDelete);

        //        return ctx.SaveChanges() == 1;
        //    }
        //}
    }
}
