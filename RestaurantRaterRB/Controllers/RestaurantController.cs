﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantRaterRB.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant/Index
        public ActionResult Index()
        {
            return View();
        }
    }
}