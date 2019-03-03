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
            user.CreateTime = DateTime.Now;
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

                Session["Username"] = u.Username;
                Session["UserId"] = u.UserId;
                return RedirectToAction("Index", "Topic");
            }
            else
            {
                //登陆失败页面
                return Content("用户名或密码错误");
            }

        }

        public ActionResult Detail()
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
                return Content("未登陆");
            }

        }

        public ActionResult Edit(int id)
        {
            User user = dataContext.Users.Find(id);
            if (user == null)
                return HttpNotFound();
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (user != null)
            {
                var updateUser = dataContext.Users.Find(user.UserId);
                updateUser.Password = user.Password;
                updateUser.Sex = user.Sex;
                updateUser.Email = user.Email;
                dataContext.SaveChanges();
                return RedirectToAction("Detail");
            }
            return View(user);
        }


    }
}