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
    }
}