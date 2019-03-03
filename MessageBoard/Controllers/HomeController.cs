using MessageBoard.Models;
using PagedList;
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

        //显示所有留言主题
        public ActionResult Index(int? page)
        {
            var topics = dataContext.Topics.ToList();
            int pageNumber = page ?? 1;
            int pageSize = 8;
            IPagedList<Topic> pagedList = topics.ToPagedList(pageNumber, pageSize);
            return View(pagedList);
        }
        
    }
}