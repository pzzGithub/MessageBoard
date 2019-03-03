using MessageBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MessageBoard.Controllers
{
    public class HomeController : Controller
    {
        private DataContext dataContext = new DataContext();

        //主页显示所有留言主题
        public ActionResult Index()
        {
            var topics = dataContext.Topics.ToList();
            return View(topics);
        }
    }
}