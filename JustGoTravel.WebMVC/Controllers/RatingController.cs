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
            if (!ModelState.IsValid)
                return View(model);

            var service = CreateRatingService();
            if (service.CreateRating(model))
            {
               TempData["SaveResult"] = "Rating was Created";
                return RedirectToAction("index");
            };
            ModelState.AddModelError("", "Rating Could NOT be Created");
            return View(model);
        }

        private RatingService CreateRatingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RatingService(userId);
            return service;
        }
    }
}