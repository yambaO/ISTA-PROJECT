using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipeApp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            //Simply returns the latest 10 recipes by the date added
            //var data = db.RecipeModels.OrderByDescending(x => x.DateAdded);
            List<Recipes> recipes = RecipesController.GetRecipes();
            return View(recipes.OrderByDescending(x => x.DateAdded).Take(10));
        }

        public ActionResult About()
        {
            ViewBag.Message = "About RecipeApp";

            return View();
        }
    }
}