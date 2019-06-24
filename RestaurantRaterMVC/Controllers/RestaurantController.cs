using RestaurantRaterMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantRaterMVC.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant 
        private RestaurantDbContext _db = new RestaurantDbContext();
        public ActionResult Index()
        {
            return View(_db.Restaurants.ToList());
        }

        //GET Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }
        //post: restaurant/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _db.Restaurants.Add(restaurant);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }
    }
}