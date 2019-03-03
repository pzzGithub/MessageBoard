using MessageBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MessageBoard.Controllers
{
    public class ReplyController : Controller
    {
        private DataContext dataContext = new DataContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int id)
        {
            Message message = dataContext.Messages.Find(id);
            if (message != null)
            {
                return View(message);
            }
            else
            {
                return Content("该留言不存在");
            }
        }

        [HttpPost]
        public ActionResult Create(Reply reply)
        {
            if(Session["UserId"]!=null)
            {
                reply.UserId = (int)Session["UserId"];
                reply.CreateTime = DateTime.Now;
                dataContext.Replies.Add(reply);
                dataContext.SaveChanges();
                var message=dataContext.Messages.Find(reply.MessageId);
                return RedirectToAction("Index/"+message.TopicId, "Message");
            }
            else
            {
                return Content("未登录");
            }
        }

        public ActionResult MyReply()
        {
            if (Session["UserId"] != null)
            {
                int UserId = (int)Session["UserId"];
                var replies = dataContext.Replies.Where(r=>r.UserId==UserId).ToList();
                return View(replies);
            }
            else
                return Content("未登陆");
        }

        public ActionResult Delete(int id)
        {
            var reply = dataContext.Replies.Find(id);
            if (reply != null)
            {
                dataContext.Replies.Remove(reply);
                dataContext.SaveChanges();
                return RedirectToAction("MyReply");
            }
            else
                return Content("该回复不存在");
        }

        public ActionResult Edit(int id)
        {
            var reply = dataContext.Replies.Find(id);
            if (reply != null)
            {
                return View(reply);
            }
            else
                return Content("该回复不存在");
        }

        [HttpPost]
        public ActionResult Edit(Reply reply)
        {
            var updateReply = dataContext.Replies.Find(reply.ReplyId);
            updateReply.ReplyContent = reply.ReplyContent;
            dataContext.SaveChanges();
            return RedirectToAction("MyReply");
        }
    }
}