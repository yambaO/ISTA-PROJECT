using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RecipeApp.Models;
using RecipeApp;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using HtmlAgilityPack;

namespace RecipeApp.Controllers
{
    public class RecipesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Recipes
        [Authorize]
        public ActionResult Index()
        {
             ViewBag.SyncOrAsync = "Asynchronous";
             var recipes = db.RecipeModels.Include(x => x.CreatedBy).Include(y => y.Cuisine); //Include the creator and category details as well
             return View(recipes);
        }

        // GET: Recipes/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Return details of recipe including author and category based on id
            Recipes recipes = db.RecipeModels.Include(x => x.CreatedBy).Include(y => y.Cuisine).First(c => c.Id == id);

            if (recipes == null)
            {
                return HttpNotFound();
            }
            return View(recipes);
        }

        // GET: Recipes/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(RecipeModelCuisine recipeModel)
        {
            //Set the date of added to current date. Had to instanciate obj
            recipeModel.RecipeItem.DateAdded = new DateTime();
            recipeModel.RecipeItem.DateAdded = DateTime.Now;

            //Assigning the current logged in user as the creator of the recipe
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser user = db.Users.FirstOrDefault(x => x.Id == currentUserId);
            recipeModel.RecipeItem.CreatedBy = user;

            //Assigning a category based on dropdown value
            //Uses form dropdown value to find category then reassigns category data to the model
            int catId = recipeModel.RecipeItem.Cuisine.Id;
            TypeOfCuisines recCat = new TypeOfCuisines();
            recCat = db.Cuisines.FirstOrDefault(x => x.Id == catId);
            recipeModel.RecipeItem.Cuisine = recCat;

            //Making changes to db and redirecting
            db.RecipeModels.Add(recipeModel.RecipeItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Recipes/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeModelCuisine rec = new RecipeModelCuisine();
            rec.RecipeItem = db.RecipeModels.Include(x => x.Cuisine).FirstOrDefault(y => y.Id == id);

            if (rec.RecipeItem == null)
            {
                return HttpNotFound();
            }
            return View(rec);
        }

        // POST: Recipes/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(RecipeModelCuisine recipeModel)
        {
            if (ModelState.IsValid)
            {
                //Retrieve category information
                var cuisine = db.Cuisines.FirstOrDefault(x => x.Id == recipeModel.RecipeItem.Cuisine.Id);
                recipeModel.RecipeItem.Cuisine = cuisine;

                //Change recipe details
                db.RecipeModels.Attach(recipeModel.RecipeItem);
                var entry = db.Entry(recipeModel.RecipeItem);
                entry.Property(e => e.Ingredients).IsModified = true;
                entry.Property(e => e.PreparationInstructions).IsModified = true;
                entry.Property(e => e.RecipeName).IsModified = true;
                entry.Property(e => e.Servings).IsModified = true;
                entry.Property(e => e.Time).IsModified = true;
                entry.Property(e => e.Description).IsModified = true;

                //Change category details
                var catEntry = db.Entry(recipeModel.RecipeItem.Cuisine);
                catEntry.Property(e => e.CuisineName).IsModified = true;
                catEntry.Property(e => e.CuisineDescription).IsModified = true;

                //Make changes to db
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recipeModel.RecipeItem);
        }

        // GET: Recipes/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipes recipes = db.RecipeModels.Find(id);
            if (recipes == null)
            {
                return HttpNotFound();
            }
            return View(recipes);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipes recipes = db.RecipeModels.Find(id);
            db.RecipeModels.Remove(recipes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //Static method for use in other methods to allow access to Recipe data, mainly used for Main Index
        public static List<Recipes> GetRecipes()
        {
            ApplicationDbContext db = new ApplicationDbContext(); //No access to previous db context?
            List<Recipes> recipes = db.RecipeModels.Include(x => x.CreatedBy).Include(y => y.Cuisine).ToList(); //Include the creator and category details as well
            return recipes;
        }

        //Get recipes by user 
        public static List<Recipes> GetRecipesByUser(int i)
        {
            ApplicationDbContext db = new ApplicationDbContext(); //No access to previous db context?
            ApplicationUser usr = new ApplicationUser();
            List<Recipes> recipes = db.RecipeModels.Include(x => x.CreatedBy).Include(y => y.Cuisine).Where(x => x.Id == Int32.Parse(usr.Id)).ToList(); //Include the creator and category details as well
            return recipes;
        }
        //============================================================================================================================================================================================================
         public static async Task<Recipes> FindAnabelData(string data)
         {
           //Retrieve HTML doc from Anabel recipe site
            HttpClient http = new HttpClient();
            var response = await http.GetByteArrayAsync(data);
            String source = Encoding.GetEncoding("utf-8").GetString(response, 0, response.Length - 1);
            source = WebUtility.HtmlDecode(source);
            HtmlDocument resultat = new HtmlDocument();
            resultat.LoadHtml(source);

            //Using xpath and get by id to get specific data. Will need to change them if the website ever changes structure. 
            //Need to implement try/catch
            var recipeName = resultat.DocumentNode.SelectSingleNode("//*[@id='middle_col']/div[1]/h1").InnerText;
            var ingredients = resultat.DocumentNode.SelectSingleNode("//*[@id='ingred']").InnerHtml;
            var method = resultat.DocumentNode.SelectSingleNode("//*[@id='method']").InnerHtml;
            var recipeData = resultat.DocumentNode.SelectSingleNode("//*[@id='middle_col']/div[1]/dl");
            var servings = resultat.DocumentNode.SelectSingleNode("//*[@id='middle_col']/div[1]/dl/dd[3]").InnerText;
            var time = resultat.DocumentNode.SelectSingleNode("//*[@id='middle_col']/div[1]/dl/dd[2]").InnerText;

            //Debug to check if its working
            System.Diagnostics.Debug.WriteLine("Recipe Name: " + recipeName);
            System.Diagnostics.Debug.WriteLine("Servings: " + servings);
            System.Diagnostics.Debug.WriteLine("Time: " + time);

            //Modelling data to recipe model to pass back
            Recipes recipe = new Recipes();
            recipe.RecipeName = recipeName;
            recipe.Ingredients = ingredients;
            recipe.PreparationInstructions = method;
            recipe.Servings = servings;
            recipe.Time = time;

            return recipe;
         }
        [HttpPost]
        public async Task<ActionResult> CreateFromURL(RecipeFromURL rec)
        {
           //recipe data
            Recipes newRecipe = new Recipes();

            if (rec.SiteName == "Annabel")
            {
                newRecipe = await FindAnabelData(rec.URL);
            }
            newRecipe.Description = rec.Description;

            //date
            newRecipe.DateAdded = DateTime.Now;

            //User conversion
            string id = User.Identity.GetUserId();
            var user = db.Users.Find(id);
            newRecipe.CreatedBy = user;

            //Category
            newRecipe.Cuisine = db.Cuisines.Find(int.Parse(rec.Cuisine));

            db.RecipeModels.Add(newRecipe);
            db.SaveChanges();

            return RedirectToAction("Index", "Recipes");
        }

        //Perform async data test
        //Currently contains static URL for testing purposes

        //Only anabel langbein recipes will work at the moment
        public static async Task LoadTestPage()
        {
            await FindAnabelData("http://www.annabel-langbein.com/recipes/huntsmans-chicken-pie/3382/");
        }
    }
}