using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserRegistration.Models;
namespace UserRegistration.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult AddOrEdit(int id = 0)
        {
            User user = new User();
            return View(user);
        }
        [HttpPost]
        public ActionResult AddOrEdit(User user)
        {
            using ( DBModels db = new DBModels ())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful.";
            return View("AddOrEdit", new User() );
        }
    }
}