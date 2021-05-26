using JustGoTravel.Data;
using JustGoTravel.Models.Rating;
using JustGoTravel.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JustGoTravel.WebMVC.Controllers
{

    [Authorize]
    public class RatingController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        //CRUD 

        // GET: Rating
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RatingService(userId);
            var model = service.GetRating();
            return View(model);
        }

        //GET CREATE
        public ActionResult Create()
        {
            return View();
        }
        //POST CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RatingCreate model)
        {
            //ModelState is Invalid
            if (!ModelState.IsValid)
                return View(model);

            var service = CreateRatingService();
            if (service.CreateRating(model))
            {
               TempData["SaveResult"] = "Rating was Created";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Rating Could NOT be Created");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateRatingService();
            var model = svc.GetRatingById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateRatingService();
            var detail = service.GetRatingById(id);
            var model =
                new RatingEdit
                {
                    ID = detail.ID,
                    HotelRating = detail.HotelRating,
                    FoodRating = detail.FoodRating

                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RatingEdit model)
        {
            if (!ModelState.IsValid)
            return View(model);

            if (model.ID != id)
            {
                ModelState.AddModelError("", "Invalid ID");
                return View(model);
            }
            var service = CreateRatingService();

            if (service.UpdateRating(model))
            {
                TempData["SaveResult"] = "Rating Updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Rating could NOT be updated");
            return View(model);
        }

        private RatingService CreateRatingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RatingService(userId);
            return service;
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRatingService();
            var model = svc.GetRatingById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateRatingService();

            service.DeleteRating(id);
            TempData["SaveResult"] = "Rating was Deleted";

            return RedirectToAction("Index");
        }
        

    }
}