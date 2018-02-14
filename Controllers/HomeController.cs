using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using lost_in_woods.Factories;
using lost_in_woods.Models;
using Microsoft.AspNetCore.Mvc;

namespace lost_in_woods.Controllers {
    public class HomeController : Controller {
        private readonly TrailFactory TrailFactory;
        public HomeController () {
            TrailFactory = new TrailFactory ();
        }
        public IActionResult Index () {
            ViewBag.trails = TrailFactory.AllTrails ();
            return View ();
        }

        public IActionResult AddTrail () {
            return View ("AddTRail");
        }

        [HttpPost]
        [Route ("Home/add")]
        public IActionResult add (Trail trail) {
            if (ModelState.IsValid) {
                TrailFactory.AddNewTrail (trail);
                return RedirectToAction ("Index");
            } else {
                return View ("AddTrail");
            }
        }

        [HttpGet]
        [Route ("Home/see/{tid}")]
        public IActionResult Show (int tid) {
            var trail = TrailFactory.ShowOne (tid);
            ViewBag.trail=trail[0];
            return View ("Show");
        }

        [HttpGet]
        [Route ("Home/show/{tid}")]
        public IActionResult ShowOne (int tid) {
            return RedirectToAction ("Show", new { id = tid });
        }

    }

}