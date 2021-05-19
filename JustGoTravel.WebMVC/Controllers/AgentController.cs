using JustGoTravel.Models.Agent;
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
    public class AgentController : Controller
    {
        // GET: Agent
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AgentService(userId);
            var model = service.GetAgents();
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
        public ActionResult Create(AgentCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var service = CreateAgentService();
            if (service.CreateAgent(model))
            {
                TempData["SaveResult"] = "Your Agent was Created";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Agent Could NOT be Created");
            return View(model);
        }

        private AgentService CreateAgentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AgentService(userId);
            return service;
        }
        public ActionResult Details(int id)
        {
            var svc = CreateAgentService();
            var model = svc.GetAgentById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateAgentService();
            var details = service.GetAgentById(id);
            var model = new AgentEdit
            {
                ID = details.ID,
                FirstName = details.FirstName,
                LastName = details.LastName,
                Company = details.Company,
                PhoneNumber = details.PhoneNumber,
                Email = details.Email,
                LinkedIn = details.LinkedIn

            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AgentEdit model)
        {
            if(!ModelState.IsValid)
                return View(model);
            if (model.ID != id)
            {
                ModelState.AddModelError("", "Invalid ID");
                return View(model);
            }
            var service = CreateAgentService();

            if (service.UpdateAgent(model))
            {
                TempData["SaveResult"] = "Agent was Updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Agent was NOT Updated");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateAgentService();
            var model = svc.GetAgentById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateAgentService();

            service.DeleteAgent(id);

            TempData["SaveResult"] = "Agent was Deleted";

            return RedirectToAction("Index");

        }

    }
}