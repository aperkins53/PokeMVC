using PokeMVC.Data;
using PokeMVC.Models;
using PokeMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokeMVC.Controllers
{
    [Authorize]
    public class MoveController : Controller
    {
        // GET: Move
        public ActionResult Index()
        {
            var moveService = new MoveService();
            var allMoves = moveService.GetMoves();

            return View(allMoves);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MoveCreate move)
        {
            if (!ModelState.IsValid) return View(move);

            var moveService = new MoveService();

            if (moveService.CreateMove(move))
            {
                TempData["SaveResult"]= "The move was added!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "The move could not be added.");

            return View(move);
        }

        public ActionResult Details(int id)
        {
            var moveService = new MoveService();
            var move = moveService.GetMoveById(id);

            return View(move);
        }

        public ActionResult Edit(int id)
        {
            var moveService = new MoveService();
            var move = moveService.GetMoveById(id);
            var editedMove =
                new MoveEdit
                {
                    MoveId = move.MoveId,
                    MoveName = move.MoveName,
                    MovePower = move.MovePower,
                    MoveAccuracy = move.MoveAccuracy,
                    MovePP = move.MovePP,
                    ExtraEffect = move.ExtraEffect
                };

            return View(editedMove);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MoveEdit move)
        {
            if (!ModelState.IsValid) return View(move);

            if (move.MoveId != id)
            {
                ModelState.AddModelError("", "Id does not match");
                return View(move);
            }

            var moveService = new MoveService();
            
            if (moveService.UpdateMove(move))
            {
                TempData["SaveResult"] = "The move was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The move could not be updated.");
            return View(move);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var moveService = new MoveService();
            var move = moveService.GetMoveById(id);

            return View(move);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var moveService = new MoveService();

            moveService.DeleteMove(id);

            TempData["SaveResult"] = "The move was deleted.";

            return RedirectToAction("Index");
        }
    }
}