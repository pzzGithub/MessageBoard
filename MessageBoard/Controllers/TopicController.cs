using MessageBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MessageBoard.Controllers
{
    public class TopicController : Controller
    {
        private DataContext dataContext = new DataContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddTopic()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTopic(Topic topic)
        {
            dataContext.Topics.Add(topic);
            dataContext.SaveChanges();
            return Content(topic.TopicTitle);
        }
   
        public ActionResult ListTopics()
        {
            List<Topic> topics=dataContext.Topics.ToList();
            return View(topics);
        }

        public ActionResult EditTopic()
        {
            return View();
        }

        public ActionResult DeleteTopic(int id)
        {
            Topic topic=dataContext.Topics.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(topic);
            }
        }
    }
}