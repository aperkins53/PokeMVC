using PokeMVC.Models;
using PokeMVC.Models.PMModels;
using PokeMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokeMVC.Controllers
{
    public class PMController : Controller
    {
        //public ActionResult Index()
        //{
        //    var service = new PMService();
        //    var allPokemon = service.GetAllPM();

        //    return View(allPokemon);
        //}

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ActionName("CreatePM")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PMCreate pokemon)
        {
            if (!ModelState.IsValid) return View(pokemon);

            var service = new PMService();

            if (service.CreatePM(pokemon))
            {
                TempData["SaveResult"] = "The Pokemon was added!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "The Pokemon could not be added.");

            return View(pokemon);
        }

        //public ActionResult Details(int id)
        //{
        //    var service = new PokemonService();
        //    var pokemon = service.GetPokemonById(id);

        //    return View(pokemon);
        //}

        //public ActionResult Edit(int id)
        //{
        //    var service = new PMService();
        //    var pokemon = service.GetPMById(id);
        //    var editedPokemon =
        //        new PMEdit
        //        {
        //            //pass data
        //        };

        //    return View(editedPokemon);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, PMEdit pokemon)
        //{
        //    if (!ModelState.IsValid) return View(pokemon);

        //    //if ()//id doesnt match
        //    //{
        //    //    ModelState.AddModelError("", "Id does not match.");
        //    //    return View(pokemon);
        //    //}

        //    var service = new PMService();

        //    if (service.UpdatePM(pokemon))
        //    {
        //        TempData["SaveResult"] = "The Pokemon was updated!";
        //        return RedirectToAction("Index");
        //    }

        //    ModelState.AddModelError("", "The Pokemon could not be updated.");
        //    return View(pokemon);
        //}

        //[ActionName("Delete")]
        //public ActionResult Delete(int id)
        //{
        //    var service = new PMService();
        //    var pokemon = service.GetPMById(id);

        //    return View(pokemon);
        //}

        //[HttpPost]
        //[ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeletePost(int id)
        //{
        //    var service = new PMService();

        //    service.DeletePM(id);

        //    TempData["SaveResult"] = "The Pokemon was deleted.";

        //    return RedirectToAction("Index");
        //}
    }
}