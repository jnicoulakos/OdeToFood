﻿using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class ReviewsController : Controller
    {


        OdeToFoodDb _db = new OdeToFoodDb();


        public ActionResult Index([Bind(Prefix="id")]  int restaurantId)
        {
            var restaurant = _db.Restaurants.Find(restaurantId);
            if (restaurant  != null)
            {
                return View(restaurant);
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Create(int restaurantId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RestaurantReview review) 
        {
            if (ModelState.IsValid) 
            {
                _db.Reviews.Add(review);
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.RestaurantId });
            
            }
            return View(review);
        }





        protected override void Dispose(bool disposing)
        {
            
            base.Dispose(disposing);
        }














    }
}
