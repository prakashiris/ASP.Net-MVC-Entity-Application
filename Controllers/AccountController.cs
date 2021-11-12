using EntitytoDatabse.Models;
using EntitytoDatabse.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntitytoDatabse.Controllers
{
    public class AccountController : Controller
    {
        private StoreContext _context;
        public AccountController()
        {
            _context = new StoreContext();
        }
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if(!ModelState.IsValid)
                return View("Register", user);

            if(_context.User.Where(u => u.Email == user.Email || u.UserName == user.UserName).Any())
            {
                ModelState.AddModelError("Email", "This email or UserName already exists.");
                return View("Register", user);
            }
            _context.User.Add(user);
            _context.SaveChanges();

            return Content("Your Registration is Performed Successfully ,Please Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginFormViewModel user)
        {
            if (!ModelState.IsValid)
                return View("Login", user);

            var loginUser = _context.User.Where(u => u.UserName == user.UserName && u.Password == user.Password && u.IsActive == true).FirstOrDefault();

            if(loginUser == null)
            {
                ModelState.AddModelError("UserName", "UserName Or Password is Incorrect, Please try with correct username and password");
                return View("Login", user);
            }
            else
            {
                Session["UserName"] = loginUser.UserName;
                return RedirectToAction("Index", "home");
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}