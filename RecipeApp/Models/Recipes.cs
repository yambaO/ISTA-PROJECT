using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RecipeApp.Models
{
    public class Recipes
    {
        public int Id { get; set; }
        [Display(Name = "Recipe Name")]
        public string RecipeName { get; set; }
        [Display(Name = " Type of Cuisine")]
        public TypeOfCuisines Cuisine { get; set; }
        public string Description { get; set; }
        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
        [Display(Name = "Added By")]
        public ApplicationUser CreatedBy { get; set; }
        [AllowHtml]
        public string Ingredients { get; set; }
        [Display(Name = "Number of servings")]
        public string Servings { get; set; }
        [Display(Name = "Cooking Time")]
        public string Time { get; set; }
        [AllowHtml]
        [Display(Name = "Instructions")]
        public string PreparationInstructions { get; set; }
     
    }
    public class RecipeModelCuisine
    {
        [Display(Name = "Cuisines")]
        public List<TypeOfCuisines> CuisineItems { get; set; }
        public Recipes RecipeItem { get; set; }
    }

    public class RecipeFromURL
    {
        public string URL { get; set; }
        public string SiteName { get; set; }
        public string Description { get; set; }
        public string Cuisine { get; set; }
    }
}