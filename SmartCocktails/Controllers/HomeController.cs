using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartCocktails.Migrations;
using SmartCocktails.Models;
using System.Data.Entity;
namespace SmartCocktails.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
          
            ViewBag.Title = "Home Page";
            return View();
        }

      
    }
}
