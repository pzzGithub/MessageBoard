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
            var topics = dataContext.Topics.ToList();
            return View(topics);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Topic topic)
        {
            topic.CreateTime = DateTime.Now;
            topic.UserId = (int)Session["UserId"];
            dataContext.Topics.Add(topic);
            dataContext.SaveChanges();
            return Content(topic.TopicTitle);
        }

        public ActionResult MyTopic()
        {
            int UserId = (int)Session["UserId"];
            var topics = dataContext.Topics.Where(t=>t.UserId.Equals(UserId)).ToList();
            return View(topics);
        }

        public ActionResult Edit(int id)
        {
            var topic=dataContext.Topics.Find(id);
            return View(topic);
            
        }
        [HttpPost]
        public ActionResult Edit(Topic topic)
        {
            Topic updateTopic=dataContext.Topics.Find(topic.TopicId);
            updateTopic.TopicTitle = topic.TopicTitle;
            updateTopic.TopicDescription = topic.TopicDescription;
            dataContext.SaveChanges();
            return RedirectToAction("MyTopic");
        }

        public ActionResult Delete(int id)
        {
            Topic topic=dataContext.Topics.Find(id);
            if(topic!=null)
            {
                dataContext.Topics.Remove(topic);
                dataContext.SaveChanges();
                return RedirectToAction("MyTopic");
            }
            else
            {
                return Content("该主题不存在");
            }
        }

    }
}