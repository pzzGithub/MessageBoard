using MessageBoard.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MessageBoard.Controllers
{
    public class MessageController : Controller
    {
        private DataContext dataContext = new DataContext();

        //显示该主题下的所有留言回复
        public ActionResult Index(int id)
        {
            var topic = dataContext.Topics.Find(id);
            var messages = dataContext.Messages.Where(m => m.TopicId == id).ToList();
            var replies = dataContext.Replies.Where(r => r.Message.TopicId == id).ToList();
            ViewBag.Topic = topic;
            ViewBag.Messages = messages;
            ViewBag.Replies = replies;
            return View();
        }

        //添加留言
        [HttpPost]
        public ActionResult Create(Message message)
        {
            message.UserId = (int)Session["UserId"];
            message.CreateTime = DateTime.Now;
            dataContext.Messages.Add(message);
            dataContext.SaveChanges();
            return RedirectToAction("Index/" + message.TopicId);
        }

        //我的留言页面
        public ActionResult MyMessage(int?page)
        {
            if (Session["UserId"] != null)
            {
                int UserId = (int)Session["UserId"];
                var messages = dataContext.Messages.Where(m => m.UserId == UserId).ToList();
                int pageNumber = page ?? 1;
                int pageSize = 8;
                IPagedList<Message> pagedList = messages.ToPagedList(pageNumber, pageSize);
                return View(pagedList);
            }
            else
                return Content("未登陆");
        }

        //删除留言
        public ActionResult Delete(int id)
        {
            var message=dataContext.Messages.Find(id);
            if (message != null)
            {
                dataContext.Messages.Remove(message);
                dataContext.SaveChanges();
                return RedirectToAction("MyMessage");
            }
            else
                return Content("该留言不存在");
        }

        //编辑留言页面
        public ActionResult Edit(int id)
        {
            var message = dataContext.Messages.Find(id);
            if(message!=null)
            {
                return View(message);
            }
            else
                return Content("该留言不存在");
        }

        //修改留言
        [HttpPost]
        public ActionResult Edit(Message message)
        {
            var updateMessage=dataContext.Messages.Find(message.MessageId);
            updateMessage.MessageContent = message.MessageContent;
            dataContext.SaveChanges();
            return RedirectToAction("MyMessage");
        }
    }
}