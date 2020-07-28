using PokeMVC.Data;
using PokeMVC.Models;
using PokeMVC.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI;

namespace PokeMVC.Controllers
{
    [Authorize]
    public class PokemonController : Controller
    {
        // GET: Pokemon
        public ActionResult Index()
        {
            var pokemonService = new PokemonService();
            var allPokemon = pokemonService.GetAllPokemon();

            return View(allPokemon);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PokemonCreate pokemon)
        {
            if (!ModelState.IsValid) return View(pokemon);

            var pokemonService = new PokemonService();

            if (pokemonService.CreatePokemon(pokemon))
            {
                TempData["SaveResult"] = "The Pokemon was added!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "The Pokemon could not be added.");

            return View(pokemon);
        }

        public ActionResult Details(int id)
        {
            var pokemonService = new PokemonService();
            var pokemon = pokemonService.GetPokemonById(id);

            return View(pokemon);
        }

        public ActionResult Edit(int id)
        {
            var pokemonService = new PokemonService();
            var pokemon = pokemonService.GetPokemonById(id);
            var editedPokemon =
                new PokemonEdit
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
                    IsMythical = pokemon.IsMythical
                };

            return View(editedPokemon);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PokemonEdit pokemon)
        {
            if (!ModelState.IsValid) return View(pokemon);

            if (pokemon.PokemonId != id)
            {
                ModelState.AddModelError("", "Id does not match");
                return View(pokemon);
            }

            var pokemonService = new PokemonService();

            if (pokemonService.UpdatePokemon(pokemon))
            {
                TempData["SaveResult"] = "The Pokemon was updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The Pokemon could not be updated.");
            return View(pokemon);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var pokemonService = new PokemonService();
            var pokemon = pokemonService.GetPokemonById(id);

            return View(pokemon);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var pokemonService = new PokemonService();

            pokemonService.DeletePokemon(id);

            TempData["SaveResult"] = "The Pokemon was deleted.";

            return RedirectToAction("Index");
        }

        public ActionResult AddMoveToPokemon(int id)
        {
            var pokemonService = new PokemonService();

            var moveService = new MoveService();

            var pokemon = pokemonService.GetPokemonById(id);

           // ViewBag.PokemonId = new SelectList(pokemonService.GetAllPokemon(), "PokemonId", "Species", pokemon.PokemonId);

            ViewBag.MoveId = new SelectList(moveService.GetMoves(), "MoveId", "MoveName");

            return View(pokemon);
        }

        [HttpPost]
        [ActionName("AddMoveToPokemon")]
        [ValidateAntiForgeryToken]
        public ActionResult AddMoveToPokemonPost(int pokemonId /*this int never gets used, pokemon id is in the model because of hidden for*/, int moveId, PokemonDetail pokemon)
        {
            var pokemonService = new PokemonService();

            pokemonService.AddMoveToPokemon(pokemon.PokemonId, moveId);

            TempData["SaveResult"] = "The move was added to the Pokemon!";

            return RedirectToAction("Index");
        }

        //[ActionName("CreateTeam")]
        //public ActionResult CreateTeam()
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var pokemonService = new PokemonService();
        //        ViewBag.PokemonId = new SelectList(ctx.AllPokemon.ToList(), "PokemonId", "Species");
        //        return View("UserTeam");
        //    }
        //}


        //[HttpPost]
        //[ActionName("AddPokemonToUserTeam")]
        //public ActionResult AddPokemonToUserTeamPost(int pokemonId)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var pokemonService = new PokemonService();

        //        pokemonService.AddPokemonToUserTeam(pokemonId);

        //        TempData["SaveResult"] = "The Pokemon was added to the user's team.";


        //        return RedirectToAction("UserTeam");
        //    }
        //}
    }
}