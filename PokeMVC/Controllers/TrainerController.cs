using PokeMVC.Data;
using PokeMVC.Models;
using PokeMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace PokeMVC.Controllers
{
    [Authorize]
    public class TrainerController : Controller
    {
        // GET: Trainer
        public ActionResult Index()
        {
            var trainerService = new TrainerService();
            var allTrainers = trainerService.GetTrainers();

            return View(allTrainers);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TrainerCreate trainer)
        {
            if (!ModelState.IsValid) return View(trainer);

            var trainerService = new TrainerService();

            if (trainerService.CreateTrainer(trainer))
            {
                TempData["SaveResult"] = "The trainer was added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "The trainer could not be added.");

            return View(trainer);
        }

        public ActionResult Details(int id)
        {
            var trainerService = new TrainerService();
            var trainer = trainerService.GetTrainerById(id);

            return View(trainer);
        }

        public ActionResult Edit(int id)
        {
            var trainerService = new TrainerService();
            var trainer = trainerService.GetTrainerById(id);
            var editedTrainer =
                new TrainerEdit
                {
                    TrainerId = trainer.TrainerId,
                    Name = trainer.Name,
                    IsGymLeader = trainer.IsGymLeader,
                    IsEliteFour = trainer.IsEliteFour,
                    IsChampion = trainer.IsChampion
                };

            return View(editedTrainer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TrainerEdit trainer)
        {
            if (!ModelState.IsValid) return View(trainer);

            if (trainer.TrainerId != id)
            {
                ModelState.AddModelError("", "Id does not match");
                return View(trainer);
            }

            var trainerService = new TrainerService();

            if (trainerService.UpdateTrainer(trainer))
            {
                TempData["SaveResult"] = "The trainer was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The trainer could not be updated.");
            return View(trainer);
        }

        public ActionResult Delete(int id)
        {
            var trainerService = new TrainerService();
            var trainer = trainerService.GetTrainerById(id);

            return View(trainer);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var trainerService = new TrainerService();

            trainerService.DeleteTrainer(id);

            TempData["SaveResult"] = "The trainer was deleted.";

            return RedirectToAction("Index");
        }
    }
}