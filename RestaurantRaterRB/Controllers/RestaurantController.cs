﻿using RestaurantRaterRB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace RestaurantRaterRB.Controllers
{
    public class RestaurantController : Controller
    {
        private RestaurantDbContext _db = new RestaurantDbContext();

        // GET: Restaurant/Index
        public ActionResult Index()
        {
            return View(_db.Restaurants.ToList());
        }

        // GET: Restaurant/Create
        public ActionResult Create()
        {
            return View(); // we don't want to pass a model. Want to pass a view
        }

        // POST: Restaurant/Create
        [HttpPost] // this attribute is needed bc we want the program to know that this is only a post method, not a get
        [ValidateAntiForgeryToken] // this is needed bc we created this in Views.Restaurant.Create.cshtml line 10
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _db.Restaurants.Add(restaurant);
                _db.SaveChanges();
                return RedirectToAction("Index"); // we don't want to return create view bc that wouldn't make sense here, so we use this return RedirectToAction to get to string Index
            }

            return View(restaurant); // If the ModelState Is Not Valid, we don't want to just wipe the form, we want to return the model that the inputter gave back to the view and populate that..we are being kind
        }

    }
}