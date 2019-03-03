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

        //显示所有留言主题
        public ActionResult Index()
        {
            var topics = dataContext.Topics.ToList();

            return View(topics);
        }

        //添加留言主题页面
        public ActionResult Create()
        {
            return View();
        }

        //添加留言主题
        [HttpPost]
        public ActionResult Create(Topic topic)
        {
            topic.CreateTime = DateTime.Now;
            topic.UserId = (int)Session["UserId"];
            dataContext.Topics.Add(topic);
            dataContext.SaveChanges();
            return RedirectToAction("Index");
        }

        //我的留言主题页面
        public ActionResult MyTopic()
        {
            int UserId = (int)Session["UserId"];
            var topics = dataContext.Topics.Where(t => t.UserId == UserId).ToList();
            return View(topics);
        }

        //编辑留言主题页面
        public ActionResult Edit(int id)
        {
            var topic = dataContext.Topics.Find(id);
            return View(topic);

        }

        //修改留言主题
        [HttpPost]
        public ActionResult Edit(Topic topic)
        {
            Topic updateTopic = dataContext.Topics.Find(topic.TopicId);
            updateTopic.TopicTitle = topic.TopicTitle;
            updateTopic.TopicDescription = topic.TopicDescription;
            dataContext.SaveChanges();
            return RedirectToAction("MyTopic");
        }

        //删除留言主题
        public ActionResult Delete(int id)
        {
            Topic topic = dataContext.Topics.Find(id);
            if (topic != null)
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