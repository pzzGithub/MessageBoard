using MessageBoard.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MessageBoard.Controllers
{
    public class UserController : Controller
    {
        private DataContext dataContext = new DataContext();

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            dataContext.Users.Add(user);
            dataContext.SaveChanges();
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = from u in dataContext.Users
                       where u.Username == username && u.Password == password
                       select u;
            if (user.Count() > 0)
            {
                User u = user.First();
                Session["username"] = u.Username;
                return RedirectToAction("ShowSelf");
            }
            else
            {
                //登陆失败页面
                return View("View", null);
            }

        }

        public ActionResult ShowSelf()
        {
            string username = (string)Session["username"];
            if (username != null)
            {
                var user = from u in dataContext.Users
                           where u.Username == username
                           select u;
                User users = user.First();
                return View(users);
            }
            else
            {
                //未登录页面
                return View(new User(1, "pzz", "123456", "男", "email", DateTime.Now));
            }

        }

        public ActionResult EditUser(int id)
        {
            User user = dataContext.Users.Find(id);
            if (user == null)
                return HttpNotFound();
            return View(user);
        }
        [HttpPost]
        public ActionResult EditUser(User user)
        {
            if (ModelState.IsValid)
            {
                dataContext.Entry(user).State= EntityState.Modified;
                dataContext.SaveChanges();
                return RedirectToAction("ShowSelf");
            }
            return View(user);
        }

       
    }
}