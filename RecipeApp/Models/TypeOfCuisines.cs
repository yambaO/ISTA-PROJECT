using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipeApp.Models
{
    public class TypeOfCuisines
    {
        public int Id { get; set; }

        [Display(Name = "Cuisine")]
        public string CuisineName { get; set; }
        public string CuisineDescription { get; set; }

    }
}