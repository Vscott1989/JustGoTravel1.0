using JustGoTravel.Models.VacationPack;
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
    public class VacationPackController : Controller
    {
        // GET: VacationPack
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new VacationService(userId);
            var model = service.GetVacations();
            return View(model);
        }

        //GET CREATE
        public ActionResult Create()
        {
            var svc = CreateVacationService();
            var ratingList = svc.GetRating();

            ViewBag.VacatoinsRatingList = new SelectList(ratingList, "ID", "VacationPackID");
            return View();
        }
        //POST CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VacationCreate model)
        {
            if (!ModelState.IsValid)
            return View(model);

            var service = CreateVacationService();
            if (service.CreateVacationPack(model))
            {
                TempData["SaveResult"] = "Vacation Was Created";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Vacation Could NOT be Created");
            return View(model);
        }

        private VacationService CreateVacationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new VacationService(userId);
            return service;
        }
        public ActionResult Details(int id)
        {
            var svc = CreateVacationService();
            var model = svc.GetVacationByID(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateVacationService();
            var detail = service.GetVacationByID(id);
            var model = new VacationEdit
            {
                ID = detail.ID,
                AgentID = detail.AgentID,
                Title = detail.Title,
                TripLength = detail.TripLength,
                TotalCost = detail.TotalCost,
                Location = detail.Location,
                Description =detail.Description,
                Included = detail.Included,
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VacationEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.ID != id)
            {
                ModelState.AddModelError("", "Invalid ID");
                return View(model);
            }
            var service = CreateVacationService();

            if (service.UpdateVacation(model))
            {
                TempData["SaveResult"] = "Vacation Updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Vacation was NOT Updated");
            return View(model);
            
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateVacationService();
            var model = svc.GetVacationByID(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateVacationService();

            service.DeleteVacation(id);

            TempData["SaveResult"] = "Vacation was Deleted";

            return RedirectToAction("Index");
        }

    }
}